using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;

namespace MealPrepPlanner_XPlatform.View;

//Handles interaction logic for main page
public partial class MainPage : ContentPage
{
    private readonly RecipeBookPage _recipeBookPage;
    private readonly DaySelectorPage _daySelectorPage; 
    public MainPage()
    {
        InitializeComponent();
        //Create pages so recipes are loaded and created once
        _recipeBookPage = new RecipeBookPage();
        _daySelectorPage = new DaySelectorPage();
        //Exit button is not needed on IOS, so if the platform is ios, hide it
        if (DeviceInfo.Platform == DevicePlatform.iOS)
        {
            Exit.IsVisible = false;
        }
    }

    //Event handler for exit button
    private void Exit_OnClicked(object? sender, EventArgs e)
    {
        //Close application
        Application.Current?.Quit(); 
    }

    //Event handler for recipe book button
    private async void RecipeBook_OnClicked(object? sender, EventArgs e)
    {
        //Navigate to recipe book page
        await Navigation.PushAsync(_recipeBookPage);
    }
    
    //Event handler for meal planner button
    private async void MealPlanner_OnClicked(object? sender, EventArgs e)
    {
        //Supply the day selector with the recipe list
        var recipeBook = _recipeBookPage.GetModel();
        _daySelectorPage.RecipeBook = recipeBook;
        //Navigate to recipe book page
        await Navigation.PushAsync(_daySelectorPage);
    }
}