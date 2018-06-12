using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DoggaLogg.Model;
using DoggaLogg.MenuItems;

namespace DoggaLogg.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        
        public HomePage()
        {
            InitializeComponent();

            
            var toolbarItem = new ToolbarItem
            {
                Text = "+"
            };

            toolbarItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new AddNewProfilePage() { BindingContext = new ProfileItems() });
            };

            ToolbarItems.Add(toolbarItem);
            
            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            ProfileList.ItemsSource = await App.Database.GetProfileAsync();
        }

        async void ProfileList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushModalAsync(new NavigationPage(new ProfilePage()) { BindingContext = e.SelectedItem });
            }
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            var menuItem = BindingContext as ProfileItems;


            await App.Database.DeleteProfileAsync(menuItem);
        }
    }
}