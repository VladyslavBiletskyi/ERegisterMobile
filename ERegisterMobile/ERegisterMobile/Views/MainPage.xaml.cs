using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERegisterMobile.Views;
using Xamarin.Forms;

namespace ERegisterMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Application.Current.Properties.Remove("IsLogedIn");
            if (!Application.Current.Properties.ContainsKey("IsLogedIn") ||
                String.IsNullOrEmpty((string) Application.Current.Properties["IsLogedIn"]))
            {
                SignInPage sip = new SignInPage(this);
                Navigation.PushModalAsync(sip, true);
            }
            else
            {
                MenuPage mp = new MenuPage();
                Navigation.PushAsync(mp);
                Navigation.RemovePage(this);
            }

        }
    }
}
