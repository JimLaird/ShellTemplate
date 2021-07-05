using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using System.Threading.Tasks;
using MvvmHelpers.Commands;
using Xamarin.Essentials;
using Xamarin.Forms;
using ShellTemplate.Helpers;
using Command = MvvmHelpers.Commands.Command;
using ShellTemplate.Models;
using ShellTemplate.Services;
using System.Diagnostics;

namespace ShellTemplate.ViewModels
{
    public class ProfileModel : ViewModelBase
    {
        private string username;
        private string useremail;
        private string userpass;
        private string userregdate;
        private string userimage;
        private string initials;
        private bool editmode;

        public AsyncCommand EditCommand { get; }
        public AsyncCommand SaveCommand { get; }
        public AsyncCommand CancelCommand { get; }
        public AsyncCommand SelectImageCommand { get; }
        public AsyncCommand TakeImageCommand { get; }

        IDataService dataService;

        public string userName
        {
            get => username;
            set
            {
                SetProperty(ref username, value);
                OnPropertyChanged();
            }
        }

        public string userEmail
        {
            get => useremail;
            set
            {
                SetProperty(ref useremail, value);
                OnPropertyChanged();
            }
        }

        public string userPass
        {
            get => userpass;
            set
            {
                SetProperty(ref userpass, value);
                OnPropertyChanged();
            }
        }

        public string userRegDate
        {
            get => userregdate;
            set
            {
                SetProperty(ref userregdate, value);
                OnPropertyChanged();
            }
        }

        public string userImage
        {
            get => userimage;
            set
            {
                SetProperty(ref userimage, value);
                OnPropertyChanged();
            }
        }

        public string Initials
        {
            get => initials;
            set
            {
                SetProperty(ref initials, value);
                OnPropertyChanged();
            }
        }

        public bool EditMode
        {
            get => editmode;
            set
            {
                SetProperty(ref editmode, value);
                OnPropertyChanged();
            }
        }

        public ProfileModel()
        {
            Title = "Profile";

            dataService = DependencyService.Get<IDataService>();
            EditCommand = new AsyncCommand(DoEdit);
            SaveCommand = new AsyncCommand(DoSave);
            CancelCommand = new AsyncCommand(DoCancel);
            SelectImageCommand = new AsyncCommand(SelectImage);
            TakeImageCommand = new AsyncCommand(TakeImage);

            GetCurrentUser();

            EditMode = false;
        }

        async Task SelectImage()
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick an image."
            });

            if (result != null)
            {
                string img1 = result.FullPath.ToString();
                userImage = img1;
            }
        }

        async Task TakeImage()
        {
            var result = await MediaPicker.CapturePhotoAsync();

            if (result != null)
            {
                string img1 = result.FullPath.ToString();
                userImage = img1;
            }
        }

        async Task DoEdit()
        {
            //  Toggle Edit Mode
            EditMode = true;
        }

        async Task DoSave()
        {
            //  Update the database
            EditMode = false;

            //  Get values
            int id = Preferences.Get("CurrentUser", 1);
            string email = userEmail;
            string password = userPass;
            string image = userImage;

            await dataService.UpdateUser(id,email,password,image);
        }

        async Task DoCancel()
        {
            //  Cancel Edit Mode
            EditMode = false;
        }
        async void GetCurrentUser()
        {
            var uId = Preferences.Get("CurrentUser", 1);
            var u = await dataService.GetUser(uId);

            if (u != null)
            {
                userEmail = u.Email;
                userImage = u.Image;
                userName = u.Name;
                userPass = u.Pass;
                userRegDate = u.RegDate;

                //  Call helper method to parse username and return initials
                Initials = userName.GetInitials();
            }
            else
            {
                return;
            }

        }

        
    }
}