using System;
using System.Collections.Generic;
using Android.Content.Res;
using ERegisterMobile.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Application = Xamarin.Forms.Application;

namespace ERegisterMobile.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        public async void SignIn()
        {
            if (String.IsNullOrEmpty(SignInEmail.Text) || String.IsNullOrEmpty(SignInPassword.Text))
            {
                return;
            }
            var list = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("UserName", SignInEmail.Text),
                new KeyValuePair<string, string>("Password", SignInPassword.Text),
            };
            try
            {
                Dictionary<string, string> responce = (Dictionary<string, string>) (await HttpClientEngine.Token(list));
                Application.Current.Properties.Add("token", responce["access_token"]);
                HttpClientEngine.AccessToken = responce["access_token"];
                MessagingCenter.Send<Page>(this, "User is logged in");
                Navigation.PopModalAsync(true);
            }
            catch
            {
                DisplayAlert("Error!", "Email or password is incorrect", "Ok");
            }
        }

        private void SignInButton_Clicked(object sender, EventArgs e)
        {
            SignIn();
        }

        private void SignUpButton_Clicked(object sender, EventArgs e)
        {
            SignUpPage sup = new SignUpPage();
            Navigation.PushModalAsync(sup);
        }
    }
}
