using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using WpfApp1.Core;
using WpfApp1.MVVM.Model.SystemMethods;

namespace WpfApp1.MVVM.Model
{
    class ConfidentionalModel : ObservableObject
    {
        public List<SpyServicesItem> SpyList { get; set; } = new List<SpyServicesItem>(){
            new SpyServicesItem() { Action  = () => DisableTelemetry_Async(), Title="Disabling telemetry service", IsChecked = true},
            new SpyServicesItem() { Action  = () => DisableGeo_Async(), Title="Disabling the location service", IsChecked = true },
            new SpyServicesItem() { Action  = () => DisableEventCollector_Async(), Title="Disable System Event Collection", IsChecked = true },
            new SpyServicesItem() { Action  = () => DisableRemoteExp_Async(), Title="Disabling the possibility of remote experiments on the system", IsChecked = true },
        };
        public List<TelemetryItem> TelemetryList { get; set; } = new List<TelemetryItem>(){
            new TelemetryItem() { Action  = () => DisableAdIdentifier_Async(), Title="Disabling advertising user ID", IsChecked = true},
            new TelemetryItem() { Action  = () => DisableAllTelemetry_Async(), Title="Disabling all system telemetry", IsChecked = true },
            new TelemetryItem() { Action  = () => DisableNVIDIATelemetry_Async(), Title="Disabling NVIDIA telemetry", IsChecked = true },
            new TelemetryItem() { Action  = () => DisableVoiseSynt_Async(), Title="Disable system speech synthesis | Speech synthesis", IsChecked = true },
        };
        public List<DataCollectionItem> DataCollectionList { get; set; } = new List<DataCollectionItem>(){
            new DataCollectionItem() { Action  = () => DisableSheldueDataCollection_Async(), Title="Disable data collection via scheduler events", IsChecked = true},
            new DataCollectionItem() { Action  = () => DisableDataCollectionInstalledApp_Async(), Title="Disable collection of data about installed applications", IsChecked = true},
            new DataCollectionItem() { Action  = () => DisableDataCollectionUsedApp_Async(), Title="Disabling the collection of data about the applications used", IsChecked = true },
            new DataCollectionItem() { Action  = () => DisableWinSync_Async(), Title="Disabling all types of synchronization with Microsoft servers", IsChecked = true },
            new DataCollectionItem() { Action  = () => DisableHandWRDataCollection_Async(), Title="Disable handwriting data collection", IsChecked = true },
            new DataCollectionItem() { Action  = () => DisableDataCollectionUserBehavior_Async(), Title="Disable User Behavior Data Collection", IsChecked = true },
            new DataCollectionItem() { Action  = () => DisableHiddenMonitoringSystem_Async(), Title="Disabling hidden system monitoring", IsChecked = true },
            new DataCollectionItem() { Action  = () => DisableSystemLogging_Async(), Title="Disable system activity logging", IsChecked = true },
        };
        public async void SpyServiceExecute()
        {
            foreach (var item in SpyList)
            {
                if (item.IsChecked == true)
                {
                    await item.Action();
                    item.IsChecked = false;
                }
            }
        }
        public async void AllTlemetryExecute()
        {
            foreach (var item in TelemetryList)
            {
                if (item.IsChecked == true)
                {
                    await item.Action();
                    item.IsChecked = false;
                }
            }
        }
        public async void DataCollectionExecute()
        {
            foreach (var item in DataCollectionList)
            {
                if (item.IsChecked == true)
                {
                    await item.Action();
                    item.IsChecked = false;
                }
            }
        }

        #region Logic

        #region Telemetry
        private static async Task DisableAdIdentifier_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo");
                key.SetValue("Enabled", 0);

