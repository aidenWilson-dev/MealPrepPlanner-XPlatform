using System.Globalization;
using MealPrepPlanner_XPlatform.Model;

namespace MealPrepPlanner_XPlatform.View;

//Handles interaction logic for add edit page
public partial class AddEditRecipePage : ContentPage
{
    //Recipe being edited
    private readonly Recipe _recipe;
    
    public AddEditRecipePage(Recipe recipeToEdit)
    {
        InitializeComponent();
        //Get recipe to edit and set placeholder text of Entry to the recipe name
        _recipe = recipeToEdit;
        RecipeNameEntry.Text = _recipe.RecipeName;
        //Set binding context
        /*
         * Done differently here because the collection view does not utilise the data template
         * if the binding context is set via the XAML page. It creates a new Recipe object
         * and binds the page to that, in this case we want to pass in an already created object
        */
        BindingContext = _recipe;
    }

    //Event handler for add button
    private async void Add_OnClicked(object? sender, EventArgs e)
    {
        //Create the recipe
        var newIngredient= new Ingredient("New Ingredient", 0, "Units");
        //Add recipe to recipe book
        _recipe.Ingredients.Add(newIngredient);
        //Navigate to add recipe page
        await Navigation.PushAsync(new AddEditIngredientPage(newIngredient));
    }

    //Event handler for delete button
    private void Delete_OnClicked(object? sender, EventArgs e)
    {
        var selectedIngredient = SelectedIngredient();
        _recipe.Ingredients.Remove(selectedIngredient);
    }
    
    //Event handler for edit button
    private async void Edit_OnClicked(object? sender, EventArgs e)
    {
        //Navigate to the edit ingredient page supplying the selected item in list
        await Navigation.PushAsync(new AddEditIngredientPage(SelectedIngredient()));
    }
    
    //Event handler for Save button
    private async void Save_OnClicked(object? sender, EventArgs e)
    {
        //See if name has changed
        var oldName = _recipe.RecipeName;
        var newName = RecipeNameEntry.Text;
        if (oldName != newName)
        {
            //If it has update the file name and recipe name
            RecipeBook.UpdateRecipeFileName(oldName, newName);
            _recipe.RecipeName = newName;
        }
        await Navigation.PopAsync();
    }
    
    //Event handler for macros button
    private async void Macros_OnClicked(object? sender, EventArgs e)
    {
        //Navigate to the edit ingredient page supplying the selected item in list
        await Navigation.PushAsync(new EditMacros(_recipe.RecipeMacros));
    }

    //Event handler for steps button
    private void Steps_OnClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
    
    private Ingredient SelectedIngredient()
    {
        var model = (Ingredient)IngredientView.SelectedItem;
        return model;
    }
}