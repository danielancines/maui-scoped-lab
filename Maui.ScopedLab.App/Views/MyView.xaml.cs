namespace Maui.ScopedLab.App.Views;

public partial class MyView : ContentView
{
    private IServiceProvider _serviceProvider;

    public MyView(IServiceProvider serviceProvider)
	{
		InitializeComponent();

		this._serviceProvider = serviceProvider;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        var mainPage = this._serviceProvider?.GetService<MainPage>();
        mainPage?.DisplayAlert("Message", $"Alert from MyView - WindowId: {mainPage.Window.Id}", "Cancel", FlowDirection.LeftToRight);
    }
}