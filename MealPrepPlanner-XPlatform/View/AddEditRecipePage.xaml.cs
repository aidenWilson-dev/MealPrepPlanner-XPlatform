using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealPrepPlanner_XPlatform.Model;

namespace MealPrepPlanner_XPlatform.View;

public partial class AddEditRecipePage : ContentPage
{
    private Recipe recipe;
    
    public AddEditRecipePage(Recipe recipeToEdit)
    {
        InitializeComponent();
        recipe = recipeToEdit;
        RecipeNameEntry.Placeholder = recipe.RecipeName;
        BindingContext = recipe;
        
    }

    private void Add_OnClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Delete_OnClicked(object? sender, EventArgs e)
    {
        var selectedIngredient = SelectedIngredient();
        recipe.Ingredients.Remove(selectedIngredient);
    }

    private void Edit_OnClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private async void Save_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    
    private void OnEntryTextChanged(object sender, EventArgs e)
    {
        var newRecipeName = ((Entry)sender).Text;
        recipe.RecipeName = newRecipeName;
    }
    
    private Ingredient SelectedIngredient()
    {
        var model = (Model.Ingredient)IngredientView.SelectedItem;
        return model;
    }

    
}