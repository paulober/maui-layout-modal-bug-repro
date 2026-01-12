namespace MauiApp1;

public partial class BugDemoPage : ContentPage
{
    public BugDemoPage(bool removeInputTransparent = false)
    {
        InitializeComponent();
        
        // Option to remove InputTransparent for comparison
        if (removeInputTransparent)
        {
            CardLayer.InputTransparent = false;
            
            // Add TapGestureRecognizer to CardLayer for closing
            CardLayer.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await Navigation.PopModalAsync(false))
            });
        }
        else
        {
            // Add tap to backdrop for closing (when InputTransparent is true)
            BackdropLayer.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await Navigation.PopModalAsync(false))
            });
        }
        
        BackdropLayer.Opacity = 0;
        CardLayer.Opacity = 0;
        CardLayer.Scale = 0.8;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await Task.Delay(50);
        var backdropTask = BackdropLayer.FadeToAsync(1, 150);
        await Task.Delay(50);
        var cardFadeTask = CardLayer.FadeToAsync(1, 200);
        var cardScaleTask = CardLayer.ScaleToAsync(1, 200);
        await Task.WhenAll(backdropTask, cardFadeTask, cardScaleTask);
    }
}
