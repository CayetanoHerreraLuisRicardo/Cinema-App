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
    public class CONTACTOViewModel : ViewModelBase<CONTACTOSchema>
    {
        private RelayCommandEx<CONTACTOSchema> itemClickCommand;
        public RelayCommandEx<CONTACTOSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<CONTACTOSchema>(
                        (item) =>
                        {
                            NavigationServices.NavigateToPage("CONTACTODetail", item);
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
        override protected DataSourceBase<CONTACTOSchema> CreateDataSource()
        {
            return new CONTACTODataSource(); // CollectionDataSource
        }


        override public void NavigateToSectionList()
        {
            NavigationServices.NavigateToPage("CONTACTOList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("CONTACTODetail");
        }
    }
}
