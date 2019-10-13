using Prism.Mvvm;

namespace NavigationConverterAndPopupModal.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "NavigationSample";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
