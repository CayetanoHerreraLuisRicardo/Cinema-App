using System;
using System.Windows;
using System.Windows.Input;

using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Data;
using AppStudio.Services;

namespace AppStudio.ViewModels
{
    public class TodoCVCDViewModel : ViewModelBase<RssSchema>
    {
        private RelayCommandEx<RssSchema> itemClickCommand;
        public RelayCommandEx<RssSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<RssSchema>(
                        (item) =>
                        {
                            NavigationServices.NavigateToPage("TodoCVCDDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }


        private RelayCommandEx<string> changeFontSizeCommand;

        public RelayCommandEx<string> ChangeFontSizeCommand
        {
            get
            {
                if (changeFontSizeCommand == null)
                {
                    changeFontSizeCommand = new RelayCommandEx<string>((s) =>
                    {
                        FontSizes fontSize;
                        Enum.TryParse<FontSizes>(s, out fontSize);
                        DisplayFontSize = fontSize;
                    });
                }

                return changeFontSizeCommand;
            }
        }

        public FontSizes DisplayFontSize
        {
            get
            {
                if (ApplicationData.Current.LocalSettings.Values.ContainsKey(LocalSettingNames.TextViewerFontSizeSetting))
                {
                    FontSizes fontSizes;
                    Enum.TryParse<FontSizes>(ApplicationData.Current.LocalSettings.Values[LocalSettingNames.TextViewerFontSizeSetting].ToString(), out fontSizes);
                    return fontSizes;
                }
                return FontSizes.Normal;
            }
            set
            {
                ApplicationData.Current.LocalSettings.Values[LocalSettingNames.TextViewerFontSizeSetting] = value.ToString();
                this.OnPropertyChanged("DisplayFontSize");
            }
        }
        override protected DataSourceBase<RssSchema> CreateDataSource()
        {
            return new TodoCVCDDataSource(); // RssDataSource
        }


        override public Visibility GoToSourceVisibility
        {
            get { return ViewType == ViewTypes.Detail ? Visibility.Visible : Visibility.Collapsed; }
        }

        override protected void GoToSource()
        {
            base.GoToSource("{FeedUrl}");
        }

        override public Visibility RefreshVisibility
        {
            get { return ViewType == ViewTypes.List ? Visibility.Visible : Visibility.Collapsed; }
        }

        override public void NavigateToSectionList()
        {
            NavigationServices.NavigateToPage("TodoCVCDList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("TodoCVCDDetail");
        }
    }
}
