using AppStudio.Services;
using AppStudio.ViewModels;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AppStudio.Views
{
    public sealed partial class NOTICIASDELCINEDetail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public NOTICIASDELCINEDetail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            SizeChanged += OnSizeChanged;

            NOTICIASDELCINEModel = new NOTICIASDELCINEViewModel();
        }

        public NOTICIASDELCINEViewModel NOTICIASDELCINEModel { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width < 500)
            {
                VisualStateManager.GoToState(this, "SnappedView", true);
            }
            else if (e.NewSize.Width < e.NewSize.Height)
            {
                VisualStateManager.GoToState(this, "PortraitView", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "FullscreenView", true);
            }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            if (NOTICIASDELCINEModel != null)
            {
                await NOTICIASDELCINEModel.LoadItemsAsync();
                NOTICIASDELCINEModel.SelectItem(e.Parameter);

                NOTICIASDELCINEModel.ViewType = ViewTypes.Detail;
            }
            DataContext = this;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
            _dataTransferManager.DataRequested -= OnDataRequested;
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            if (NOTICIASDELCINEModel != null)
            {
                NOTICIASDELCINEModel.GetShareContent(args.Request);
            }
        }
    }
}
