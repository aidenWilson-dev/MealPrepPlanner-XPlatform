using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealPrepPlanner_XPlatform.Model;

namespace MealPrepPlanner_XPlatform.View;

public partial class EditStepsPage : ContentPage
{

    private Recipe _recipe;
    
    public EditStepsPage(Recipe recipe)
    {
        InitializeComponent();
        _recipe = recipe;
    }

    private async void Save_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void NewStep_OnClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}