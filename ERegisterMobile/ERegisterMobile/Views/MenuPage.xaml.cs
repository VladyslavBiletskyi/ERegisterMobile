using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content.Res;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERegisterMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }
        private void ProfileButton_Clicked(object sender, EventArgs e)
        {
            ProfilePage profile = new ProfilePage();
            Navigation.PushModalAsync(profile);
        }

        private void AbsentsButton_OnClicked(object sender, EventArgs e)
        {
            AbsentsPage absents = new AbsentsPage();
            Navigation.PushModalAsync(absents);
        }

        private void DebtsButton_Clicked(object sender, EventArgs e)
        {
            DebtsPage debts = new DebtsPage();
            Navigation.PushModalAsync(debts);
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            RegisterPage register = new RegisterPage();
            Navigation.PushModalAsync(register);
        }

        private void SignOutButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties.Remove("IsLogedIn");
            Resources.Remove("token");
            Navigation.PushModalAsync(new SignInPage());
            Navigation.PopAsync();
        }
    }
}
