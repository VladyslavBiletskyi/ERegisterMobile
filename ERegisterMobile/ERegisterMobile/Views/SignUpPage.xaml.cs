using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERegisterMobile.Models;
using ERegisterMobile.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERegisterMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        private List<int> GroupIds;
        public SignUpPage()
        {
            InitializeComponent();
            var model = (List<GroupViewModel>)HttpClientEngine.Get("api/Groups/Get", typeof(List<GroupViewModel>));
            GroupIds = new List<int>();
            SignUpGroup.Items.Clear();
            foreach (var element in model)
            {
                SignUpGroup.Items.Add(element.Name);
                GroupIds.Add(element.Id);
            }
        }

        public async void SignUp()
        {
            if (String.IsNullOrEmpty(SignUpEmail.Text)|| 
                String.IsNullOrEmpty(SignUpPassword.Text)|| 
                String.IsNullOrEmpty(SignUpFirstName.Text)|| 
                String.IsNullOrEmpty(SignUpLastName.Text)||
                String.IsNullOrEmpty(SignUpPasswordConfirm.Text)||
                SignUpGroup.SelectedIndex==-1)
            {
                DisplayAlert("Error!", "Check your inputs", "Ok");
                return;
            }
            if (SignUpPassword.Text != SignUpPasswordConfirm.Text)
            {
                DisplayAlert("Error!", "Passwords must be the same", "Ok");
                return;
            }
            try
            {
                var model = new SignUpViewModel
                {
                    FirstName = SignUpFirstName.Text,
                    LastName = SignUpLastName.Text,
                    Email = SignUpEmail.Text,
                    Password = SignUpPassword.Text,
                    ConfirmPassword = SignUpPasswordConfirm.Text,
                    Group = GroupIds[SignUpGroup.SelectedIndex]
                };
                await HttpClientEngine.Post("api/Account/Register", model);
            }
            catch
            {
                DisplayAlert("Error!", "An error occured while signing up, check your fields and ty again", "Ok");
                return;
            }
            Navigation.PopModalAsync(true);
        }
        private void SignUpButton_Clicked(object sender, EventArgs e)
        {
            SignUp();
        }
    }
}
