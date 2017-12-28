using System.Collections.ObjectModel;
using System.ComponentModel;
using GalaSoft.MvvmLight;
using Microsoft.Practices.ServiceLocation;

namespace PALMS.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object _content;
        private MenuViewModel _menuViewModel;

        public object Content
        {
            get { return _content; }
            set { Set(() => Content, ref _content, value); }
        }
        public MenuViewModel MenuViewModel
        {
            get { return _menuViewModel; }
            set { Set(() => MenuViewModel, ref _menuViewModel, value); }
        }

        public MainViewModel(DataViewModel content, MenuViewModel menu)
        {
            Content = content;
            MenuViewModel = menu;

            MenuViewModel.PropertyChanged += MenuPropertyChanged;
        }

        private void MenuPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var menuViewModel = sender as MenuViewModel;
            if (menuViewModel == null)
                return;

            if (e.PropertyName == nameof(MenuViewModel.SelectedItem))
            {
                if (menuViewModel.SelectedItem == null)
                    return;

                var contentType = menuViewModel.SelectedItem.GetType().BaseType?.GetGenericArguments()[0];

                Content = ServiceLocator.Current.GetInstance(contentType);
            }
        }
    }
}
