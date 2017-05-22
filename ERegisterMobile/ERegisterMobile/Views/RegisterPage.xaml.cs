﻿using System;
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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            RegisterDate.MaximumDate = DateTime.Now.Date.AddDays(1);
        }

        public void GetRegister(DateTime date)
        {
            HttpClientEngine.AccessToken = Application.Current.Properties["token"]?.ToString();
            List<LessonViewModel> lessons;
            try
            {
                lessons =
                    (List<LessonViewModel>)HttpClientEngine.Get("api/Lessons/Register", typeof(List<LessonViewModel>));
                FillElements(lessons);
            }
            catch
            {
                DisplayAlert("Error!", "Error while filling debts", "Ok");
            }
        }
        private void FillElements(List<LessonViewModel> lessons)
        {
            Label header = new Label
            {
                Text = "Your register on "+RegisterDate.Date.Date,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            int i = 1;
            ListView listView = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = lessons,
                ItemTemplate = new DataTemplate(() =>
                {
                    Label elementNumberLabel = new Label
                    {
                        Text = "Mark №" + i++,
                        HorizontalOptions = LayoutOptions.Center,
                        TextColor = Color.Black
                    };
                    Label subjectLabel = new Label { Text = "Subject name" };
                    Label subjectName = new Label { TextColor = Color.Black };
                    subjectName.SetBinding(Label.TextProperty, "Subject");
                    Label myMarkLabel = new Label { Text = "My result on lesson" };
                    Label myMark = new Label { TextColor = Color.Black };
                    myMark.SetBinding(Label.TextProperty, "Result");
                    Label numberLabel = new Label { Text = "Number of present" };
                    Label numberOfPresent = new Label { TextColor = Color.Black };
                    numberOfPresent.SetBinding(Label.TextProperty, "NumberOfPresent");
                    Label averrageMarkLabel = new Label { Text = "Average mark on lesson" };
                    Label averageMark = new Label { TextColor = Color.Black };
                    averageMark.SetBinding(Label.TextProperty, "AverageMark");
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Vertical,
                            Children = {
                                elementNumberLabel,
                                subjectLabel,
                                subjectName,
                                numberLabel,
                                numberOfPresent,
                                averrageMarkLabel,
                                averageMark,
                                myMarkLabel,
                                myMark
                            }
                        }
                    };
                })
            };
            Content = new StackLayout { Children = { header, listView } };
        }

        private void RegisterDate_OnDateSelected(object sender, DateChangedEventArgs e)
        {
            GetRegister(RegisterDate.Date);
        }
    }
}