                using var key1 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\PolicyManager\current\device\Bluetooth");
                key1.SetValue("AllowAdvertising", 0);
            });
        }
        private static async Task DisableAllTelemetry_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\WMI\Autologger\Diagtrack-Listener");
                key.SetValue("Start", 0);

                using var key1 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Attachments");
                key1.SetValue("SaveZoneInformation", 1);

                using var key2 = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\DiagTrack");
                key2.SetValue("Start", 4);

                using var key3 = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\dmwappushservice");
                key3.SetValue("Start", 4);
            });

            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Office\\Office ClickToRun Service Monitor\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Office\\OfficeTelemetry\\AgentFallBack2016\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Office\\OfficeTelemetry\\AgentFallBack2016\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Office\\OfficeTelemetry\\OfficeTelemetryAgentLogOn2016\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Office\\OfficeTelemetryAgentFallBack2016\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Office\\OfficeTelemetryAgentLogOn2016\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Office\\OfficeTelemetryAgentFallBack\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Office\\OfficeTelemetryAgentLogOn\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Office\\Office 15 Subscription Heartbeat\" /disable");
        }
        private static async Task DisableVoiseSynt_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Speech");
                key.SetValue("AllowSpeechModelUpdate", 0);
            });
        }
        private static async Task DisableNVIDIATelemetry_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\NvTelemetryContainer");
                key.SetValue("Start", 4);
            });

            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn NvTmRepOnLogon_{B2FE1952-0186-46C3-BAEC-A80AA35AC5B8} /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn NvTmRep_{B2FE1952-0186-46C3-BAEC-A80AA35AC5B8} /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn NvTmMon_{B2FE1952-0186-46C3-BAEC-A80AA35AC5B8} /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("net stop NvTelemetryContainer");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("sc config NvTelemetryContainer start= disabled");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("sc stop NvTelemetryContainer");
        }
        private static async Task DisableTelemetry_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DataCollection");
                key.SetValue("AllowTelemetry", 0);
            });
            await Task.Run(() =>
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name='DiagTrack'");
                using var service = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

                SystemService.CloseService(service);
            });
            await Task.Run(() =>
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name='dmwappushservice'");
                using var service = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

                SystemService.CloseService(service);
            });
        }
        private static async Task DisableGeo_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\LocationAndSensors");
                key.SetValue("DisableLocation", 1);
                key.SetValue("DisableLocationScripting", 1);
                key.SetValue("DisableWindowsLocationProvider", 1);
            });
            await Task.Run(() =>
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name='lfsvc'");
                using var service = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

                SystemService.CloseService(service);
            });
        }
        private static async Task DisableRemoteExp_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\PolicyManager\current\device\System");
                key.SetValue("AllowExperimentation", 0);
            });
        }
        private static async Task DisableEventCollector_Async()
        {
            await Task.Run(() =>
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name='Wecsvc'");
                using var service = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

                SystemService.CloseService(service);
            });
        }
        #endregion
        #region DataCollection
        private static async Task DisableDataCollectionInstalledApp_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\AppCompat");
                key.SetValue("DisableInventory", 1);
            });
        }
        private static async Task DisableDataCollectionUsedApp_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\DataCollection");
                key.SetValue("AllowTelemetry", 0);

                using var key1 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\AppCompat");
                key1.SetValue("AITEnable", 0);

                using var key2 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DataCollection");
                key2.SetValue("AllowTelemetry", 0);

                using var key3 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced");
                key3.SetValue("Start_TrackProgs", 0);
            });
        }
        private static async Task DisableSheldueDataCollection_Async()
        {
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Windows\\Maintenance\\WinSAT\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Windows\\Autochk\\Proxy\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Windows\\Application Experience\\Microsoft Compatibility Appraiser\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Windows\\Application Experience\\ProgramDataUpdater\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Windows\\Application Experience\\StartupAppTask\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Windows\\PI\\Sqm-Tasks\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Windows\\NetTrace\\GatherNetworkInfo\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Windows\\Customer Experience Improvement Program\\Consolidator\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Windows\\Customer Experience Improvement Program\\KernelCeipTask\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Windows\\Customer Experience Improvement Program\\UsbCeip\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Windows\\DiskDiagnostic\\Microsoft-Windows-DiskDiagnosticResolver\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Windows\\DiskDiagnostic\\Microsoft-Windows-DiskDiagnosticDataCollector\" /disable");
        }
        private static async Task DisableWinSync_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\SettingSync\Groups\Accessibility");
                key.SetValue("Enabled", 0);

                using var key1 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\SettingSync\Groups\BrowserSettings");
                key1.SetValue("Enabled", 0);

                using var key2 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\SettingSync\Groups\BrowserSettings");
                key2.SetValue("Enabled", 0);

                using var key3 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\SettingSync\Groups\Language");
                key3.SetValue("Enabled", 0);

                using var key4 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\SettingSync\Groups\Personalization");
                key4.SetValue("Enabled", 0);

                using var key5 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\SettingSync\Groups\Windows");
                key5.SetValue("Enabled", 0);
            });
        }
        private static async Task DisableHandWRDataCollection_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\TabletPC");
                key.SetValue("PreventHandwritingDataSharing", 1);

                using var key1 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\HandwritingErrorReports");
                key1.SetValue("PreventHandwritingErrorReports", 1);

                using var key2 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Input\TIPC");
                key2.SetValue("Enabled", 0);
            });
        }
        private static async Task DisableDataCollectionUserBehavior_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\AppCompat");
                key.SetValue("DisableUAR", 1);

                using var key1 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\Personalization");
                key1.SetValue("NoLockScreenCamera", 1);
            });
        }
        private static async Task DisableSystemLogging_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\diagnosticshub.standardcollector.service");
                key.SetValue("Start", 4);
            });
        }
        private static async Task DisableHiddenMonitoringSystem_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\CDPUserSvc");
                key.SetValue("Start", 4);
            });
        }
        #endregion
        #endregion
    }
    class SpyServicesItem : SomeItem { }
    class TelemetryItem : SomeItem { }
    class DataCollectionItem : SomeItem { }
}
