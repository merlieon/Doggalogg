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
            // I added this line to obtain the profile item in the bindingcontext
            ProfileItems profile = (ProfileItems)BindingContext;
            //Load the loggs
            var loggs = await App.Database.GetLoggAsync();
            //Load the loggs only where the profileId is in
            LoggList.ItemsSource = loggs.Where(x =>x.ProfileId == profile.Id);
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            //Same above 
            ProfileItems profile = (ProfileItems)BindingContext;
            //Send the profileId to the AddNewLoggPage to when I add a new logg item know what profile is
            await Navigation.PushAsync(new AddNewLoggPage() { BindingContext = new LoggItems() { ProfileId = profile.Id } });
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