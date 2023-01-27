using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//
using App_Compras.Vistas;

namespace App_Compras
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new Vistas.Compras());
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
