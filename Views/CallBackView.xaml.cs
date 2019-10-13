using NavigationConverterAndPopupModal.ViewModels;
using System.Windows.Controls;

namespace NavigationConverterAndPopupModal.Views
{
    /// <summary>
    /// CallBackView.xaml の相互作用ロジック
    /// </summary>
    public partial class CallBackView : UserControl
    {
        public CallBackView()
        {
            InitializeComponent();
            this.DataContext = new CallBackViewModel();
        }
    }
}
