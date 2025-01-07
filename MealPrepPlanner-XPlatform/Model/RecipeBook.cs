using System;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.Maui.Storage;

namespace MealPrepPlanner_XPlatform.Model;

public class RecipeBook
{
    //Observable list of recipes
    public ObservableCollection<Recipe> Recipes { get; set; } = new ObservableCollection<Recipe>();
    
    public RecipeBook()
    {
        //Load recipes into recipes collection
        LoadRecipes();
    }

    //Get the directory with the recipes
    private static DirectoryInfo GetRecipeBookDirectory()
    {
        //Get the data path (app container on macOS and iOS)
        var appDataPath = FileSystem.AppDataDirectory;
        //Create new subfolder called Recipes
        var returnDirectory = Directory.CreateDirectory($"{appDataPath}/Recipes");
        return returnDirectory;
    }

    //Get recipe filename from recipe (as an object)
    private static string GetRecipeFileName(Recipe recipe)
    {
        //Recipe Name -> Recipe-Name.txt
        return $"{recipe.RecipeName.Replace(" ", "-")}.txt";
    }

    //get recipe name from file name
    private static string GetRecipeName(FileInfo recipeFileName)
    {
        //Recipe-Name.txt -> Recipe Name
        return recipeFileName.Name.Replace("-", " ").Replace(".txt", "");
    }

    //Update recipe file name
    public static void UpdateRecipeFileName(string oldName, string newName)
    {
        //Load directory
        var recipeBookFolder = GetRecipeBookDirectory();
        //For each file in recipes folder 
        foreach (var file in recipeBookFolder.GetFiles())
        {
            if (file.Name != oldName) continue;
            //Create a new file with the new name
            var newFile = new FileInfo($"{recipeBookFolder.FullName}/{newName}");
            newFile.Create();
            //Delete the old file
            //The file contents can be discarded as its re-written when the page is closed
            file.Delete();
        }
    }
    
    //Delete recipe file
    public static void DeleteRecipeFile(Recipe recipe)
    {
        //Load directory
        var recipeBookFolder = GetRecipeBookDirectory();
        var recipeFileName = GetRecipeFileName(recipe);
        //Find the file with the same name as the recipe
        foreach (var file in recipeBookFolder.GetFiles())
        {
            if (recipeFileName == file.Name)
            {
                //delete it
                file.Delete();
            }
        }
    }
    
    //Update recipe contents
    public void UpdateRecipes()
    {
        //Load directory
        var recipeBookFolder = GetRecipeBookDirectory();
        //for each recipe in the recipe list
        foreach (var recipe in Recipes)
        {
            //Flag to denote if file was found
            var fileFound = false;
            //Convert recipe name to file name
            var recipeFileName = GetRecipeFileName(recipe);
            //Field to store file when/if found
            FileInfo? correspondingFile = null;
            //Find the file with the same name as the recipe
            foreach (var file in recipeBookFolder.GetFiles())
            {
                if (recipeFileName != file.Name) continue;
                //set file found flag and corresponding file field
                fileFound = true;
                correspondingFile = file;
            }
            //Write to file
            if (fileFound)
            {
                if (correspondingFile != null)
                {
                    WriteToFile(recipe, correspondingFile);
                }
            }
            //If file not found
            else
            {
                //Create new file and write to it
                var newFile = new FileInfo($"{recipeBookFolder.FullName}/{recipeFileName}");
                WriteToFile(recipe, newFile);
            }
        }
    }

    //Write recipe contents to file
    private static void WriteToFile(Recipe recipe, FileInfo newFile)
    {
        try
        {
            //Get recipe dump
            var recipeDump = recipe.RecipeDump();
            //Write to file
            if (newFile.Directory != null)
            {
                File.WriteAllText(newFile.FullName, recipeDump);
            }
        }
        //Handle error
        catch (Exception e)
        {
            Console.WriteLine("Error occured when updating recipe file");
            Console.WriteLine(e);
            throw;
        }
    }

    private void LoadRecipes()
    {
        //Load directory
        var recipeBookFolder = GetRecipeBookDirectory();
        //Load saved recipe files
        var recipeFolder = recipeBookFolder.GetFiles();
        foreach (var recipeFile in recipeFolder)
        {
            var ingredientsLoaded = false;
            //If the file is a .DS_Store file, skip the current iteration
            if (recipeFile.Name == ".DS_Store") continue;
            try
            {
                //Create a new recipe and read from recipe
                var newRecipe = new Recipe();
                //Read all lines in from file
                var recipeFileLines = File.ReadAllLines(recipeFile.FullName);
                for (var i = 0; i < recipeFileLines.Length; i++)
                {
                    var ingredientLine = recipeFileLines[i];
                    //If we are on the first line of the file 
                    //Which is where the macros are stored
                    if (i == 0)
                    {
                        //Split line at separator
                        var parts = ingredientLine.Split(":");
                        //Get macros
                        var cals = int.Parse(parts[0]);
                        var serves = int.Parse(parts[1]);
                        var carbs = double.Parse(parts[2]);
                        var protein = double.Parse(parts[3]);
                        var fat = double.Parse(parts[4]);
                        //Add macros to recipe
                        newRecipe.AddMacros(cals, serves, carbs, protein, fat);
                    }
                    //If we have encountered the ingredient steps separator 
                    else if (ingredientLine.Contains('-'))
                    {
                        //All ingredients have been loaded
                        ingredientsLoaded = true;
                    }
                    //If we are in the steps section of the file
                    else if (ingredientsLoaded)
                    {
                        newRecipe.AddStep(ingredientLine);
                    }
                    //Ingredients section of file 
                    else
                    {
                        //Split line at separator
                        var parts = ingredientLine.Split(":");
                        //Get parts
                        var ingredientName = parts[0];
                        var ingredientAmount = int.Parse(parts[1]);
                        var amountMeasurement = parts[2];
                        //Add ingredient to recipe
                        newRecipe.AddIngredient(ingredientName, ingredientAmount, amountMeasurement);
                    }
                }
                //convert recipe filename to recipe name
                var recipeName = GetRecipeName(recipeFile);
                //set name of recipe and add to recipe list 
                newRecipe.RecipeName = recipeName;
                Recipes.Add(newRecipe);
            }
            //Handle error
            catch (Exception e)
            {
                Console.WriteLine("Error occured when loading recipe file");
                Console.WriteLine(e);
                throw;
            }
        }
    }
}