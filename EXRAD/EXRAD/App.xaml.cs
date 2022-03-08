using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EXRAD.Controllers;
using EXRAD.Views;
using System.IO;

namespace EXRAD
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DB.conexion(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DBPR.db3"));

            MainPage = new NavigationPage(new PageInicio());
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
