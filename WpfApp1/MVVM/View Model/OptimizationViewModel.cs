using System.Collections.Generic;
using System.Windows.Input;
using WpfApp1.Core;
using WpfApp1.MVVM.Model;

namespace WpfApp1.MVVM.View_Model
{
    class OptimizationViewModel : ObservableObject
    {
        private static readonly OptimizationModel _optimizationModel = new();
        public List<OptimizationItem> OptimizationList { get => _optimizationModel.OptimizationList; } 
        public ICommand OptimizationSystemCommand { get; set; }

        public OptimizationViewModel()
        {
            OptimizationSystemCommand = new RelayCommand(OptimizationSystem);
        }
        private async void OptimizationSystem(object obj)
        {
              _optimizationModel.OptimizationSystemExecute();
        }
    }
}
