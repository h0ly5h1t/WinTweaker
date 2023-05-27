using System.Collections.Generic;
using System.Windows.Input;
using WpfApp1.Core;
using WpfApp1.MVVM.Model;

namespace WpfApp1.MVVM.View_Model
{
    class InterfaceViewModel : ObservableObject
    {
        private static readonly InterfaceModel _interfaceModel = new();
        public List<ShortcutItem> ShortcutList { get => _interfaceModel.ShortcutList; }
        public List<GUIItem> GUIList { get => _interfaceModel.GUIList; }

        public bool FirstSulution { get; set; }

        public ICommand AddItemsShortcutCommand { get; set; }
        public ICommand AddGUICommand { get; set; }

        public InterfaceViewModel()
        {
            AddItemsShortcutCommand = new RelayCommand(AddItemsShortcutMenu);
            AddGUICommand = new RelayCommand(AddGUI);
        }
        private void AddItemsShortcutMenu(object obj)
        {
            _interfaceModel.AddItemsShortcutMenuExecute();
        }

        private async void AddGUI(object obj)
        {
            _interfaceModel.AddGUIExecute();
        }
    }
}
