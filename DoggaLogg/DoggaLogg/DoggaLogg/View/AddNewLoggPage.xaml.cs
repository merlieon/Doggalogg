using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DoggaLogg.Model;

namespace DoggaLogg.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddNewLoggPage : ContentPage
	{
		public AddNewLoggPage ()
		{
			InitializeComponent ();

            
		}

        async void Save_Clicked(object sender, EventArgs e)
        {
            
            
            var loggItem = new LoggItems() {
                LoggTitle = TitleEntry.Text,
                LoggText = TextEditor.Text,
                LoggCreated = DateTime.Now
                
            };
            await App.Database.SaveLoggAsync(loggItem);
            await Navigation.PopAsync();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await App.Database.GetProfileAsync();
        }
    }
}