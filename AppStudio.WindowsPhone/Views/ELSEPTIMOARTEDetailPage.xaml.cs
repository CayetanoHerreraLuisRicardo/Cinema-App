using AppStudio.Services;
using AppStudio.ViewModels;

using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AppStudio.Views
{
    public sealed partial class ELSEPTIMOARTEDetail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public ELSEPTIMOARTEDetail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            ELSEPTIMOARTEModel = new ELSEPTIMOARTEViewModel();
        }

        public ELSEPTIMOARTEViewModel ELSEPTIMOARTEModel { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            if (ELSEPTIMOARTEModel != null)
            {
                await ELSEPTIMOARTEModel.LoadItemsAsync();
                ELSEPTIMOARTEModel.SelectItem(e.Parameter);

                ELSEPTIMOARTEModel.ViewType = ViewTypes.Detail;
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
            if (ELSEPTIMOARTEModel != null)
            {
                ELSEPTIMOARTEModel.GetShareContent(args.Request);
            }
        }
    }
}
