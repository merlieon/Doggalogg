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
        public AddNewLoggPage()
        {
            InitializeComponent();


        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            //I load the binding context
            var loggItem = (LoggItems)BindingContext;
            // Set the items properties
            loggItem.LoggTitle = TitleEntry.Text;
            loggItem.LoggText = TextEditor.Text;
            loggItem.LoggCreated = DateTime.Now;
            //Save to the database
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