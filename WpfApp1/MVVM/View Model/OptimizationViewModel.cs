using System.Collections.Generic;
using System.Windows.Input;
using WpfApp1.Core;
using WpfApp1.MVVM.Model;
using WpfApp1.MVVM.Model.SystemMethods;

namespace WpfApp1.MVVM.View_Model
{
    class OptimizationViewModel : ObservableObject
    {
        private static readonly OptimizationModel _optimizationModel = new();
        private static ProgressManager _progressManager = new();
        /// <summary>
        /// Fields for creating a collection, used only in it 
        /// </summary>
        public List<OptimizationItem> OptimizationList { get => _optimizationModel.OptimizationList; }
        public List<CleanItem> CleanList { get => _optimizationModel.CleanList; }

        public ICommand OptimizationSystemCommand { get; set; }
        public ICommand CleanCommand { get; set; }

        public bool IsProgress
        {
            get => _progressManager.IsProgress; 
            private set
            {
                _progressManager.IsProgress = value;
                OnPropertyChanged(nameof(IsProgress));
            }
        }
        public OptimizationViewModel()
        {
            OptimizationSystemCommand = new RelayCommand(OptimizationSystem);
            CleanCommand = new RelayCommand(CleanSystem);
        }

        private async void OptimizationSystem(object obj)
        {
            await _optimizationModel.OptimizationSystemExecute();
        }
        private async void CleanSystem(object obj)
        {
            IsProgress = true;
            await _optimizationModel.CleanSystemExecute();
            IsProgress = false;
        }
    }
}
