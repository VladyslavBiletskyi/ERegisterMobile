using System;
using System.Collections.Generic;
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
            Application.Current.Properties["IsLogedIn"] = "true";
            Application.Current.Properties["UserName"] = "Vladyslav Biletskyi";
            var list = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("UserName", SignInEmail.Text),
                new KeyValuePair<string, string>("Password", SignInPassword.Text),
            };
            try
            {
                Dictionary<string, string> responce = (Dictionary<string, string>) (await HttpClientEngine.Token(list));
                if (responce.ContainsKey("access_token"))
                {
                    Resources.Add("token", responce["access_token"]);
                    HttpClientEngine.AccessToken = responce["access_token"];
                }
                else
                {
                    throw new Exception("Wrong email or password");
                }
            }
            catch
            {
                DisplayAlert("Error!", "Email or password is incorrect", "Ok");
            }
            MessagingCenter.Send<Page>(this, "User is logged in");
            Navigation.PopModalAsync(true);
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
