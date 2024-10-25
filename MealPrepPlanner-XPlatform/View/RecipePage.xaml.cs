using System;
using System.Globalization;
using MealPrepPlanner_XPlatform.Model;
using Microsoft.Maui.Controls;

namespace MealPrepPlanner_XPlatform.View;

//Handles interaction logic with the page that displays recipe ingredients
//(and potentially instructions in future)
public partial class RecipePage : ContentPage
{
    public RecipePage(Recipe recipeToView)
    {
        //Set binding context
        InitializeComponent();
        BindingContext = recipeToView;
        CaloriesLabel.Text = recipeToView.RecipeMacros.Cals.ToString();
        CarbsLabel.Text = recipeToView.RecipeMacros.Carbs.ToString(CultureInfo.InvariantCulture);
        ProteinLabel.Text = recipeToView.RecipeMacros.Protein.ToString(CultureInfo.InvariantCulture);
        FatLabel.Text = recipeToView.RecipeMacros.Fat.ToString(CultureInfo.InvariantCulture);
    }

    private async void Close_OnClicked(object? sender, EventArgs e)
    {
        //Close page
        await Navigation.PopAsync();
    }
}