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
    public partial class DebtsPage : ContentPage
    {
        public DebtsPage()
        {
            InitializeComponent();
            HttpClientEngine.AccessToken = Application.Current.Properties["token"]?.ToString();
            List<LessonViewModel> lessons;
            try
            {
                lessons =
                    (List<LessonViewModel>)HttpClientEngine.Get("api/Lessons/Debts", typeof(List<LessonViewModel>));
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
                Text = "Your debts",
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
                        Text = "Debt №" + i++,
                        HorizontalOptions = LayoutOptions.Center,
                        TextColor = Color.Black
                    };
                    Label subjectLabel = new Label { Text = "Subject name" };
                    Label subjectName = new Label { TextColor = Color.Black };
                    subjectName.SetBinding(Label.TextProperty, "Subject");
                    Label dateTimeLabel = new Label { Text = "Begining date and time of the lesson" };
                    Label beginingDateTime = new Label { TextColor = Color.Black };
                    beginingDateTime.SetBinding(Label.TextProperty, "BeginigDateTime");
                    Label numberLabel = new Label { Text = "Number of present" };
                    Label numberOfPresent = new Label { TextColor = Color.Black };
                    numberOfPresent.SetBinding(Label.TextProperty, "NumberOfPresent");
                    Label averrageMarkLabel = new Label { Text = "Average mark on lesson" };
                    Label averageMark = new Label { TextColor = Color.Black };
                    averageMark.SetBinding(Label.TextProperty, "AverageMark");
                    Label myMarkLabel = new Label { Text = "My result on lesson" };
                    Label myMark = new Label { TextColor = Color.Black };
                    myMark.SetBinding(Label.TextProperty, "Result");
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
                                dateTimeLabel,
                                beginingDateTime,
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
    }
}
