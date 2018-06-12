using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DoggaLogg.MenuItems;

namespace DoggaLogg.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : MasterDetailPage
	{
        
		public MainPage ()
		{
			InitializeComponent ();
            Detail = new NavigationPage(new HomePage());

            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
		}

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItems;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;
            Detail = new NavigationPage(page);
            MasterPage.ListView.SelectedItem = null;
            IsPresented = false;

        }
    }
}