using Maui.ScopedLab.App.Services;
using Maui.ScopedLab.App.Views;

namespace Maui.ScopedLab.App
{
    public partial class MainPage : ContentPage
    {
        private readonly ICustomerService? _customerService;
        private readonly IServiceProvider? _serviceProvider;

        public MainPage(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this._serviceProvider = serviceProvider;
            this._customerService = this._serviceProvider?.GetService<ICustomerService>();

            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object? sender, EventArgs e)
        {
            this.WindowIdLabel.Text = this.Window.Id.ToString();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            this.CustomerServiceLabel.Text = $"Customer Service ID: {this._customerService?.GetIdentifier()}";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var mainPage = this._serviceProvider?.GetService<AppShell>();
            if (mainPage == null)
                return;

            var window = new Window(mainPage);
            Application.Current?.OpenWindow(window);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var mainPage = this._serviceProvider?.GetService<MainPage>();
            this.DisplayAlert("Message", $"My ID: {this.GetHashCode()} - Container MainPageId: {mainPage?.GetHashCode()}", "Close");
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            var myView = this._serviceProvider?.GetService<MyView>();
            Application.Current?.OpenWindow(new Window(new ContentPage() { Content = myView }));
        }
    }
}
