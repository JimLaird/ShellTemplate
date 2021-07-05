using System;
using MonkeyCache.FileStore;
using ShellTemplate.Helpers;
using ShellTemplate.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellTemplate
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            TheTheme.SetTheme();
            Barrel.ApplicationId = AppInfo.PackageName;

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            OnResume();
        }

        protected override void OnSleep()
        {
            TheTheme.SetTheme();
            RequestedThemeChanged -= App_RequestedAppThemeChanged;
        }

        protected override void OnResume()
        {
            TheTheme.SetTheme();
            RequestedThemeChanged += App_RequestedAppThemeChanged;
        }

        private void App_RequestedAppThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                TheTheme.SetTheme();
            });
        }
    }
}
