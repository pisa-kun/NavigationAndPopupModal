using NavigationConverterAndPopupModal.ViewModels;
using System.Windows.Controls;

namespace NavigationConverterAndPopupModal.Views
{
    /// <summary>
    /// FirstView.xaml の相互作用ロジック
    /// </summary>
    public partial class FirstView : UserControl
    {
        public FirstView()
        {
            InitializeComponent();
            this.DataContext = new FirstViewModel();
        }
    }
}
