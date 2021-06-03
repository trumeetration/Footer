using Footer.Views;
using System;
using Footer.Interfaces;
using Footer.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Footer
{
    public partial class App : Application
    {
        public static IUser CurrentUser;
        public App()
        {
            InitializeComponent();
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);
            MainPage = new StartPage();
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
    }
}
