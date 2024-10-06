using MealPrepPlanner_XPlatform.Model;

namespace MealPrepPlanner_XPlatform.View;

public partial class WeekBreakdownPage : ContentPage
{
    
    private RecipeBook _recipeBook;
    private int _mealsNeeded;
    
    public WeekBreakdownPage(RecipeBook recipeBook, int mealsNeeded)
    {
        InitializeComponent();
        _recipeBook = recipeBook;
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