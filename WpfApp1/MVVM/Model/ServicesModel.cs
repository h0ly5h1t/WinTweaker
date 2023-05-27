using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using WpfApp1.Core;
using WpfApp1.MVVM.Model.SystemMethods;

namespace WpfApp1.MVVM.Model
{
    class ServicesModel : ObservableObject
    {
        public List<WindowsDefenderItem> WinDefenderList { get; set; } = new List<WindowsDefenderItem>(){
            new WindowsDefenderItem() {Action  = () => DisableAntiSpyware_Async(), Title="Anti-spyware protection",ActionEnable  = () => EnableAntiSpyware_Async(),  IsChecked = false},
            new WindowsDefenderItem() {Action  = () => DisableRealTimeProtection_Async(),ActionEnable  = () => EnableRealTimeProtection_Async(),  Title="Real-time protection (RTP)", IsChecked = false },
            new WindowsDefenderItem() {Action  = () => DisableCloudProtection_Async(), ActionEnable  = () => EnableCloudProtection_Async(), Title="Cloud-delivered system protection", IsChecked = false },
            new WindowsDefenderItem() {Action  = () => DisableSmartScreen_Async(), ActionEnable  = () => EnableSmartScreen_Async(), Title="\"SmartScreen\" protection", IsChecked = false },
            new WindowsDefenderItem() {Action  = () => DisableServiceWindowsDefender_Async(), ActionEnable  = () => EnableServiceWindowsDefender_Async(), Title="Windows Defender service | \"wscsvc\" service", IsChecked = false },
        };
        public List<WindowsUpdateCenterItem> WinUpdateList { get; set; } = new List<WindowsUpdateCenterItem>(){
            new WindowsUpdateCenterItem() {Action  = () => DisableAutoUpdate_Async(), Title="Auto-Updates",ActionEnable  = () => EnableAutoUpdate_Async(),  IsChecked = true},
            new WindowsUpdateCenterItem() {Action  = () => DisableAbilityUpdates_Async(),ActionEnable  = () => EnableAbilityUpdates_Async(),  Title="Possibility of system updates, hard method | Update Center", IsChecked = true },
        };
        public List<WindowsFirewallItem> WinFirewall { get; set; } = new List<WindowsFirewallItem>(){
            new WindowsFirewallItem() {Action  = () => DisableWinFirewall_Async(), Title="Windows Firewall",ActionEnable  = () => EnableWinFirewall_Async(),  IsChecked = false},
            new WindowsFirewallItem() {Action  = () => DisableWinFirewallServ_Async(),ActionEnable  = () => EnableWinFirewallServ_Async(),  Title="Windows Firewall Service | \"mpssvc service\"", IsChecked = false },
        };
        public List<BackgroundItem> BackgroundList { get; set; } = new List<BackgroundItem>(){
            new BackgroundItem() {Action  = () => DisableAppBackgroundWork_Async(), Title="Background services | Background Work", ActionEnable  = () => EnableAppBackgroundWork_Async(),  IsChecked = true},
            new BackgroundItem() {Action  = () => DisableCortana_Async(),ActionEnable  = () => EnableCortana_Async(),  Title="Cortana Voice Assistant | Cortana", IsChecked = true },
            new BackgroundItem() {Action  = () => DisableSuperfetch_Async(), ActionEnable  = () => EnableSuperfetch_Async(), Title="Superfetch service | Superfetch", IsChecked = true },
            new BackgroundItem() {Action  = () => DisableWSearch_Async(), ActionEnable  = () => EnableWSearch_Async(), Title="System indexing | Windows Search", IsChecked = true },
            new BackgroundItem() {Action  = () => DisableSysmain_Async(), ActionEnable  = () => EnableSysmain_Async(), Title="SysMain service | SysMain", IsChecked = true },
        };
        public List<WindowsNotifCenterItem> WindowsNotifCenterList { get; set; } = new List<WindowsNotifCenterItem>(){
            new WindowsNotifCenterItem() {Action  = () => DisableNotifCenter_Async(), Title="Windows Notification Center (tray ico)", ActionEnable  = () => EnableNotifCenter_Async(),  IsChecked = true},
            new WindowsNotifCenterItem() {Action  = () => DisableNotif_Async(),ActionEnable  = () => EnableNotif_Async(),  Title="Possibility of notifications in the system", IsChecked = true },
            new WindowsNotifCenterItem() {Action  = () => DisableExeNotif_Async(), ActionEnable  = () => EnableExeNotif_Async(), Title="Notifications when launching .exe files", IsChecked = true },
            new WindowsNotifCenterItem() {Action  = () => DisableLiveApplication_Async(), ActionEnable  = () => EnableLiveApplication_Async(), Title="Notifications from Live Tiles | Live Applications", IsChecked = true },
        };
        public List<SysConfItem> SysConfList { get; set; } = new List<SysConfItem>(){
            new SysConfItem() {Action  = () => DisableUAC_Async(), Title="User Access Control | UAC",ActionEnable  = () => EnableUAC_Async(),  IsChecked = false},
            new SysConfItem() {Action  = () => DisableEXAutoRun_Async(),ActionEnable  = () => EnableEXAutoRun_Async(),  Title="Autorun of removable media | autorun.ini", IsChecked = true },
        };

