using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.NetworkInformation;

using Windows.UI.Xaml;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class MainViewModel : BindableBase
    {
       private SENSACINEViewModel _sENSACINEModel;
       private ELMULTICINEViewModel _eLMULTICINEModel;
       private REPORTAJEESTRENOCRITICAViewModel _rEPORTAJEESTRENOCRITICAModel;
       private HOYViewModel _hOYModel;
       private TORRENTViewModel _tORRENTModel;
       private CONTACTOViewModel _cONTACTOModel;
        private PrivacyViewModel _privacyModel;

        private ViewModelBase _selectedItem = null;

        public MainViewModel()
        {
            _selectedItem = SENSACINEModel;
            _privacyModel = new PrivacyViewModel();

        }
 
        public SENSACINEViewModel SENSACINEModel
        {
            get { return _sENSACINEModel ?? (_sENSACINEModel = new SENSACINEViewModel()); }
        }
 
        public ELMULTICINEViewModel ELMULTICINEModel
        {
            get { return _eLMULTICINEModel ?? (_eLMULTICINEModel = new ELMULTICINEViewModel()); }
        }
 
        public REPORTAJEESTRENOCRITICAViewModel REPORTAJEESTRENOCRITICAModel
        {
            get { return _rEPORTAJEESTRENOCRITICAModel ?? (_rEPORTAJEESTRENOCRITICAModel = new REPORTAJEESTRENOCRITICAViewModel()); }
        }
 
        public HOYViewModel HOYModel
        {
            get { return _hOYModel ?? (_hOYModel = new HOYViewModel()); }
        }
 
        public TORRENTViewModel TORRENTModel
        {
            get { return _tORRENTModel ?? (_tORRENTModel = new TORRENTViewModel()); }
        }
 
        public CONTACTOViewModel CONTACTOModel
        {
            get { return _cONTACTOModel ?? (_cONTACTOModel = new CONTACTOViewModel()); }
        }

        public void SetViewType(ViewTypes viewType)
        {
            SENSACINEModel.ViewType = viewType;
            ELMULTICINEModel.ViewType = viewType;
            REPORTAJEESTRENOCRITICAModel.ViewType = viewType;
            HOYModel.ViewType = viewType;
            TORRENTModel.ViewType = viewType;
            CONTACTOModel.ViewType = viewType;
        }

        public ViewModelBase SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
                UpdateAppBar();
            }
        }

        public Visibility AppBarVisibility
        {
            get
            {
                return SelectedItem == null ? AboutVisibility : SelectedItem.AppBarVisibility;
            }
        }

        public Visibility AboutVisibility
        {

      get { return Visibility.Collapsed; }
        }

        public void UpdateAppBar()
        {
            OnPropertyChanged("AppBarVisibility");
            OnPropertyChanged("AboutVisibility");
        }

        /// <summary>
        /// Load ViewModel items asynchronous
        /// </summary>
        public async Task LoadDataAsync(bool forceRefresh = false)
        {
            var loadTasks = new Task[]
            { 
                SENSACINEModel.LoadItemsAsync(forceRefresh),
                ELMULTICINEModel.LoadItemsAsync(forceRefresh),
                REPORTAJEESTRENOCRITICAModel.LoadItemsAsync(forceRefresh),
                HOYModel.LoadItemsAsync(forceRefresh),
                TORRENTModel.LoadItemsAsync(forceRefresh),
                CONTACTOModel.LoadItemsAsync(forceRefresh),
            };
            await Task.WhenAll(loadTasks);
        }

        //
        //  ViewModel command implementation
        //
        public ICommand RefreshCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await LoadDataAsync(true);
                });
            }
        }

        public ICommand AboutCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateToPage("AboutThisAppPage");
                });
            }
        }

        public ICommand PrivacyCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateTo(_privacyModel.Url);
                });
            }
        }
    }
}
