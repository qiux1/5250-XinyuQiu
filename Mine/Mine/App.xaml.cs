using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mine.Services;
using Mine.Views;

namespace Mine
{
    public partial class App : Application
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public App()
        {
            //initialize the application
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            DependencyService.Register<DatabaseService>();
            MainPage = new MainPage();
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
