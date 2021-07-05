using System;
using System.Collections.Generic;
using ShellTemplate.ViewModels;
using ShellTemplate.Views;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace ShellTemplate
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            //  Register Routes for pages not specifically referenced in AppShell.xaml
            Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
            
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Preferences.Set("LoggedIn", false);
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
