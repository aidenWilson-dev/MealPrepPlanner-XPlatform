using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MealPrepPlanner_XPlatform.Model;
using Microsoft.Maui.Controls;

namespace MealPrepPlanner_XPlatform.View;

//Handles interaction logic for main page
public partial class MealSelectorPage : ContentPage
{
    //Amount of meals selected
    private readonly int _mealsNeeded;
    
    //Remaining meals
    private double _mealsRemaining;

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
        //If the user has selected to make fewer meals than needed this week
        if (_mealsRemaining > 0)
        {
            //Alert the user they have selected more recipes than needed and allow them to decide
            var answer = await DisplayAlert("Required Meals Not Reached", "With you're current selection you will create less meals than you need for this week. Are you sure you want to continue?", "Yes", "No");
            if (!answer) return;
        }
        //If the user has selected to make more meals than needed this week
        if (_mealsRemaining < 0)
        {
            //Alert the user they have selected more recipes than needed and allow them to decide
            var answer = await DisplayAlert("Required Meals Exceeded", "With you're current selection you will create more meals than you need for this week. Are you sure you want to continue?", "Yes", "No");
            if (!answer) return;
        }
        
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

    private void RecipeView_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        //Selected meals count
        var count = 0.0;
        //Loop through and count the amount of serves in the selected recipes
        foreach (var selectedRecipe in e.CurrentSelection.OfType<Recipe>())
        {
            count += selectedRecipe.RecipeMacros.Serves;
        }
        //Set the remaining meals label to the remaining meals
        _mealsRemaining = (_mealsNeeded - count);
        MealsRemainingLabel.Text = _mealsRemaining.ToString(CultureInfo.InvariantCulture);
    }
}