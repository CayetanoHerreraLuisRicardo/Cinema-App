using System;
using System.Net.NetworkInformation;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using AppStudio.Services;
using AppStudio.ViewModels;

namespace AppStudio.Views
{
    public sealed partial class CORTOMETRAJESPage : Page
    {
        private NavigationHelper _navigationHelper;

        public CORTOMETRAJESPage()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            CORTOMETRAJESModel = new CORTOMETRAJESViewModel();
            DataContext = this;

            SizeChanged += OnSizeChanged;
        }

        public CORTOMETRAJESViewModel CORTOMETRAJESModel { get; private set; }

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

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedTo(e);
            await CORTOMETRAJESModel.LoadItemsAsync();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
        }
    }
}
