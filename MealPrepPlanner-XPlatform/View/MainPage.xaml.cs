namespace MealPrepPlanner_XPlatform.View;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void Exit_OnClicked(object? sender, EventArgs e)
    {
        Application.Current?.Quit(); 
    }


    private void MealPlanner_OnClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private async void RecipeBook_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new RecipeBookPage());
    }
}