using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealPrepPlanner_XPlatform.Model;

namespace MealPrepPlanner_XPlatform.View;

public partial class EditStepsPage : ContentPage
{

    private readonly Recipe _recipe;
    
    public EditStepsPage(Recipe recipe)
    {
        InitializeComponent();
        _recipe = recipe;
        /*
         * Done differently here because the collection view does not utilise the data template
         * if the binding context is set via the XAML page. It creates a new Recipe object
         * and binds the page to that, in this case we want to pass in an already created object
         */
        BindingContext = _recipe;
    }

    private async void Save_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void NewStep_OnClicked(object? sender, EventArgs e)
    {
        _recipe.AddStep("New Step");
        
        
    }
}