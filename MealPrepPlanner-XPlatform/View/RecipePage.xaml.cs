using MealPrepPlanner_XPlatform.Model;

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
    }

    private async void Close_OnClicked(object? sender, EventArgs e)
    {
        //Close page
        await Navigation.PopAsync();
    }
}