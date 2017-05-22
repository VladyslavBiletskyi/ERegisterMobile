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
            if (!Application.Current.Properties.ContainsKey("token") ||
                String.IsNullOrEmpty((string) Application.Current.Properties["token"]))
            {
                SignInPage sip = new SignInPage();
                Navigation.PushModalAsync(sip);
                MessagingCenter.Subscribe<Page>(this, "User is logged in", OpenMenuPage);
            }
            else
            {
                OpenMenuPage(this);
            }
        }

        public void OpenMenuPage(Page page)
        {
            MenuPage mp = new MenuPage();
            Navigation.PushAsync(mp,true);
        }
    }
}
