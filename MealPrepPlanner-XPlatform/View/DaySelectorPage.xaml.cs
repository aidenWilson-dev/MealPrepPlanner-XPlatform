namespace MealPrepPlanner_XPlatform.View;

//Handles interaction logic for day selector page
public partial class DaySelectorPage : ContentPage
{
    //Amount of days selected to be skipped
    private int _daysSelected = 0;
    
    public DaySelectorPage()
    {
        InitializeComponent();
    }
    
    private void Button_OnClicked(object? sender, EventArgs e)
    {
        //If sender is null or not a button
        if (sender is not Button button) return;
        //If the button is already selected
        if (button.Text == "Skipped")
        {
            //Change bg colour, text colour, text and border width back to default
            button.Text = "Skip";
            button.BackgroundColor = Color.FromArgb("#73C526");
            button.TextColor = Colors.White;
            button.BorderWidth = 0;
            //Increment days selected
            _daysSelected -= 1;
            return;
        }
        //If button is not skipped
        //Change to skipped preset
        button.Text = "Skipped";
        button.BackgroundColor = Colors.Black;
        button.TextColor = Color.FromArgb("#87D93A");
        button.BorderWidth = 2;
        _daysSelected += 1;
    }

    private async void Close_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void Next_OnClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}