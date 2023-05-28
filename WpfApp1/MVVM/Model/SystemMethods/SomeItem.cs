using System;
using System.Threading.Tasks;
using WpfApp1.Core;

namespace WpfApp1.MVVM.Model.SystemMethods
{
    class SomeItem : ObservableObject
    {
        public virtual Func<Task> Action { get; set; }
        public virtual string Title { get; set; }
        public virtual string ToolTip { get; set; }

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
