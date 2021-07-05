using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using ShellTemplate.Views;
using Command = MvvmHelpers.Commands.Command;
using Xamarin.CommunityToolkit;
using ShellTemplate.Services;
using ShellTemplate.Models;

namespace ShellTemplate.ViewModels
{
    public class LoginModel : ViewModelBase
    {
        private string useremail;
        private string userpass;
        private bool emailvalid;
        IDataService dataService;

        public string userEmail
        {
            get => useremail;
            set
            {
                SetProperty(ref useremail, value);
                OnPropertyChanged(nameof(LoginAllowed));
            }
        }

        public string userPass
        {
            get => userpass;
            set
            {
                SetProperty(ref userpass, value);
                OnPropertyChanged(nameof(LoginAllowed));
            }
        }

        public bool EmailValid
        {
            get => emailvalid;
            set
            {
                SetProperty(ref emailvalid, value);
                OnPropertyChanged(nameof(LoginAllowed));
            }
        }

        public AsyncCommand LoginCommand { get; }
        public AsyncCommand RegisterCommand { get; }

        public LoginModel()
        {
            //  Set Page Title
            Title = "Login";

            userEmail = "";
            userPass = "";

            LoginCommand = new AsyncCommand(DoLogin);
            RegisterCommand = new AsyncCommand(DoRegister);

            dataService = DependencyService.Get<IDataService>();
        }

        async Task DoLogin()
        {
            // Check if user is valid
            var uEmail = userEmail.ToString();
            var uPass = userPass.ToString();

            var result = await dataService.ValidateLogin(uEmail, uPass);

            if (result != null)
            {
                var uId = result.Id;

                //  Set user as Logged In
                Preferences.Set("LoggedIn", true);
                Preferences.Set("CurrentUser", uId);

                //  Navigate to Overview Page
                await Shell.Current.GoToAsync($"//{nameof(OverviewPage)}");
            }
            else
            {
                //  Login Failed
                await App.Current.MainPage.DisplayAlert("Error", "Login Failed", "OK");
                return;
            }            
        }

        async Task DoRegister()
        {
            //  Endure User is not currently logged in
            Preferences.Set("LoggedIn", false);
            
            //  Navigate to registration page
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}/{nameof(RegistrationPage)}");
        }

        
        public bool LoginAllowed => EmailValid && !string.IsNullOrEmpty(userpass);
    }
}
