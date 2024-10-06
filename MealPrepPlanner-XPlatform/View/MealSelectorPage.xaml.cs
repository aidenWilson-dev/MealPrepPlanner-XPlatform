using MealPrepPlanner_XPlatform.Model;

namespace MealPrepPlanner_XPlatform.View;

//Handles interaction logic for main page
public partial class MealSelectorPage : ContentPage
{
    //Amount of meals selected
    private int _mealsSelected;
    //recipe book 
    private RecipeBook _recipeBook;
    
    public MealSelectorPage(RecipeBook recipeBook, int mealsNeeded)
    {
        InitializeComponent();
        _recipeBook = recipeBook;
        _mealsSelected = mealsNeeded;
        //Set binding context to recipe book
        BindingContext = recipeBook;
    }

    private async void ViewRecipe_OnClicked(object? sender, EventArgs e)
    {
        //Navigate to the recipe view supplying the selected item in list
        var selectedModel = SelectedRecipe();
        if (selectedModel == null) return;
        await Navigation.PushAsync(new RecipePage(selectedModel));
    }

    private async void Close_OnClicked(object? sender, EventArgs e)
    {
        //Close page
        await Navigation.PopAsync();
    }

    private async void Next_OnClicked(object? sender, EventArgs e)
    {
        var mealsNeeded = 21 - _mealsSelected;
        Console.WriteLine(mealsNeeded);
        await Navigation.PushAsync(new WeekBreakdownPage(_recipeBook, mealsNeeded));
    }
    
    private Recipe? SelectedRecipe()
    {
        //Since this recipe view is multi-select, multiple items may be selected
        var selectedItems = RecipeView.SelectedItems;
        //If there is only one selected item return that recipe
        if (selectedItems.Count == 1)
        {
            return (Recipe)selectedItems[0];
        }
        //Otherwise return null
        return null;
    }
}