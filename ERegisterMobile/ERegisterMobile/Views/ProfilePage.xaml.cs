using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using ERegisterMobile.Models;
using ERegisterMobile.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERegisterMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            HttpClientEngine.AccessToken = Application.Current.Properties["token"]?.ToString();
            var model = (UserDetailsViewModel)HttpClientEngine.Get("api/Account/GetUserInfo", typeof(UserDetailsViewModel));
            FirstNameLabel.Text = model.FirstName;
            LastNameLabel.Text = model.LastName;
            GroupLabel.Text = model.Group;
        }
        public async void ChangePassword()
        {
            HttpClientEngine.AccessToken = Application.Current.Properties["token"]?.ToString();
            if (String.IsNullOrEmpty(OldPassword.Text)||
                String.IsNullOrEmpty(NewPassword.Text) ||
                String.IsNullOrEmpty(ConfirmPassword.Text))
            {
                DisplayAlert("Error!", "Fields must be filled", "Ok");
                return;
            }
            if (NewPassword.Text != ConfirmPassword.Text)
            {
                DisplayAlert("Error!", "Password and confirmition must be the same", "Ok");
            }
            try
            {
                ChangePasswordModel model = new ChangePasswordModel
                {
                    OldPassword = OldPassword.Text,
                    NewPassword = NewPassword.Text,
                    ConfirmPassword = ConfirmPassword.Text
                };
                await HttpClientEngine.Post("api/Account/ChangePassword", model);
                DisplayAlert("Success!", "Password completely changed", "Ok");
            }
            catch
            {
                DisplayAlert("Error!", "Error while changinp password. Check fields and try again", "Ok");
            }
        }

        private void ChangePasswordButton_Clicked(object sender, EventArgs e)
        {
            ChangePassword();
        }
    }
}
