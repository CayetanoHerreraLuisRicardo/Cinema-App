using System;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using AppStudio.Services;
using AppStudio.ViewModels;

namespace AppStudio.Views
{
    public sealed partial class TOPCRITICASPRENSAList : Page
    {
        private NavigationHelper _navigationHelper;

        public TOPCRITICASPRENSAList()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            TOPCRITICASPRENSAModel = new TOPCRITICASPRENSAViewModel();

            SizeChanged += OnSizeChanged;
        }

        public TOPCRITICASPRENSAViewModel TOPCRITICASPRENSAModel { get; private set; }

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
            else
            {
                VisualStateManager.GoToState(this, "FullscreenView", true);
            }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedTo(e);
            await TOPCRITICASPRENSAModel.LoadItemsAsync();

            DataContext = this;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
        }
    }
}
