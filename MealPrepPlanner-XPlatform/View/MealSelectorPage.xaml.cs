using System;
using System.Collections.Generic;
using System.Linq;
using MealPrepPlanner_XPlatform.Model;
using Microsoft.Maui.Controls;

namespace MealPrepPlanner_XPlatform.View;

//Handles interaction logic for main page
public partial class MealSelectorPage : ContentPage
{
    //Amount of meals selected
    private readonly int _mealsNeeded;

    public MealSelectorPage(RecipeBook recipeBook, int mealsNeeded)
    {
        InitializeComponent();
        _mealsNeeded = mealsNeeded;
        MealsRemainingLabel.Text = _mealsNeeded.ToString();
        //Set binding context to recipe book
        BindingContext = recipeBook;
    }

    private async void ViewRecipe_OnClicked(object? sender, EventArgs e)
    {
        //Get the recipe that the view button that was clicked is attached too
        var button = sender as Button;
        var selectedModel = button?.CommandParameter as Recipe;
        //if the model is not null navigate to a recipe page with that model
        if (selectedModel == null) return;
        await Navigation.PushAsync(new RecipePage(selectedModel));
    }

    private async void Close_OnClicked(object? sender, EventArgs e)
    {
        //Close page
        await Navigation.PopAsync();
    }

    private async void Next_OnClicked(object? sender, EventArgs e)
    {
        //Get selected recipes
        var selectedRecipes = SelectedRecipes();
        //Check if the selected items is not null and the length is greater than or equal to 1
        if (selectedRecipes is not { Count: >= 1 }) return;
        //Open week breakdown page 
        await Navigation.PushAsync(new WeekBreakdownPage(selectedRecipes, _mealsNeeded));
    }
    
    private List<Recipe> SelectedRecipes()
    {
        //Since this recipe view is multi-select, multiple items may be selected
        var selectedItems = RecipeView.SelectedItems;
        //Return selected items as a list of recipes
        return selectedItems.Cast<Recipe>().ToList();
    }
}