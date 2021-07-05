using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Command = MvvmHelpers.Commands.Command;
using ShellTemplate.Views;
using ShellTemplate.Services;

namespace ShellTemplate.ViewModels
{
    public class RegistrationModel : ViewModelBase
    {
        private string username;
        private string useremail;
        private string userpass;
        private string userregdate;
        private bool emailvalid;

        IDataService dataService;

        public string userName
        {
            get => username;
            set
            {
                SetProperty(ref username, value);
                OnPropertyChanged(nameof(RegisterAllowed));
            }
        }

        public string userEmail
        {
            get => useremail;
            set
            {
                SetProperty(ref useremail, value);
                OnPropertyChanged(nameof(RegisterAllowed));
            }
        }

        public string userPass
        {
            get => userpass;
            set
            {
                SetProperty(ref userpass, value);
                OnPropertyChanged(nameof(RegisterAllowed));
            }
        }

        public string userRegDate
        {
            get => userregdate;
            set
            {
                SetProperty(ref userregdate, value);
            }
        }

        public bool EmailValid
        {
            get => emailvalid;
            set
            {
                SetProperty(ref emailvalid, value);
                OnPropertyChanged(nameof(RegisterAllowed));
            }
        }

        public AsyncCommand CancelCommand { get; }
        public AsyncCommand RegisterCommand { get; }

        public RegistrationModel()
        {
            //  Set page title
            Title = "Register";

            userName = "";
            userEmail = "";
            userPass = "";
            userRegDate = DateTime.Today.ToString("dd/MM/yyyy");

            CancelCommand = new AsyncCommand (DoCancel);
            RegisterCommand = new AsyncCommand (DoRegister);

            dataService = DependencyService.Get<IDataService>();        }

        private async Task DoCancel()
        {
            //  Cancel registration
            Preferences.Set("LoggedIn", false);

            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        private async Task DoRegister()
        {
            var uEmail = userEmail.ToString();

            //  Check if user is already registered
            var result = await dataService.CheckUserExists(uEmail);

            if (result != null)
            {
                await App.Current.MainPage.DisplayAlert("Error", "A user with that email address already exists.", "OK");
                Preferences.Set("LoggedIn", false);
                Preferences.Remove("CurrentUser");

                //  Return user to the Login Page
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            else
            {
                await dataService.SaveUser(userName, userEmail, userPass, userRegDate);
                var uId = result.Id;
                //  Set user as Logged In
                Preferences.Set("LoggedIn", true);
                Preferences.Set("CurrentUser", uId);

                //  Go to main app page
                await Shell.Current.GoToAsync($"//{nameof(OverviewPage)}");
            }
        }

        public bool RegisterAllowed =>
            !string.IsNullOrEmpty(username) && EmailValid && !string.IsNullOrEmpty(userpass);
    }
}
