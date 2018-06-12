using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using DoggaLogg.MenuItems;
using DoggaLogg.View;

namespace DoggaLogg.Model
{
    public class MainPageMasterViewModel
    {
        public ObservableCollection<MasterPageItems> MenuItems { get; }

        public MainPageMasterViewModel()
        {
            MenuItems = new ObservableCollection<MasterPageItems>(new[]
            {
                new MasterPageItems{Title = "Home", TargetType = typeof(HomePage)},
                new MasterPageItems{Title = "Contact", TargetType = typeof(ContactPage)}
            });
        }
    }
}
