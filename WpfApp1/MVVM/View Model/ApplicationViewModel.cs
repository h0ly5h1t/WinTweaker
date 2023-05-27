using System.Collections.Generic;
using System.Windows.Input;
using WpfApp1.Core;
using WpfApp1.MVVM.Model;

namespace WpfApp1.MVVM.View_Model
{
    class ApplicationViewModel : ObservableObject
    {
        private static readonly ApplicationModel _appModel = new();
        public List<AppsItem> AppsList { get => _appModel.AppsList; }
        public ICommand DeleteAppsCommand { get; set; }

        public ApplicationViewModel()
        {
            DeleteAppsCommand = new RelayCommand(DeleteApps);
        }

        private void DeleteApps(object obj)
        {
            _appModel.DeleteAppExecute();
        }
    }
}
