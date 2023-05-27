using System.Collections.Generic;
using System.Windows.Input;
using WpfApp1.Core;
using WpfApp1.MVVM.Model;

namespace WpfApp1.MVVM.View_Model
{
    class ServicesViewModel : ObservableObject
    {
        private static readonly ServicesModel _servicesModel = new();

        /// <summary>
        /// Properties for getting collections of elements and passing them to the View
        /// </summary>
        public List<WindowsDefenderItem> WinDefenderList { get => _servicesModel.WinDefenderList; }
        public List<WindowsUpdateCenterItem> WinUpdateList { get => _servicesModel.WinUpdateList; }
        public List<WindowsFirewallItem> WinFirewallList { get => _servicesModel.WinFirewall; }
        public List<BackgroundItem> BackgroundList { get => _servicesModel.BackgroundList; }
        public List<WindowsNotifCenterItem> WindowsNotifCenterList { get => _servicesModel.WindowsNotifCenterList; }
        public List<SysConfItem> SysConfList { get => _servicesModel.SysConfList; }

        /// <summary>
        /// Commands for On/Off Buttons
        /// </summary>
        public ICommand WindowsDefenderDisableCommand { get; set; }
        public ICommand WindowsDefenderEnableCommand { get; set; }
        public ICommand WindowsUpdateCenterDisableCommand { get; set; }
        public ICommand WindowsUpdateCenterEnableCommand { get; set; }
        public ICommand WindowsFirewallDisableCommand { get; set; }
        public ICommand WindowsFirewallEnableCommand { get; set; }
        public ICommand BackgroundAppDisableCommand { get; set; }
        public ICommand BackgroundAppEnableCommand { get; set; }
        public ICommand NotiCenterDisableCommand { get; set; }
        public ICommand NotiCenterEnableCommand { get; set; }
        public ICommand SysConfDisableCommand { get; set; }
        public ICommand SysConfEnableCommand { get; set; }

        public ServicesViewModel()
        {
            WindowsDefenderDisableCommand = new RelayCommand(DisableWinDefender);
            WindowsDefenderEnableCommand = new RelayCommand(EnableWinDefender);

            WindowsUpdateCenterDisableCommand = new RelayCommand(DisableWindowsUpdateCenter);
            WindowsUpdateCenterEnableCommand = new RelayCommand(EnableWindowsUpdateCenter);

            WindowsFirewallDisableCommand = new RelayCommand(DisableWindowsFirewall);
            WindowsFirewallEnableCommand = new RelayCommand(EnableWindowsFirewall);

            BackgroundAppDisableCommand = new RelayCommand(DisableBackgroundWork);
            BackgroundAppEnableCommand = new RelayCommand(EnableBackgroundWork);

            NotiCenterDisableCommand = new RelayCommand(DisableNotif);
            NotiCenterEnableCommand = new RelayCommand(EnableNotif);

            SysConfDisableCommand = new RelayCommand(DisableSysConf);
            SysConfEnableCommand = new RelayCommand(EnableSysConf);
        }

        private void DisableWinDefender(object obj)
        {
            _servicesModel.DisableWinDefenderExecute();
        }
        private void EnableWinDefender(object obj)
        {
            _servicesModel.EnableWinDefenderExecute();
        }
        private void DisableWindowsUpdateCenter(object obj)
        {
            _servicesModel.DisableUpdateCenterExecute();
        }
        private void EnableWindowsUpdateCenter(object obj)
        {
            _servicesModel.EnableUpdateCenterExecute();
        }
        private void DisableWindowsFirewall(object obj)
        {
            _servicesModel.DisableFirewallExecute();
        }
        private void EnableWindowsFirewall(object obj)
        {
            _servicesModel.EnableFirewallExecute();
        }
        private void DisableBackgroundWork(object obj)
        {
            _servicesModel.DisableBackgdroundWorkExecute();
        }
        private void EnableBackgroundWork(object obj)
        {
            _servicesModel.EnableBackgdroundWorkExecute();
        }
        private void DisableNotif(object obj)
        {
            _servicesModel.DisableNotificationsExecute();
        }
        private void EnableNotif(object obj)
        {
            _servicesModel.EnableNotificationsExecute();
        }
        private void DisableSysConf(object obj)
        {
            _servicesModel.DisableSysConfExecute();
        }
        private void EnableSysConf(object obj)
        {
            _servicesModel.EnableSysConfExecute();
        }
    }
}
