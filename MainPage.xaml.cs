namespace MauiApp1;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnOpenModalWithBugClicked(object sender, EventArgs e)
    {
        // Open modal WITH InputTransparent="True" (shows bug on Android)
        var bugDemoPage = new BugDemoPage();
        await Navigation.PushModalAsync(bugDemoPage, false);
    }

    private async void OnOpenModalWithoutBugClicked(object sender, EventArgs e)
    {
        // Open modal WITHOUT InputTransparent (works correctly)
        var fixedDemoPage = new BugDemoPage(removeInputTransparent: true);
        await Navigation.PushModalAsync(fixedDemoPage, false);
    }
}
