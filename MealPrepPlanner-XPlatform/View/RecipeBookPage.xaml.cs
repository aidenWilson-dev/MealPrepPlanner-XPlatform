using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrepPlanner_XPlatform.View;

public partial class RecipeBookPage : ContentPage
{
    public RecipeBookPage()
    {
        InitializeComponent();
    }

    private async void Close_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void Delete_OnClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Add_OnClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Edit_OnClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}