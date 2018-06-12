using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoggaLogg.Database;

using Xamarin.Forms;

namespace DoggaLogg
{
	public partial class App : Application
	{
        static ProfileDatabase database;

		public App ()
		{
			InitializeComponent();

			MainPage = new DoggaLogg.View.MainPage();
		}

        public static ProfileDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ProfileDatabase(DependencyService.Get<IFileHelper>().GetLocaLFilePath("Profile.db3"));
                }
                return database;
            }
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
