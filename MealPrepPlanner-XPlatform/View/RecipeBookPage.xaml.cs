using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealPrepPlanner_XPlatform.Model;

namespace MealPrepPlanner_XPlatform.View;

public partial class RecipeBookPage : ContentPage
{
    
    public RecipeBookPage()
    {
        InitializeComponent();
    }

    private async void Add_OnClicked(object? sender, EventArgs e)
    {
        var recipeBook = (Model.RecipeBook)BindingContext;
        var newRecipe = new Recipe();
        recipeBook.Recipes.Add(newRecipe);
        await Navigation.PushAsync(new AddEditRecipePage(newRecipe));
    }
    
    private void Delete_OnClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
    
    private async void Edit_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddEditRecipePage(SelectedRecipe()));
    }
    
    private async void Close_OnClicked(object? sender, EventArgs e)
    {
        var model = (Model.RecipeBook)BindingContext;
        model.UpdateRecipes();
        await Navigation.PopAsync();
    }
    
    private Recipe SelectedRecipe()
    {
        var model = (Model.Recipe)RecipeView.SelectedItem;
        return model;
    }

    private void RecipeView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}