        public async void DisableWinDefenderExecute()
        {
            foreach (var item in WinDefenderList)
            {
                if (item.IsChecked == true)
                {
                    await item.Action();
                    item.IsChecked = false;
                }
            }
        }
        public async void EnableWinDefenderExecute()
        {
            foreach (var item in WinDefenderList)
            {
                if (item.IsChecked == true)
                {
                    await item.ActionEnable();
                    item.IsChecked = false;
                }
            }
        }
        public async void DisableUpdateCenterExecute()
        {
            foreach (var item in WinUpdateList)
            {
                if (item.IsChecked == true)
                {
                    await item.Action();
                    item.IsChecked = false;
                }
            }
        }
        public async void EnableUpdateCenterExecute()
        {
            foreach (var item in WinUpdateList)
            {
                if (item.IsChecked == true)
                {
                    await item.ActionEnable();
                    item.IsChecked = false;
                }
            }
        }
        public async void DisableFirewallExecute()
        {
            foreach (var item in WinFirewall)
            {
                if (item.IsChecked == true)
                {
                    await item.Action();
                    item.IsChecked = false;
                }
            }
        }
        public async void EnableFirewallExecute()
        {
            foreach (var item in WinFirewall)
            {
                if (item.IsChecked == true)
                {
                    await item.ActionEnable();
                    item.IsChecked = false;
                }
            }
        }
        public async void DisableBackgdroundWorkExecute()
        {
            foreach (var item in BackgroundList)
            {
                if (item.IsChecked == true)
                {
                    await item.Action();
                    item.IsChecked = false;
                }
            }
        }
        public async void EnableBackgdroundWorkExecute()
        {
            foreach (var item in BackgroundList)
            {
                if (item.IsChecked == true)
                {
                    await item.ActionEnable();
                    item.IsChecked = false;
                }
            }
        }
        public async void DisableNotificationsExecute()
        {
            foreach (var item in WindowsNotifCenterList)
            {
                if (item.IsChecked == true)
                {
                    await item.Action();
                    item.IsChecked = false;
                }
            }
        }
        public async void EnableNotificationsExecute()
        {
            foreach (var item in WindowsNotifCenterList)
            {
                if (item.IsChecked == true)
                {
                    await item.ActionEnable();
                    item.IsChecked = false;
                }
            }
        }
        public async void DisableSysConfExecute()
        {
            foreach (var item in SysConfList)
            {
                if (item.IsChecked == true)
                {
                    await item.Action();
                    item.IsChecked = false;
                }
            }
        }
        public async void EnableSysConfExecute()
        {
            foreach (var item in SysConfList)
            {
                if (item.IsChecked == true)
                {
                    await item.ActionEnable();
                    item.IsChecked = false;
                }
            }
        }

