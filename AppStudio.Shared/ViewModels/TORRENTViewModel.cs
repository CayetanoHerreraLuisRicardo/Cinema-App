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
    public class TORRENTViewModel : ViewModelBase<MenuSchema>
    {
        private RelayCommandEx<MenuSchema> itemClickCommand;
        public RelayCommandEx<MenuSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<MenuSchema>(
                        (item) =>
                        {
                            if (item.GetValue("Type").EqualNoCase("Section"))
                            {
                                NavigationServices.NavigateToPage(item.GetValue("Target"));
                                }
                                else
                                {
                                    var targetUri = TryCreateUri(item.GetValue("Target"));
                                    if (targetUri != null)
                                    {
                                        NavigationServices.NavigateTo(targetUri);
                                }
                            }
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
        override protected DataSourceBase<MenuSchema> CreateDataSource()
        {
            return new TORRENTDataSource(); // MenuDataSource
        }


        override public bool HasMoreItems
        {
            get { return false; }
        }

        override protected void NavigateToSelectedItem()
        {
            var currentItem = GetCurrentItem();
            if (currentItem != null)
            {
                if (currentItem.GetValue("Type").EqualNoCase("Section"))
                {
                    NavigationServices.NavigateToPage(currentItem.GetValue("Target"));
                }
                else
                {
                    NavigationServices.NavigateTo(new Uri(currentItem.GetValue("Target"), UriKind.Absolute));
                }
            }
        }
    }
}
