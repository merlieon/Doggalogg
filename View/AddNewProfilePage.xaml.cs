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
	public partial class AddNewProfilePage : ContentPage
	{
		public AddNewProfilePage ()
		{
			InitializeComponent ();
		}

        async void Save_Clicked(object sender, EventArgs e)
        {
            var additem = new ProfileItems
            {
                ProfileName = "Zelda",
                ProfileRace = "Kooiker"
            };

            var profileItem = (ProfileItems)BindingContext;
            await App.Database.SaveProfileAsync(profileItem);
            await Navigation.PopAsync(); 
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}