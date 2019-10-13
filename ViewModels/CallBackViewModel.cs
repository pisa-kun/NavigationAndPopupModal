using NavigationConverterAndPopupModal.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace NavigationConverterAndPopupModal.ViewModels
{
    public class CallBackViewModel : BindableBase, IConfirmNavigationRequest, IJournalAware, IRegionMemberLifetime
    {
        public bool KeepAlive => false;

        public DelegateCommand BackCommand { get; }

        private IRegionNavigationService RegionNavigationService { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CallBackViewModel()
        {
            BackCommand = new DelegateCommand(() => NextButtonAction());
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback) => continuationCallback(true);

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            RegionNavigationService = navigationContext.NavigationService;
        }

        public bool PersistInHistory()
        {
            return true;
        }

        /// <summary>
        /// 遷移ボタンを押したときの処理。
        /// booleanを渡す
        /// </summary>
        private void NextButtonAction()
        {
            var param = new NavigationParameters();
            param.Add("TargetData", true); // パラメータをkeyとvalueの組み合わせで追加

            // 第二引数にパラメータを渡すと、viewが切り替わった先でパラメータを受け取る
            RegionNavigationService.RequestNavigate(nameof(FirstView), param);
        }
    }
}
