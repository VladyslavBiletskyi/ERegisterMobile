using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            FirstNameLabel.Text = Application.Current.Properties["UserName"]?.ToString().Split(' ')[0];
            LastNameLabel.Text = Application.Current.Properties["UserName"]?.ToString().Split(' ')[1];
            EmailLabel.Text = "vladyslav.biletskyi@nure.ua";
        }
    }
}
