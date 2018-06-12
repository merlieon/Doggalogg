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
	public partial class MainPageMaster : ContentPage
	{
        public ListView ListView => ListViewMenuItems;
		public MainPageMaster ()
		{
			InitializeComponent ();

            BindingContext = new MainPageMasterViewModel();
		}
	}
}