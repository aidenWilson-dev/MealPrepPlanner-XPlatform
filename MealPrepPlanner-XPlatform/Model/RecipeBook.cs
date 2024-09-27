using System.Collections.ObjectModel;

namespace MealPrepPlanner_XPlatform.Model;

public class RecipeBook
{
    public ObservableCollection<Recipe> Recipes { get; set; } = new ObservableCollection<Recipe>();
    
    public RecipeBook()
    {
        LoadRecipes();
    }

    //Get the directory with the recipes
    public static DirectoryInfo GetRecipeBookDirectory()
    {
        var appDataPath = FileSystem.AppDataDirectory;
        var returnDirectory = Directory.CreateDirectory($"{appDataPath}/Recipes");
        return returnDirectory;
    }

    //Get recipe filename from recipe (as an object)
    public static string GetRecipeFileName(Recipe recipe)
    {
        return $"{recipe.RecipeName.Replace(" ", "-")}.txt";
    }
    
    //Get recipe file name from recipe name (as a string) 
    public static string GetRecipeFileName(string recipeName)
    {
        return $"{recipeName.Replace(" ", "-")}.txt";
    }

    //get recipe name from file name
    public static string GetRecipeName(FileInfo recipeFileName)
    {
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
            if (file.Name == oldName)
            {
                //Create a new file with the new name
                var newFile = new FileInfo($"{recipeBookFolder.FullName}/{newName}");
                newFile.Create();
                //Delete the old file
                //The file contents can be discarded as its re-written when the page is closed
                file.Delete();
            }
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
                if (recipeFileName == file.Name)
                {
                    //set file found flag and corresponding file field
                    fileFound = true;
                    correspondingFile = file;
                }
            }
            //Write to file
            if (fileFound)
            {
                WriteToFile(recipe, correspondingFile);
            }
            //If file not found
            else
            {
                try
                {
                    //Create new file and write to it, handling appropriate errors
                    var newFile = new FileInfo($"{recipeBookFolder.FullName}/{recipeFileName}");
                    newFile.Create();
                    WriteToFile(recipe, newFile);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error occured when updating recipe file");
                    Console.WriteLine(e);
                    throw;
                }
            }

        }
    }

    //Write recipe contents to file
    public static void WriteToFile(Recipe recipe, FileInfo newFile)
    {
        try
        {
            //Get recipe dump
            var recipeDump = recipe.IngredientDump();
            //Write to file
            if (newFile.Directory != null)
            {
                File.WriteAllText(newFile.Directory.FullName, recipeDump);
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

    public void LoadRecipes()
    {
        //Load directory
        var recipeBookFolder = GetRecipeBookDirectory();
        //Load saved recipe files
        var recipeFolder = recipeBookFolder.GetFiles();
        foreach (var recipeFile in recipeFolder)
        {
            try
            {
                //Create a new recipe and read from recipe
                var newRecipe = new Recipe();
                //Read all lines in from file
                foreach (var ingredientLine in File.ReadAllLines(recipeFile.FullName))
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