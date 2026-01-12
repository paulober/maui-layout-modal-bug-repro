namespace MauiApp1;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnOpenModalClicked(object sender, EventArgs e)
    {
        // Open as modal, which is how BadgeOverlayPage is opened
        var bugDemoPage = new BugDemoPage();
        await Navigation.PushModalAsync(bugDemoPage, false);
    }
}
