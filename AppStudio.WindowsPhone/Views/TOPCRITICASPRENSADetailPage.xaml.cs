using AppStudio.Services;
using AppStudio.ViewModels;

using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AppStudio.Views
{
    public sealed partial class TOPCRITICASPRENSADetail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public TOPCRITICASPRENSADetail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            TOPCRITICASPRENSAModel = new TOPCRITICASPRENSAViewModel();
        }

        public TOPCRITICASPRENSAViewModel TOPCRITICASPRENSAModel { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            if (TOPCRITICASPRENSAModel != null)
            {
                await TOPCRITICASPRENSAModel.LoadItemsAsync();
                TOPCRITICASPRENSAModel.SelectItem(e.Parameter);

                TOPCRITICASPRENSAModel.ViewType = ViewTypes.Detail;
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
            if (TOPCRITICASPRENSAModel != null)
            {
                TOPCRITICASPRENSAModel.GetShareContent(args.Request);
            }
        }
    }
}
