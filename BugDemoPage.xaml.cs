namespace MauiApp1;

public partial class BugDemoPage : ContentPage
{
    public BugDemoPage()
    {
        InitializeComponent();
        
        // Simulate the animation setup from BadgeOverlayPage
        BackdropLayer.Opacity = 0;
        CardLayer.Opacity = 0;
        CardLayer.Scale = 0.8;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Animate in, similar to BadgeOverlayPage
        await Task.Delay(50);
        var backdropTask = BackdropLayer.FadeToAsync(1, 150);
        await Task.Delay(50);
        var cardFadeTask = CardLayer.FadeToAsync(1, 200);
        var cardScaleTask = CardLayer.ScaleToAsync(1, 200);
        await Task.WhenAll(backdropTask, cardFadeTask, cardScaleTask);
    }
}
