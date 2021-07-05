using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShellTemplate.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var loggedIn = Preferences.Get("LoggedIn", false);

            //  If already logged in, go directly to overview page
            if (loggedIn)
            {
                await Shell.Current.GoToAsync($"//{nameof(OverviewPage)}");
            }

        }
    }
}