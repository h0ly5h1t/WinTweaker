using System;

namespace WpfApp1.MVVM.Model.SystemMethods
{
    class ProgressManager
    {
        private bool _isProgress;
        public bool IsProgress
        {
            get => _isProgress;
            set
            {
                if (_isProgress != value)
                {
                    _isProgress = value;
                    OnProgressChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }
        private static event EventHandler OnProgressChanged;
    }
}