        #region Logic
        #region WindowsDefender
        private static async Task DisableAntiSpyware_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender");
                key.SetValue("DisableAntiSpyware", 1);
                key.SetValue("AllowFastServiceStartup", 0);
                key.SetValue("ServiceKeepAlive", 0);
                key.SetValue("DisableAntiVirus", 1);
            });
        }
        private static async Task EnableAntiSpyware_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender");

                if (key?.GetValue("DisableAntiSpyware") != null)
                    key.DeleteValue("DisableAntiSpyware");
                if (key?.GetValue("AllowFastServiceStartup") != null)
                    key.DeleteValue("AllowFastServiceStartup");
                if (key?.GetValue("ServiceKeepAlive") != null)
                    key.DeleteValue("ServiceKeepAlive");
            });
        }
        private static async Task DisableRealTimeProtection_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection");

                key.SetValue("DisableIOAVProtection", 1);
                key.SetValue("DisableRealtimeMonitoring", 1);
                key.SetValue("DisableBehaviorMonitoring", 1);
                key.SetValue("DisableOnAccessProtection", 1);
                key.SetValue("DisableScanOnRealtimeEnable", 1);
            });
        }
        private static async Task EnableRealTimeProtection_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection");

                if (key?.GetValue("DisableIOAVProtection") != null)
                    key.DeleteValue("DisableIOAVProtection");
                if (key?.GetValue("DisableRealtimeMonitoring") != null)
                    key.DeleteValue("DisableRealtimeMonitoring");
                if (key?.GetValue("DisableBehaviorMonitoring") != null)
                    key.DeleteValue("DisableBehaviorMonitoring");
                if (key?.GetValue("DisableOnAccessProtection") != null)
                    key.DeleteValue("DisableOnAccessProtection");
                if (key?.GetValue("DisableScanOnRealtimeEnable") != null)
                    key.DeleteValue("DisableScanOnRealtimeEnable");
            });
        }
        private static async Task DisableCloudProtection_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Spynet");

                key.SetValue("DisableBlockAtFirstSeen", 1);
                key.SetValue("LocalSettingOverrideSpynetReporting", 0);
                key.SetValue("SubmitSamplesConsent", 2);
            });
        }
        private static async Task EnableCloudProtection_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Spynet");

                if (key?.GetValue("DisableBlockAtFirstSeen") != null)
                    key?.DeleteValue("DisableBlockAtFirstSeen");
                if (key?.GetValue("LocalSettingOverrideSpynetReporting") != null)
                    key?.DeleteValue("LocalSettingOverrideSpynetReporting");
                if (key?.GetValue("SubmitSamplesConsent") != null)
                    key?.DeleteValue("SubmitSamplesConsent");
            });
        }
        private static async Task DisableSmartScreen_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer");
                key.SetValue("SmartScreenEnabled", "off");

                using var key1 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\MicrosoftEdge\PhishingFilter");
                key1.SetValue("EnabledV9", 0);

                using var key2 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\System");
                key2.SetValue("EnableSmartScreen", 0);

                using var key3 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\SmartScreen");
                key3.SetValue("ConfigureAppInstallControl", "Anywhere");
                key3.SetValue("ConfigureAppInstallControlEnabled", 1);

                using var key4 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\AppHost");
                key4.SetValue("EnableWebContentEvaluation", 0);
            });
        }
        private static async Task EnableSmartScreen_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer");
                if (key?.GetValue("SmartScreenEnabled") != null)
                    key?.DeleteValue("SmartScreenEnabled");

                using var key1 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\MicrosoftEdge\PhishingFilter");
                if (key1?.GetValue("EnabledV9") != null)
                    key1?.DeleteValue("EnabledV9");

                using var key2 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\System");
                if (key2?.GetValue("EnableSmartScreen") != null)
                    key2?.DeleteValue("EnableSmartScreen");

                using var key3 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\SmartScreen");
                if (key3?.GetValue("ConfigureAppInstallControl") != null)
                    key3?.DeleteValue("ConfigureAppInstallControl");
                if (key3?.GetValue("ConfigureAppInstallControlEnabled") != null)
                    key3?.DeleteValue("ConfigureAppInstallControlEnabled");

                using var key4 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\AppHost");
                if (key4?.GetValue("EnableWebContentEvaluation") != null)
                    key4?.DeleteValue("EnableWebContentEvaluation");
            });
        }
        private static async Task DisableServiceWindowsDefender_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\SecurityHealthService");
                key.SetValue("Start", 4);

                using var key1 = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\wscsvc");
                key1.SetValue("Start", 4);

                using var key2 = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\Sense");
                key2.SetValue("Start", 4);

                //todo Данные ключи не применяются, нужны права системы. Разобраться
                //using var key3 = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\WdBoot");
                //key3.SetValue("Start", 4);

                //using var key4 = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\WdFilter");
                //key4.SetValue("Start", 4);

                //using var key5 = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\WdNisSvc");
                //key5.SetValue("Start", 4);

                //using var key6 = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\WinDefend");
                //key6.SetValue("Start", 4);
            });
            await Task.Run(() =>
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name='WinDefend'");
                using var service = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

                SystemService.CloseService(service);
            });
            await Task.Run(() =>
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name='WdNisSvc'");
                using var service = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

                SystemService.CloseService(service);
            });
            await Task.Run(() =>
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name='Sense'");
                using var service = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

                SystemService.CloseService(service);
            });
            await Task.Run(() =>
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name='SecurityHealthService'");
                using var service = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

                SystemService.CloseService(service);
            });
        }
        private static async Task EnableServiceWindowsDefender_Async() // todo допилить включение
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\SecurityHealthService");
                if (key?.GetValue("Start") != null)
                    key?.SetValue("Start", 3);

                using var key1 = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\wscsvc");
                if (key1?.GetValue("Start") != null)
                    key1?.SetValue("Start", 2);
            });
            await Task.Run(() =>
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name='WinDefend'");
                using var service = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

                SystemService.RunService(service);
            });
            await Task.Run(() =>
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name='WdNisSvc'");
                using var service = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

                SystemService.RunService(service);
            });
            await Task.Run(() =>
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name='Sense'");
                using var service = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

                SystemService.RunService(service);
            });
            await Task.Run(() =>
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name='SecurityHealthService'");
                using var service = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

                SystemService.RunService(service);
            });
        }
        #endregion
        #region UpdateCenter
        private static async Task DisableAutoUpdate_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU");
                key.SetValue("NoAutoUpdate", 1);
            });

            await CmdPowershell.RunCMDCommandAsAdmyn_Async(@"takeown /f c:\windows\system32\usoclient.exe /a");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async(@"reg add HKLM\SYSTEM\CurrentControlSet\Services\WaaSMedicSvc /v Start /t reg_dword /d 4 /f");

            await Task.Run(() =>
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name='wuauserv'");
                using var service = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

                SystemService.CloseService(service);
            });
        }
        private static async Task EnableAutoUpdate_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU");

                if (key?.GetValue("NoAutoUpdate") != null)
                    key.DeleteValue("NoAutoUpdate");

            });
            await CmdPowershell.RunCMDCommandAsAdmyn_Async(@"reg add HKLM\SYSTEM\CurrentControlSet\Services\WaaSMedicSvc /v Start /t reg_dword /d 4 /f");

            await Task.Run(() =>
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name='wuauserv'");
                using var service = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

                SystemService.RunService(service);
            });
        }
        private static async Task DisableAbilityUpdates_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate");

                key.SetValue("DoNotConnectToWindowsUpdateInternetLocations", 1);
                key.SetValue("UpdateServiceUrlAlternate", "loacal.wsus");
                key.SetValue("WUServer", "loacal.wsus");
                key.SetValue("WUStatusServer", "loacal.wsus");

                using var key1 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU");
                key1.SetValue("UseWUServer", 1);
            });
        }
        private static async Task EnableAbilityUpdates_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate");
                if (key?.GetValue("DoNotConnectToWindowsUpdateInternetLocations") != null)
                    key.DeleteValue("DoNotConnectToWindowsUpdateInternetLocations");
                if (key?.GetValue("UpdateServiceUrlAlternate") != null)
                    key.DeleteValue("UpdateServiceUrlAlternate");
                if (key?.GetValue("WUServer") != null)
                    key.DeleteValue("WUServer");
                if (key?.GetValue("WUStatusServer") != null)
                    key.DeleteValue("WUStatusServer");


                using var key1 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU");
                if (key1?.GetValue("UseWUServer") != null)
                    key1.DeleteValue("UseWUServer");
            });
        }
        #endregion
        #region WindowsFirewall
        private static async Task DisableWinFirewall_Async()
        {
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("netsh advfirewall set allprofiles state off");
        }
        private static async Task EnableWinFirewall_Async()
        {
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("netsh advfirewall set allprofiles state on");
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\SharedAccess\Defaults\FirewallPolicy");
                key.SetValue("Enable Firewall", 1);
            });
        }
        private static async Task DisableWinFirewallServ_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\mpssvc");
                key.SetValue("Start", 4);
            });
        }
        private static async Task EnableWinFirewallServ_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\mpssvc");
                key.SetValue("Start", 2);
            });
        }
        #endregion
        #region BackgroundWork
        private static async Task DisableAppBackgroundWork_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications");
                key.SetValue("GlobalUserDisabled", 1);

                using var key1 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Search");
                key1.SetValue("BackgroundAppGlobalToggle", 0);
            });
        }
        private static async Task EnableAppBackgroundWork_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications");
                if (key?.GetValue("GlobalUserDisabled") != null)
                    key.DeleteValue("GlobalUserDisabled");

                using var key1 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Search");
                if (key1?.GetValue("BackgroundAppGlobalToggle") != null)
                    key1.DeleteValue("BackgroundAppGlobalToggle");
            });

        }
        private static async Task DisableCortana_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\Windows Search");
                key.SetValue("AllowCortana", 0);
                key.SetValue("AllowCloudSearch", 0);
                key.SetValue("AllowSearchToUseLocation", 0);
                key.SetValue("ConnectedSearchUseWeb", 0);
                key.SetValue("DisableWebSearch", 1);

                using var key1 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows Search");
                key1.SetValue("AllowCortana", 0);

                using var key2 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Speech_OneCore\Preferences");
                key2.SetValue("ModelDownloadAllowed", 0);

                using var key3 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\InputPersonalization");
                key3.SetValue("RestrictImplicitInkCollection", 1);
                key3.SetValue("RestrictImplicitTextCollection", 1);

                using var key4 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\InputPersonalization");
                key4.SetValue("HarvestContacts", 0);

                using var key5 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Personalization\Settings");
                key5.SetValue("AcceptedPrivacyPolicy", 0);

                using var key6 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Windows Search");
                key6.SetValue("CortanaConsent", 0);
            });
        }
        private static async Task EnableCortana_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\Windows Search");
                if (key?.GetValue("AllowCortana") != null)
                    key.DeleteValue("AllowCortana");
                if (key?.GetValue("AllowCloudSearch") != null)
                    key.DeleteValue("AllowCloudSearch");
                if (key?.GetValue("AllowSearchToUseLocation") != null)
                    key.DeleteValue("AllowSearchToUseLocation");
                if (key?.GetValue("ConnectedSearchUseWeb") != null)
                    key.DeleteValue("ConnectedSearchUseWeb");
                if (key?.GetValue("DisableWebSearch") != null)
                    key.DeleteValue("DisableWebSearch");

                using var key1 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows Search");
                if (key1?.GetValue("AllowCortana") != null)
                    key1.DeleteValue("AllowCortana");

                using var key2 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Speech_OneCore\Preferences");
                if (key2?.GetValue("ModelDownloadAllowed") != null)
                    key2.DeleteValue("ModelDownloadAllowed");

                using var key3 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\InputPersonalization");
                if (key3?.GetValue("RestrictImplicitInkCollection") != null)
                    key3.DeleteValue("RestrictImplicitInkCollection");
                if (key3?.GetValue("RestrictImplicitTextCollection") != null)
                    key3.DeleteValue("RestrictImplicitTextCollection");

                using var key4 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\InputPersonalization");
                if (key4?.GetValue("HarvestContacts") != null)
                    key4.DeleteValue("HarvestContacts");

                using var key5 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Personalization\Settings");
                if (key5?.GetValue("AcceptedPrivacyPolicy") != null)
                    key5.DeleteValue("AcceptedPrivacyPolicy");

                using var key6 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Windows Search");
                if (key6?.GetValue("CortanaConsent") != null)
                    key6.DeleteValue("CortanaConsent");
            });
        }
        private static async Task DisableSuperfetch_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters");
                key.SetValue("EnablePrefetcher", 0);
            });
        }
        private static async Task EnableSuperfetch_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters");
                key.SetValue("EnablePrefetcher", 3);
            });

        }
        private static async Task DisableWSearch_Async()
        {
            await Task.Run(() =>
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name='WSearch'");
                using var service = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

                SystemService.CloseService(service);
            });
        }
        private static async Task EnableWSearch_Async()
        {
            await Task.Run(() =>
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name='WSearch'");
                using var service = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

                SystemService.RunService(service);
            });
        }
        private static async Task DisableSysmain_Async()
        {
            await Task.Run(() =>
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name='SysMain'");
                using var service = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

                SystemService.CloseService(service);
            });
        }
        private static async Task EnableSysmain_Async()
        {
            await Task.Run(() =>
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name='SysMain'");
                using var service = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

                SystemService.RunService(service);
            });
        }
        #endregion
        #region WindowsNotifCenter
        private static async Task DisableNotifCenter_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.CurrentUser.CreateSubKey(@"Software\Policies\Microsoft\Windows\Explorer");
                key.SetValue("DisableNotificationCenter", 1);
            });
        }
        private static async Task EnableNotifCenter_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.CurrentUser.CreateSubKey(@"Software\Policies\Microsoft\Windows\Explorer");
                if (key?.GetValue("DisableNotificationCenter") != null)
                    key?.DeleteValue("DisableAutoplay");
            });
        }
        private static async Task DisableNotif_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\PushNotifications");
                key.SetValue("ToastEnabled", 0);
            });
        }
        private static async Task EnableNotif_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\PushNotifications");
                if (key?.GetValue("ToastEnabled") != null)
                    key?.DeleteValue("ToastEnabled");
            });
        }
        private static async Task DisableExeNotif_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Security");
                key.SetValue("DisableSecuritySettingsCheck", 1);

                using var key1 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\3");
                key1.SetValue("1806", 0);
            });
        }
        private static async Task EnableExeNotif_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Security");
                if (key?.GetValue("DisableSecuritySettingsCheck") != null)
                    key?.DeleteValue("DisableSecuritySettingsCheck");

                using var key1 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\3");
                if (key1?.GetValue("1806") != null)
                    key1?.DeleteValue("1806");
            });
        }
        private static async Task DisableLiveApplication_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.CurrentUser.CreateSubKey(@"Software\Policies\Microsoft\Windows\CurrentVersion\PushNotifications");
                key.SetValue("NoTileApplicationNotification", 1);

                using var key1 = Registry.CurrentUser.CreateSubKey(@"Software\Policies\Microsoft\Windows\Explorer");
                key1.SetValue("ClearTilesOnExit", 1);
            });
        }
        private static async Task EnableLiveApplication_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.CurrentUser.CreateSubKey(@"Software\Policies\Microsoft\Windows\CurrentVersion\PushNotifications");
                if (key?.GetValue("NoTileApplicationNotification") != null)
                    key?.DeleteValue("NoTileApplicationNotification");

                using var key1 = Registry.CurrentUser.CreateSubKey(@"Software\Policies\Microsoft\Windows\Explorer");
                if (key?.GetValue("ClearTilesOnExit") != null)
                    key?.DeleteValue("ClearTilesOnExit");
            });
        }
        #endregion
        #region SysConf
        private static async Task DisableUAC_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
                key.SetValue("ConsentPromptBehaviorAdmin", 0);
                key.SetValue("EnableInstallerDetection", 0);
                key.SetValue("EnableLUA", 0);
                key.SetValue("EnableSecureUIAPaths", 0);
                key.SetValue("EnableVirtualization", 0);
                key.SetValue("FilterAdministratorToken", 0);
                key.SetValue("PromptOnSecureDesktop", 0);
            });
        }
        private static async Task EnableUAC_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
                key.SetValue("ConsentPromptBehaviorAdmin", 5);
                key.SetValue("EnableInstallerDetection", 1);
                key.SetValue("EnableLUA", 1);
                key.SetValue("EnableVirtualization", 1);
                key.SetValue("PromptOnSecureDesktop", 1);
                if (key?.GetValue("FilterAdministratorToken") != null)
                    key?.DeleteValue("FilterAdministratorToken");
            });
        }
        private static async Task DisableEXAutoRun_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\AutoplayHandlers");
                key.SetValue("DisableAutoplay", 1);
            });
        }
        private static async Task EnableEXAutoRun_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\AutoplayHandlers");
                key.SetValue("DisableAutoplay", 0);
            });
        }
        #endregion
        #endregion
    }

    class WindowsDefenderItem : SomeItem
    {
        public Func<Task> ActionEnable { get; set; }
    }
    class WindowsUpdateCenterItem : SomeItem
    {
        public Func<Task> ActionEnable { get; set; }
    }
    class WindowsFirewallItem : SomeItem
    {
        public Func<Task> ActionEnable { get; set; }
    }
    class BackgroundItem : SomeItem
    {
        public Func<Task> ActionEnable { get; set; }
    }
    class WindowsNotifCenterItem : SomeItem
    {
        public Func<Task> ActionEnable { get; set; }
    }
    class SysConfItem : SomeItem
    {
        public Func<Task> ActionEnable { get; set; }
    }
}
