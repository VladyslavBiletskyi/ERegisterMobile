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
        private MainPage previous;
        public SignInPage(MainPage previous)
        {
            this.previous = previous;
            InitializeComponent();
        }

        public void SignIn()
        {
            if (SignInEmail.Text == "Vladyslav" && SignInPassword.Text == "Password")
            {
                Application.Current.Properties["IsLogedIn"] = "true";
                Application.Current.Properties["UserName"] = "Vladyslav Biletskyi";
                previous.Navigation.PushAsync(new MenuPage());
                previous.Navigation.PopModalAsync(true);
            }
            else
            {
                DisplayAlert("Error!", "Email or password is incorrect", "Ok");
            }
        }

        private void SignUpButton_Clicked(object sender, EventArgs e)
        {
            SignIn();
        }
    }
}
