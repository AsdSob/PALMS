using GalaSoft.MvvmLight;

namespace PALMS.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object _content;
        private object _menuViewModel;

        public object Content
        {
            get { return _content; }
            set { Set(() => Content, ref _content, value); }
        }

        public object MenuViewModel
        {
            get { return _menuViewModel; }
            set { Set(() => MenuViewModel, ref _menuViewModel, value); }
        }

        public MainViewModel(DataViewModel content, MenuViewModel menu)
        {
            Content = content;
            MenuViewModel = menu;
        }
    }
}
