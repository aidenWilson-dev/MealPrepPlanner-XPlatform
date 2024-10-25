using System;
using System.Collections.ObjectModel;
using MealPrepPlanner_XPlatform.Model;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace MealPrepPlanner_XPlatform.View;

//Handles interaction logic for day selector page
public partial class DaySelectorPage : ContentPage
{
    //Amount of days selected to be skipped
    private int _daysSelected = 0;
    private const int MealsPerWeek = 21;

    //Recipe list that needs to be given to the recipe selector
    public RecipeBook? RecipeBook;
    
    public DaySelectorPage()
    {
        InitializeComponent();
    }
    
    private void Button_OnClicked(object? sender, EventArgs e)
    {
        //If sender is null or not a button
        if (sender is not Button button) return;
        //If the button is already selected
        if (button.Text == "Skipped")
        {
            //Change bg colour, text colour, text and border width back to default
            button.Text = "Skip";
            button.BackgroundColor = Color.FromArgb("#73C526");
            button.TextColor = Colors.White;
            button.BorderWidth = 0;
            //Increment days selected
            _daysSelected -= 1;
            return;
        }
        //If button is not skipped
        //Change to skipped preset
        button.Text = "Skipped";
        button.BackgroundColor = Colors.Black;
        button.TextColor = Color.FromArgb("#87D93A");
        button.BorderWidth = 2;
        _daysSelected += 1;
    }

    private async void Close_OnClicked(object? sender, EventArgs e)
    {
        //Close page
        await Navigation.PopAsync();
    }

    private async void Next_OnClicked(object? sender, EventArgs e)
    {
        //Calculate the amount of meals needed
        var mealsNeeded = MealsPerWeek - _daysSelected;
        if (RecipeBook != null)
        {
            //Open meal selector page
            await Navigation.PushAsync(new MealSelectorPage(RecipeBook, mealsNeeded));
        }
    }
}