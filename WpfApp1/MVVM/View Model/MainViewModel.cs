using WpfApp1.Core;

namespace WpfApp1.MVVM.View_Model
{
    class MainViewModel : ObservableObject
    {
        private object _currentView;

        private ServicesViewModel ServicesVM { get; set; }
        private ConfidentionalViewModel ConfidentionalVM { get; set; }
        private OptimizationViewModel OptimizationVM { get; set; }
        private InterfaceViewModel InterfaceVM { get; set; }
        private ApplicationViewModel ApplicationVM { get; set; }
        private AutorunViewModel AutorunVM { get; set; }

        public RelayCommand ServicesViewCommand { get; set; }
        public RelayCommand ConfidentionalViewCommand { get; set; }
        public RelayCommand OptimizationViewCommand { get; set; }
        public RelayCommand InterfaceViewCommand { get; set; }
        public RelayCommand ApplicationViewCommand { get; set; }
        public RelayCommand AutorunViewCommand { get; set; }
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            ServicesVM = new ServicesViewModel();
            ConfidentionalVM = new ConfidentionalViewModel();
            OptimizationVM = new OptimizationViewModel();
            InterfaceVM = new InterfaceViewModel();
            ApplicationVM = new ApplicationViewModel();
            AutorunVM = new AutorunViewModel();

            CurrentView = ServicesVM;

            ServicesViewCommand = new RelayCommand(o => { CurrentView = ServicesVM; });
            ConfidentionalViewCommand = new RelayCommand(o => { CurrentView = ConfidentionalVM; });
            OptimizationViewCommand = new RelayCommand(o => { CurrentView = OptimizationVM; });
            InterfaceViewCommand = new RelayCommand(o => { CurrentView = InterfaceVM; });
            ApplicationViewCommand = new RelayCommand(o => { CurrentView = ApplicationVM; });
            AutorunViewCommand = new RelayCommand(o => { CurrentView = AutorunVM; });
        }
    }
}
