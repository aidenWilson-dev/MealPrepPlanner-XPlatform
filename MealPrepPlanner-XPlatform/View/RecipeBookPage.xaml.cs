using MealPrepPlanner_XPlatform.Model;

namespace MealPrepPlanner_XPlatform.View;

//Handles interaction logic for recipe book page
public partial class RecipeBookPage : ContentPage
{
    public RecipeBookPage()
    {
        InitializeComponent();
        //Font size 22 is too big on ios, so need to make it smaller 
        if (DeviceInfo.Platform != DevicePlatform.iOS) return;
        Add.FontSize = 20;
        Edit.FontSize = 20;
        Delete.FontSize = 20;
        Close.FontSize = 20;
    }

    //Event handler for add button
    private async void Add_OnClicked(object? sender, EventArgs e)
    {
        //Create the recipe
        var newRecipe = new Recipe();
        //Add recipe to recipe book
        GetModel().Recipes.Add(newRecipe);
        //Navigate to add recipe page
        await Navigation.PushAsync(new AddEditRecipePage(newRecipe));
    }
    
    //Event handler for add button
    private void Delete_OnClicked(object? sender, EventArgs e)
    {
        var recipeToDelete = SelectedRecipe();
        //Remove recipe from collection
        GetModel().Recipes.Remove(recipeToDelete);
        //Delete recipe file
        RecipeBook.DeleteRecipeFile(recipeToDelete);
    }
    
    private async void Edit_OnClicked(object? sender, EventArgs e)
    {
        //Navigate to the edit recipe page supplying the selected item in list
        await Navigation.PushAsync(new AddEditRecipePage(SelectedRecipe()));
    }
    
    private async void Close_OnClicked(object? sender, EventArgs e)
    {
        //Update all recipes 
        GetModel().UpdateRecipes();
        //Close page
        await Navigation.PopAsync();
    }
    
    private Recipe SelectedRecipe()
    {
        //Return the page that is selected in the list view
        var model = (Recipe)RecipeView.SelectedItem;
        return model;
    }
    
    private RecipeBook GetModel()
    {
        //Return recipe book model
        return (RecipeBook)BindingContext;
    }

    private void ViewRecipe_OnClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}