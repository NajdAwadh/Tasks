using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace loginSystemApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
           
        }
        async void Button_Clicked(object sender, System.EventArgs e)
        {
            SignInButton.Text = "clicked";
            //string result = await DisplayPromptAsync("Question 1", "What's your name?");
            // count++;
            //((Button)sender).Text = $"You clicked {count} times.";
        }

        private void SignUpButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new signup());
        }
        private void SignUpPopup_Clicked(object sender, EventArgs e)
        {
            signUpPopup.IsVisible = true;
        }
    }

}
