using System.Collections.ObjectModel;
using System.Text;

namespace MealPrepPlanner_XPlatform.Model;

public class Recipe
{
    //Recipe name property, Recipe Name is default value
    public string RecipeName {get; set;} = "Recipe Name";

    //Observable collection of ingredients 
    public ObservableCollection<Ingredient> Ingredients { get; } = new ObservableCollection<Ingredient>();

    public void AddIngredient(string name, double amount, string measurement)
    {
        var newIngredient = new Ingredient(name, amount, measurement);
        Ingredients.Add(newIngredient);
    }

    public string IngredientDump()
    {
        //Output string builder
        var ingredientDump = new StringBuilder();

        //For each ingredient, add a new line to the dump in the form 
        //Ingredient:Amount:Measurement
        foreach (var ingredient in Ingredients)
        {
            var individualDump = new StringBuilder();
            individualDump.Append(
                $"{ingredient.IngredientName}:{ingredient.IngredientAmount}:{ingredient.AmountMeasurement}\n");
            ingredientDump.Append(individualDump);
        }
        //Return the dump
        return ingredientDump.ToString();
    }
}