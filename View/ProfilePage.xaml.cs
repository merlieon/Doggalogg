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
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
			InitializeComponent ();

            this.Title = "Profile";
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            LoggList.ItemsSource = await App.Database.GetLoggAsync();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new AddNewLoggPage() { BindingContext = new LoggItems() });
        }

        async void LoggList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushModalAsync(new LoggItemPage() { BindingContext = e.SelectedItem });
            }
        }
    }
}