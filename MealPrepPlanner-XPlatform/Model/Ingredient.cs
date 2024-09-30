using System.ComponentModel;

namespace MealPrepPlanner_XPlatform.Model;

//Data class for ingredient
public class Ingredient(string name, double amount, string measurement)
{
    //Property changed event
    public event PropertyChangedEventHandler? PropertyChanged;
    
    //Property for ingredient name
    private string? _ingredientName = name;
    public string? IngredientName
    {
        //Return ingredient name
        get => _ingredientName;
        set
        {
            //Set ingredient name and notify property changed
            _ingredientName = value;
            OnPropertyChanged(nameof(IngredientName));
        }
    }
    
    //Property for ingredient amount
    private double? _ingredientAmount = amount;
    public double? IngredientAmount
    {
        //Return ingredient name
        get => _ingredientAmount;
        set
        {
            //Set ingredient amount and notify property changed
            _ingredientAmount = value;
            OnPropertyChanged(nameof(IngredientName));
        }
    }

    //Property for amount measurement
    private string? _amountMeasurement = measurement;
    public string? AmountMeasurement
    {
        //Return ingredient name
        get => _amountMeasurement;
        set
        {
            //Set amount measurement and notify property changed
            _amountMeasurement = value;
            OnPropertyChanged(nameof(IngredientName));
        }
    }
    
    //Invoke event, inform listeners that the supplied property value has changed
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}