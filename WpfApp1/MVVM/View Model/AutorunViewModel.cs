using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Core;
using WpfApp1.MVVM.Model;

namespace WpfApp1.MVVM.View_Model
{
    class AutorunViewModel : ObservableObject
    {
        public ICommand UninstallProgramsFromStartupCommand { get; set; } // Command to remove a parameter from a registry branch
        public ICommand AddProgramForRegCommand { get; set; } // Command to adding a parameter from a registry branch
        public List<AutoStartAppsModel> AutoStartApps { get; set; } // Get a collection of model class fields - checkbox, name, path
        private static readonly AutoStartAppsModel _autoStartApps = new();

        public string UserPath
        {
            get => _autoStartApps.UserPath;
            set
            {
                _autoStartApps.UserPath = value;
                OnPropertyChanged(nameof(UserPath));
            }
        }
        public string UserName
        {
            get => _autoStartApps.UserName;
            set
            {
                _autoStartApps.UserName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public AutorunViewModel()
        {
            AutoStartApps = new List<AutoStartAppsModel>(AutoStartAppsService.GetAutoStartApps()); // Loading data from registry branches

            UninstallProgramsFromStartupCommand = new RelayCommand(DeleteRegistrySetting); // When the button is clicked, this command executes the code to remove the registry setting
            AddProgramForRegCommand = new RelayCommand(AddRegistrySetting); // When the button is clicked, this command executes the code to add the registry setting
        }

        private async void DeleteRegistrySetting(object selectedItem)
        {
            await Task.Run(async () =>
            {
                foreach (var selectApps in AutoStartApps)
                    if (selectApps.IsChecked == true)
                        await AutoStartAppsService.DeleteParamsInRegistry(selectApps.Name);

                /// <summary>
                /// After deletion, we update the collection, report the change, then it reloads it, creating a new memory instance
                /// </summary>

                OnPropertyChanged(nameof(AutoStartApps));
                AutoStartApps = new List<AutoStartAppsModel>(AutoStartAppsService.GetAutoStartApps());
            });
        }

        private async void AddRegistrySetting(object selectedItem)
        {
            await Task.Run(async () =>
            {
                await AutoStartAppsService.AddParamsInRegistry(UserName, UserPath);

                /// <summary>
                /// After additiuon, we update the collection, report the change, then it reloads it, creating a new memory instance
                /// </summary>

                OnPropertyChanged(nameof(AutoStartApps));
                AutoStartApps = new List<AutoStartAppsModel>(AutoStartAppsService.GetAutoStartApps());
            });
        }
    }
}
