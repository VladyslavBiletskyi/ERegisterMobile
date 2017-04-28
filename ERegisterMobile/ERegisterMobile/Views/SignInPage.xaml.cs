using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERegisterMobile.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        public void SignIn()
        {
            if (SignInEmail.Text == "vladyslav.biletskyi@nure.ua" && SignInPassword.Text == "Password")
            {
                Application.Current.Properties["IsLogedIn"] = "true";
                Application.Current.Properties["UserName"] = "Vladyslav Biletskyi";
                MessagingCenter.Send<Page>(this, "User is logged in");
                Navigation.PopModalAsync(true);
            }
            else
            {
                DisplayAlert("Error!", "Email or password is incorrect", "Ok");
            }
        }

        private void SignInButton_Clicked(object sender, EventArgs e)
        {
            SignIn();
        }
    }
}
