using AppStudio.Services;
using AppStudio.ViewModels;

using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AppStudio.Views
{
    public sealed partial class TOPCRITICASESPECTADORESDetail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public TOPCRITICASESPECTADORESDetail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            TOPCRITICASESPECTADORESModel = new TOPCRITICASESPECTADORESViewModel();
        }

        public TOPCRITICASESPECTADORESViewModel TOPCRITICASESPECTADORESModel { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            if (TOPCRITICASESPECTADORESModel != null)
            {
                await TOPCRITICASESPECTADORESModel.LoadItemsAsync();
                TOPCRITICASESPECTADORESModel.SelectItem(e.Parameter);

                TOPCRITICASESPECTADORESModel.ViewType = ViewTypes.Detail;
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
            if (TOPCRITICASESPECTADORESModel != null)
            {
                TOPCRITICASESPECTADORESModel.GetShareContent(args.Request);
            }
        }
    }
}
