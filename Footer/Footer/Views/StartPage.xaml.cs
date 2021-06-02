using System;
using System.ComponentModel;
using Footer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Footer.Views
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            BindingContext = new LoginViewModel();
            InitializeComponent();
        }
    }
}