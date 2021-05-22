using Footer.Services;
using Footer.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Footer
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
