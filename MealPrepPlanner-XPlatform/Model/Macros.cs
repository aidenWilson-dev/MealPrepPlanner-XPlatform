using System.ComponentModel;
using System.Text;

namespace MealPrepPlanner_XPlatform.Model;

public class Macros(int cals, double serves, double carbs, double protein, double fat) : INotifyPropertyChanged
{
    //Property changed event
    public event PropertyChangedEventHandler? PropertyChanged;
    
    //Property for calories
    private int _cals = cals;
    public int Cals
    {
        //Return calories amount
        get => _cals;
        set
        {
            //Set calories amount and notify property changed
            _cals = value;
            OnPropertyChanged(nameof(Cals));
        }
    }
    
    //Property for serves
    private double _serves = serves;
    public double Serves
    {
        //Return serves amount
        get => _serves;
        set
        {
            //Set serves amount and notify property changed
            _serves = value;
            OnPropertyChanged(nameof(Serves));
        }
    }
    
    //Property for carbs
    private double _carbs = carbs;
    public double Carbs
    {
        //Return carbs amount
        get => _carbs;
        set
        {
            //Set carb amount and notify property changed
            _carbs = value;
            OnPropertyChanged(nameof(Carbs));
        }
    }
    
    //Property for protein
    private double _protein = protein;
    public double Protein
    {
        //Return protein amount
        get => _protein;
        set
        {
            //Set protein amount and notify property changed
            _protein = value;
            OnPropertyChanged(nameof(Protein));
        }
    }
    
    //Property for fat
    private double _fat = fat;
    public double Fat
    {
        //Return fat amount
        get => _fat;
        set
        {
            //Set fat amount and notify property changed
            _fat = value;
            OnPropertyChanged(nameof(Fat));
        }
    }

    public string MacrosDump()
    {
        var macrosDump = new StringBuilder();
        macrosDump.Append($"{Cals}:{Serves}:{Carbs}:{Protein}:{Fat}\n");
        return macrosDump.ToString();
    }
    
    //Invoke event, inform listeners that the supplied property value has changed
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
}