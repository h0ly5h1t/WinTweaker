using System.Collections.Generic;
using System.Windows.Input;
using WpfApp1.Core;
using WpfApp1.MVVM.Model;
using WpfApp1.MVVM.Model.SystemMethods;

namespace WpfApp1.MVVM.View_Model
{
    class ApplicationViewModel : ObservableObject
    {
        private static readonly ApplicationModel _appModel = new();
        private static ProgressManager _progressManager = new();

        public List<AppsItem> AppsList { get => _appModel.AppsList; }
        public ICommand DeleteAppsCommand { get; set; }

        public ApplicationViewModel()
        {
            DeleteAppsCommand = new RelayCommand(DeleteApps);
        }

        public bool IsProgress
        {
            get => _progressManager.IsProgress; set
            {
                _progressManager.IsProgress = value;
                OnPropertyChanged(nameof(IsProgress));
            }
        }

        private async void DeleteApps(object obj)
        {
            IsProgress = true;
            await _appModel.DeleteAppExecute();
            IsProgress = false;
        }
    }
}
