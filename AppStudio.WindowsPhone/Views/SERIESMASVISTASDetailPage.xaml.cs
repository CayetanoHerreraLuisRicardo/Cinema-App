using AppStudio.Services;
using AppStudio.ViewModels;

using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AppStudio.Views
{
    public sealed partial class SERIESMASVISTASDetail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public SERIESMASVISTASDetail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            SERIESMASVISTASModel = new SERIESMASVISTASViewModel();
        }

        public SERIESMASVISTASViewModel SERIESMASVISTASModel { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            if (SERIESMASVISTASModel != null)
            {
                await SERIESMASVISTASModel.LoadItemsAsync();
                SERIESMASVISTASModel.SelectItem(e.Parameter);

                SERIESMASVISTASModel.ViewType = ViewTypes.Detail;
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
            if (SERIESMASVISTASModel != null)
            {
                SERIESMASVISTASModel.GetShareContent(args.Request);
            }
        }
    }
}
