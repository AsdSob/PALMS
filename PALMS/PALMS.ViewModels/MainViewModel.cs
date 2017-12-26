using GalaSoft.MvvmLight;

namespace PALMS.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object _content;

        public object Content
        {
            get { return _content; }
            set { Set(() => Content, ref _content, value); }
        }

        public MainViewModel(DataViewModel content)
        {
            Content = content;
        }

        public MainViewModel(MenuViewModel content)
        {
            Content = content;
        }
    }
}
