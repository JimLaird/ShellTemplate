using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace ShellTemplate.ViewModels
{
    public class AboutModel : ViewModelBase 
    { 
        public AboutModel()
        {
            
            Title = "About";
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}