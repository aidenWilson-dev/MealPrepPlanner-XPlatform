using MealPrepPlanner_XPlatform.Model;

namespace MealPrepPlanner_XPlatform.View;

//Handles interaction logic with the page that displays recipe ingredients
//(and potentially instructions in future)
public partial class RecipePage : ContentPage
{
    public RecipePage(Recipe recipeToView)
    {
        InitializeComponent();
        BindingContext = recipeToView;
    }

    private async void Close_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}