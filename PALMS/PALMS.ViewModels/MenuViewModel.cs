using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        //public MenuViewModel()
        //{
        //    Items = new ObservableCollection<MenuItemViewModel> {

        //        new MenuItemViewModel { Name = "1" },
        //        new MenuItemViewModel { Name = "2" },
        //        new MenuItemViewModel { Name = "3" },

        //    };
        //}


        #region Test view changer

        
        private ViewModelBase _currentViewModel;

        readonly static ClientViewModel _clientViewModel = new ClientViewModel();
        readonly static MasterLinenViewModel _masterViewModel = new MasterLinenViewModel();
        
        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                if (_currentViewModel == value)
                    return;
                _currentViewModel = value;
                RaisePropertyChanged("Content");
            }
        }

      
        public ICommand MasterViewCommand { get; private set; }

        public ICommand ClientViewCommand { get; private set; }

       
        public MenuViewModel()
        {
            CurrentViewModel = MenuViewModel._masterViewModel;
            MasterViewCommand = new RelayCommand(() => ExecuteMasterViewCommand());
            ClientViewCommand = new RelayCommand(() => ExecuteClientViewCommand());
        }

        
        private void ExecuteMasterViewCommand()
        {
            CurrentViewModel = MenuViewModel._masterViewModel;
        }

        
        private void ExecuteClientViewCommand()
        {
            CurrentViewModel = MenuViewModel._clientViewModel;
        }

        #endregion

    }
}
