using System.Collections.Generic;
using System.Windows.Input;
using WpfApp1.Core;
using WpfApp1.MVVM.Model;

namespace WpfApp1.MVVM.View_Model
{
    class ConfidentionalViewModel : ObservableObject
    {
        private static readonly ConfidentionalModel _confModel = new();

        public ICommand SpyCommand { get; set; }
        public ICommand TelemetryCommand { get; set; }
        public ICommand DataCollectionCommand { get; set; }

        public List<SpyServicesItem> SpyList { get => _confModel.SpyList; }
        public List<TelemetryItem> TelemetryList { get => _confModel.TelemetryList; }
        public List<DataCollectionItem> DataCollectionList { get => _confModel.DataCollectionList; }

        public ConfidentionalViewModel()
        {
            SpyCommand = new RelayCommand(SpyServices);
            TelemetryCommand = new RelayCommand(AllTelemetry);
            DataCollectionCommand = new RelayCommand(DataCollection);
        }

        private void SpyServices(object obj)
        {
            _confModel.SpyServiceExecute();
        }
        private void AllTelemetry(object obj)
        {
            _confModel.AllTlemetryExecute();
        }
        private void DataCollection(object obj)
        {
            _confModel.DataCollectionExecute();
        }
    }
}
