using MealPrepPlanner_XPlatform.Model;

namespace MealPrepPlanner_XPlatform.View;

public partial class WeekBreakdownPage : ContentPage
{
    
    private IList<Recipe>? _selectedRecipes;
    private int _mealsNeeded;
    
    public WeekBreakdownPage(IList<Recipe>? selectedRecipes, int mealsNeeded)
    {
        InitializeComponent();
        _selectedRecipes = selectedRecipes;
        _mealsNeeded = mealsNeeded;
        //LoadIngredientsView();
    }

    private void LoadIngredientsView()
    {
        throw new NotImplementedException();
    }

    private async void Close_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync(); 
    }
}