using System;
using System.Threading.Tasks;
using WpfApp1.Core;

namespace WpfApp1.MVVM.Model.SystemMethods
{
    class SomeItem : ObservableObject
    {
        public Func<Task> Action { get; set; }
        public string Title { get; set; }

        private bool _isChecked;
        public bool IsChecked
        {
            get => _isChecked; set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    OnPropertyChanged(nameof(IsChecked));
                }
            }
        }
    }
}
