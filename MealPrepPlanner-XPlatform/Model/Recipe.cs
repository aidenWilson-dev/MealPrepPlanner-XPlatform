using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Microsoft.Extensions.Primitives;

namespace MealPrepPlanner_XPlatform.Model;

public class Recipe : INotifyPropertyChanged
{
    //Property changed event
    public event PropertyChangedEventHandler? PropertyChanged;
    
    //Observable collection of ingredients 
    public ObservableCollection<Ingredient> Ingredients { get; } = new ObservableCollection<Ingredient>();
    
    //Observable collection of steps
    public ObservableCollection<Step> Steps { get; } = new ObservableCollection<Step>();
    
    //Macros object associated with recipe, default is 0 for each
    public Macros RecipeMacros = new Macros(0, 0, 0, 0);
    
    //Recipe name property, Recipe Name is default value
    private string _recipeName = "Recipe name";
    public string RecipeName
    {
        //Return name
        get => _recipeName;
        set
        {
            //Set name, notify UI of name change
            _recipeName = value;
            OnPropertyChanged(nameof(RecipeName));
        }
    }

    //Add new ingredient to ObservableCollection
    public void AddIngredient(string name, double amount, string measurement)
    {
        var newIngredient = new Ingredient(name, amount, measurement);
        Ingredients.Add(newIngredient);
    }
    
    //add new step to observable collection
    public void AddStep(string step)
    {
        var num = Steps.Count + 1;
        var newStep = new Step(num, step);
        Steps.Add(newStep);
    }
    
    //Add macros
    public void AddMacros(int cals, double carbs, double protein, double fat)
    {
        RecipeMacros.Cals = cals;
        RecipeMacros.Carbs = carbs;
        RecipeMacros.Protein = protein;
        RecipeMacros.Fat = fat;
    }

    public string IngredientDump()
    {
        //Output string builder
        var ingredientDump = new StringBuilder();
        ingredientDump.Append(RecipeMacros.MacrosDump());
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
    
    //Invoke event, inform listeners that the supplied property value has changed
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}