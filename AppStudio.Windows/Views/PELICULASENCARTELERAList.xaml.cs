using System;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using AppStudio.Services;
using AppStudio.ViewModels;

namespace AppStudio.Views
{
    public sealed partial class PELICULASENCARTELERAList : Page
    {
        private NavigationHelper _navigationHelper;

        public PELICULASENCARTELERAList()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            PELICULASENCARTELERAModel = new PELICULASENCARTELERAViewModel();

            SizeChanged += OnSizeChanged;
        }

        public PELICULASENCARTELERAViewModel PELICULASENCARTELERAModel { get; private set; }

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
            await PELICULASENCARTELERAModel.LoadItemsAsync();

            DataContext = this;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
        }
    }
}
