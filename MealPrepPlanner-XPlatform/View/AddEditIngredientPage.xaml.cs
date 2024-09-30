using MealPrepPlanner_XPlatform.Model;

namespace MealPrepPlanner_XPlatform.View;

//Handles interaction logic for add edit page of ingredient
public partial class AddEditIngredientPage : ContentPage
{
    //Ingredient being edited
    private readonly Ingredient _ingredient;
    
    public AddEditIngredientPage(Ingredient ingredientToEdit)
    {
        InitializeComponent();
        //Set model
        _ingredient = ingredientToEdit;
        //set measurement picker item source
        MeasurementPicker.ItemsSource = _ingredient.MeasurementTypes;
        //Set text fields and measurement picker selected item
        IngredientNameEntry.Text = _ingredient.IngredientName;
        IngredientAmountEntry.Text = $"{_ingredient.IngredientAmount}";
        MeasurementPicker.SelectedItem = _ingredient.AmountMeasurement;
        //Set binding context
        BindingContext = _ingredient;
    }

    //Event handler for save button
    private async void Save_OnClicked(object? sender, EventArgs e)
    {
        //Set name, amount and measurement
        _ingredient.IngredientName = IngredientNameEntry.Text;
        _ingredient.IngredientAmount = double.Parse(IngredientAmountEntry.Text);
        _ingredient.AmountMeasurement = (string)MeasurementPicker.SelectedItem;
        await Navigation.PopAsync();
    }
}