using NavigationConverterAndPopupModal.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace NavigationConverterAndPopupModal.ViewModels
{
    public class FirstViewModel : BindableBase, IConfirmNavigationRequest, IJournalAware, IRegionMemberLifetime
    {
        public bool KeepAlive => false;

        /// <summary>
        /// 次画面へ遷移するコマンド
        /// </summary>
        public DelegateCommand NextCommand { get; }

        /// <summary>
        /// モーダルとして表示するコマンド
        /// </summary>
        public DelegateCommand PopupModalCommand { get; }

        private IRegionNavigationService RegionNavigationService { get; set; }

        /// <summary>
        /// バインディング用の変数
        /// 最初は表示しないのでfalse
        /// </summary>
        private bool isImage = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FirstViewModel()
        {
            NextCommand = new DelegateCommand(() => RegionNavigationService.RequestNavigate(nameof(CallBackView)));
            PopupModalCommand = new DelegateCommand(() => PopupModalWindow());
        }

        /// <summary>
        /// モーダルウインドウを表示させる
        /// </summary>
        private void PopupModalWindow()
        {
            var win = new PopupModalWindow();
            win.ShowDialog(); // モーダルとして表示する
        }

        /// <summary>
        /// 変更通知を送る
        /// </summary>
        public bool IsImage
        {
            get => isImage;
            set => SetProperty(ref isImage, value);
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback) => continuationCallback(true);

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        /// <summary>
        /// この画面に遷移したときにパラメータを受け取っているか判定する
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters["TargetData"] != null)
            {
                // Camera画面から受け取ったパラメータを照合してバインドさせる
                IsImage = (bool)navigationContext.Parameters["TargetData"];
            }
            RegionNavigationService = navigationContext.NavigationService;
        }

        public bool PersistInHistory()
        {
            return true;
        }
    }
}
