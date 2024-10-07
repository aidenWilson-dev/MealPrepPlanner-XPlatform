using System.Collections.ObjectModel;
using MealPrepPlanner_XPlatform.Model;

namespace MealPrepPlanner_XPlatform.View;


//Handles interaction logic for week breakdown page
public partial class WeekBreakdownPage : ContentPage
{
 
    //Fields for the selected recipes, the meals needed and the observable collection to be displayed
    private readonly List<Recipe> _selectedRecipes;
    private readonly int _mealsNeeded;
    private readonly ObservableCollection<Ingredient> _ingredientSum = new ObservableCollection<Ingredient>();
    
    public WeekBreakdownPage(List<Recipe> selectedRecipes, int mealsNeeded)
    {
        InitializeComponent();
        //Set fields
        _selectedRecipes = selectedRecipes;
        _mealsNeeded = mealsNeeded;
        //Set source of ingredient view
        IngredientView.ItemsSource = _ingredientSum;
        //Load ingredient sums into view
        LoadIngredientsView();
    }

    private void LoadIngredientsView()
    {
        //Amount of meals per recipe for the entire week
        var mealsPerRecipe = _mealsNeeded / _selectedRecipes.Count;
        foreach (var recipe in _selectedRecipes)
        {
            foreach (var ingredient in recipe.Ingredients)
            {
                //Get the total amount of the ingredient for this recipe
                var totalAmount = ingredient.IngredientAmount * mealsPerRecipe;

                // Check if the ingredient already exists in the list
                var existingIngredient = _ingredientSum.FirstOrDefault(i => i.IngredientName == ingredient.IngredientName 
                                                                            && i.AmountMeasurement == ingredient.AmountMeasurement);
        
                if (existingIngredient != null)
                {
                    // If ingredient exists with the same name and measurement, update the amount
                    existingIngredient.IngredientAmount += totalAmount;
                }
                else
                {
                    // Otherwise, add it as a new ingredient
                    var amountSum = new Ingredient(ingredient.IngredientName, totalAmount, ingredient.AmountMeasurement);
                    _ingredientSum.Add(amountSum);
                }
            }
        }
        
    }

    private async void Close_OnClicked(object? sender, EventArgs e)
    {
        //close page
        await Navigation.PopAsync(); 
    }
}