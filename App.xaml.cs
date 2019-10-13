using NavigationConverterAndPopupModal.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Windows;

namespace NavigationConverterAndPopupModal
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Container.Resolve<IRegionManager>().RequestNavigate("ContentRegion", nameof(FirstView));
        }

        /// <summary>
        /// Shellに張り付けるユーザーコントロールを登録
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainWindow>(nameof(MainWindow));
            containerRegistry.RegisterForNavigation<FirstView>(nameof(FirstView));
            containerRegistry.RegisterForNavigation<CallBackView>(nameof(CallBackView));
        }
    }
}
