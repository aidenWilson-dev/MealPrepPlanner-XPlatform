
using System.Globalization;
using MealPrepPlanner_XPlatform.Model;

namespace MealPrepPlanner_XPlatform.View;

//Handles interaction logic for editing macros
public partial class EditMacrosPage : ContentPage
{
    //Recipe being edited
    private readonly Macros _macros;
    
    public EditMacrosPage(Macros macrosToEdit)
    {
        InitializeComponent();
        //Get recipe to edit and set placeholder text of Entry to the recipe name
        _macros = macrosToEdit;
        CalsEntry.Text = _macros.Cals.ToString();
        //Invariant culture as different cultures use different separator for the decimal place
        CarbsEntry.Text = _macros.Carbs.ToString(CultureInfo.InvariantCulture);
        ProteinEntry.Text = _macros.Protein.ToString(CultureInfo.InvariantCulture);
        FatEntry.Text = _macros.Fat.ToString(CultureInfo.InvariantCulture);
    }
    //Event handler for Save button
    private async void Save_OnClicked(object? sender, EventArgs e)
    {
        //Update macros 
        _macros.Cals = Convert.ToInt32(CalsEntry.Text);
        _macros.Carbs = Convert.ToDouble(CarbsEntry.Text);
        _macros.Protein = Convert.ToDouble(ProteinEntry.Text);
        _macros.Fat = Convert.ToDouble(FatEntry.Text);
        await Navigation.PopAsync();
    }
}