namespace MealPrepPlanner_XPlatform.Model;

public class Ingredient
{
    public string? IngredientName { get; set; }
    
    public double? IngredientAmount { get; set; }
    
    public string? AmountMeasurement { get; set; }
    
    //Constructor 
    public Ingredient(string name, double amount, string measurement)
    {
        //Set property's 
        IngredientName = name;
        IngredientAmount = amount;
        AmountMeasurement = measurement;
    }
}