using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace MealPrepPlanner_XPlatform.Model;

public class Recipe : INotifyPropertyChanged
{
    //Property changed event
    public event PropertyChangedEventHandler? PropertyChanged;
    
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

    //Observable collection of ingredients 
    public ObservableCollection<Ingredient> Ingredients { get; } = new ObservableCollection<Ingredient>();

    //Add new ingredient to ObservableCollection
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
    
    //Invoke event, inform listeners that the supplied property value has changed
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}