using System.ComponentModel;

namespace MealPrepPlanner_XPlatform.Model;

public class Step(int num, string step) : INotifyPropertyChanged
{
    //Property changed event
    public event PropertyChangedEventHandler? PropertyChanged;
    
    //Property for step number 
    private int _stepNum = num;
    public int StepNum
    {
        //Return ingredient name
        get => _stepNum;
        set
        {
            //Set ingredient name and notify property changed
            _stepNum = value;
            OnPropertyChanged(nameof(StepNum));
        }
    }
    
    //Property for step string
    private string _stepString = step;
    public string StepString
    {
        //Return ingredient name
        get => _stepString;
        set
        {
            //Set ingredient name and notify property changed
            _stepString = value;
            OnPropertyChanged(nameof(StepString));
        }
    }
    
    //Invoke event, inform listeners that the supplied property value has changed
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}