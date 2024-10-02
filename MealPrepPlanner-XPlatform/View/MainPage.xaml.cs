namespace MealPrepPlanner_XPlatform.View;

//Handles interaction logic for main page
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        //Exit button is not needed on IOS, so if the platform is ios, hide it
        if (DeviceInfo.Platform == DevicePlatform.iOS)
        {
            Exit.IsVisible = false;
        }
    }

    //Event handler for exit button
    private void Exit_OnClicked(object? sender, EventArgs e)
    {
        //Close application
        Application.Current?.Quit(); 
    }

    //Event handler for recipe book button
    private async void RecipeBook_OnClicked(object? sender, EventArgs e)
    {
        //Navigate to recipe book page
        await Navigation.PushAsync(new RecipeBookPage());
    }
    
    //Event handler for meal planner button
    private async void MealPlanner_OnClicked(object? sender, EventArgs e)
    {
        //Navigate to recipe book page
        await Navigation.PushAsync(new DaySelectorPage());
    }
}