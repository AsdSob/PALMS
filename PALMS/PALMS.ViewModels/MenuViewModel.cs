using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace PALMS.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private ObservableCollection<ISection> _items;
        private ISection _selectedItem;
        
        public ObservableCollection<ISection> Items
        {
            get { return _items; }
            set { Set(() => Items, ref _items, value); }
        }
        public ISection SelectedItem
        {
            get { return _selectedItem; }
            set { Set(() => SelectedItem, ref _selectedItem, value); }
        }

        public MenuViewModel()
        {
            Items = new ObservableCollection<ISection> {

                new ClientsSection { Name = "Client" },
                new MasterLinensSection { Name = "Master Linen" },

            };
        }

    }
}
