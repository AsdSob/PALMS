using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace PALMS.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private ObservableCollection<MenuItemViewModel> _items;
        private MenuItemViewModel _selectedItem;
        

        public ObservableCollection<MenuItemViewModel> Items
        {
            get { return _items; }
            set { Set(() => Items, ref _items, value); }
        }

        public MenuItemViewModel SelectedItem
        {
            get { return _selectedItem; }
            set { Set(() => SelectedItem, ref _selectedItem, value); }
        }

        public MenuViewModel()
        {
            Items = new ObservableCollection() {

                new MenuItemViewModel { Name = "1" },
                new MenuItemViewModel { Name = "2" },
                new MenuItemViewModel { Name = "3" },

            };
        }

    }
}
