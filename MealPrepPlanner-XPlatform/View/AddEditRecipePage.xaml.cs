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

    private void Add_OnClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Delete_OnClicked(object? sender, EventArgs e)
    {
        var selectedIngredient = SelectedIngredient();
        _recipe.Ingredients.Remove(selectedIngredient);
    }

    private void Edit_OnClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private async void Save_OnClicked(object? sender, EventArgs e)
    {
        var oldName = _recipe.RecipeName;
        var newName = RecipeNameEntry.Text;
        if (oldName != newName)
        {
            RecipeBook.UpdateRecipeFileName(oldName, newName);
            _recipe.RecipeName = newName;
        }
        await Navigation.PopAsync();
    }
    
    private void OnEntryTextChanged(object sender, EventArgs e)
    {
        var newRecipeName = ((Entry)sender).Text;
        _recipe.RecipeName = newRecipeName;
    }
    
    private Ingredient SelectedIngredient()
    {
        var model = (Ingredient)IngredientView.SelectedItem;
        return model;
    }

    
}