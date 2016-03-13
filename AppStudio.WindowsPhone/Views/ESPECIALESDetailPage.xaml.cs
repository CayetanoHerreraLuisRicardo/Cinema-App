using AppStudio.Services;
using AppStudio.ViewModels;

using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AppStudio.Views
{
    public sealed partial class ESPECIALESDetail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public ESPECIALESDetail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            ESPECIALESModel = new ESPECIALESViewModel();
        }

        public ESPECIALESViewModel ESPECIALESModel { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            if (ESPECIALESModel != null)
            {
                await ESPECIALESModel.LoadItemsAsync();
                ESPECIALESModel.SelectItem(e.Parameter);

                ESPECIALESModel.ViewType = ViewTypes.Detail;
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
            if (ESPECIALESModel != null)
            {
                ESPECIALESModel.GetShareContent(args.Request);
            }
        }
    }
}
