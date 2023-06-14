using System.Windows.Input;

namespace WorkoutTimers.App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("Settings", typeof(Views.Settings));
            Routing.RegisterRoute("NewRegularInterval", typeof(Views.NewRegularInterval));
            Routing.RegisterRoute("NewStaggeredInterval", typeof(Views.NewStaggeredInterval));

            NavigateToSettingsCommand = new Command(async () => {
                //await DisplayAlert("Menu Item", "Settings Selected", "OK");
                await GoToAsync("Settings", 
                    new Dictionary<string, object>
                    {
                        {"Message", "The Power of Navigation!" }
                    }
                    );
                this.FlyoutIsPresented = this.FlyoutBehavior != FlyoutBehavior.Flyout;

            });
            BindingContext = this;
        }

        public ICommand NavigateToSettingsCommand { get; private set; }

    }
}