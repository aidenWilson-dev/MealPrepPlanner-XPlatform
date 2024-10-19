using MealPrepPlanner_XPlatform.Model;

namespace MealPrepPlanner_XPlatform.View;

//Handles interaction logic for edit steps page
public partial class EditStepsPage : ContentPage
{

    //Recipe being edited
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

    //Event handler for save button
    private async void Save_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    //Event handler for new step button
    private void NewStep_OnClicked(object? sender, EventArgs e)
    {
        //Add a new step with default text
        _recipe.AddStep("New Step");
    }
}