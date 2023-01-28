using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//
using App_Compras.Vistas;
//transiciones
using Plugin.SharedTransitions;

namespace App_Compras
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new SharedTransitionNavigationPage(new Compras());
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
