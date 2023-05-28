using Microsoft.Win32;
using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp1.Core;
using WpfApp1.MVVM.Model.SystemMethods;

namespace WpfApp1.MVVM.Model
{
    class OptimizationModel : ObservableObject
    {
        public List<OptimizationItem> OptimizationList { get; set; } = new List<OptimizationItem>(){
            new OptimizationItem() { Action  = () => DisableMemDyag_Async(), Title="Disable a memory diagnostics | MemDyag", IsChecked = true},
            new OptimizationItem() { Action  = () => CasheUp_Async(), Title="Increasing the file system cache (more than 4 GB of RAM)", IsChecked = true },
            new OptimizationItem() { Action  = () => FastBootUp_Async(), Title="Speed up system startup by disabling program startup delay", IsChecked = true },
        };
        public List<CleanItem> CleanList { get; set; } = new List<CleanItem>(){
            new CleanItem() { Action  = () => CleanWinSxS(), Title="Storage cleanup (WinSxS) from system files and updates | WinSxS", IsChecked = false},
            new CleanItem() { Action  = () => CleanOldUpdates(), Title="Storage cleanup (WinSxS) from old updates & components | WinSxS", IsChecked = false,
                ToolTip="Optimization of the component store and removal of old versions of components left after installing Windows updates."},
            new CleanItem() { Action  = () => CompressionWinSxS(), Title="Storage compression (WinSxS) from system files and updates | WinSxS", IsChecked = false,
                ToolTip="Compressing files in the WinSxS folder is a way to reduce the size of the WinSxS directory by enabling NTFS compression."},
        };

        public List<string> ToolTip { get; set; } = new List<string>()
        {
            new string(""),
            new string(""),
            new string(""),
        };

        public async Task OptimizationSystemExecute()
        {
            foreach (var item in OptimizationList)
            {
                if (item.IsChecked == true)
                {
                    await item.Action();
                    item.IsChecked = false;
                }
            }
        }
        public async Task CleanSystemExecute()
        {
            foreach (var item in CleanList)
            {
                if (item.IsChecked == true)
                {
                    await item.Action();
                    item.IsChecked = false;
                }
            }
        }

        #region Logic
        public async static Task DisableMemDyag_Async()
        {
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Windows\\MemoryDiagnostic\\CorruptionDetector\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Windows\\MemoryDiagnostic\\DecompressionFailureDetector\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Windows\\MemoryDiagnostic\\ProcessMemoryDiagnosticEvents\" /disable");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("schtasks /change /tn \"Microsoft\\Windows\\MemoryDiagnostic\\RunFullMemoryDiagnostic\" /disable");
        }
        public async static Task CasheUp_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management");
                key.SetValue("LargeSystemCache", 1);
            });
        }
        public async static Task FastBootUp_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Serialize");
                key.SetValue("Startupdelayinmsec", 0);
            });
        }
        #endregion  
        public async static Task CleanWinSxS()
        {
            await Task.Run(async () =>
            {
                await CmdPowershell.RunCMDCommandAsAdmyn_Async("Dism.exe /online /cleanup-image /StartComponentCleanup");
            });
        }
        public async static Task CleanOldUpdates()
        {
            await Task.Run(async () =>
            {
                await CmdPowershell.RunCMDCommandAsAdmyn_Async("Dism.exe /Online /Cleanup-Image /StartComponentCleanup /ResetBase &&  schtasks.exe /Run /TN \"\\Microsoft\\Windows\\Servicing\\StartComponentCleanup\" ");
            });
        }
        public async static Task CompressionWinSxS()
        {
            await Task.Run(async () =>
            {
                await CmdPowershell.RunCMDCommandAsAdmyn_Async("sc stop msiserver && sc stop TrustedInstaller && sc config msiserver start= disabled && sc config TrustedInstaller start= disabled");
                await CmdPowershell.RunCMDCommandAsAdmyn_Async("icacls \"%WINDIR%\\WinSxS\" /save \"%WINDIR%\\WinSxS_NTFS.acl\" /t && takeown /f \"%WINDIR%\\WinSxS\" /r && icacls \"%WINDIR%\\WinSxS\" /grant \"%USERDOMAIN%\\%USERNAME%\":(F) /t");
                await CmdPowershell.RunCMDCommandAsAdmyn_Async("compact /s:\"%WINDIR%\\WinSxS\" /c /a /i *");
                await CmdPowershell.RunCMDCommandAsAdmyn_Async("icacls \"%WINDIR%\\WinSxS\" /setowner \"NT SERVICE\\TrustedInstaller\" /t && icacls \"%WINDIR%\" /restore \"%WINDIR%\\WinSxS_NTFS.acl\"");
                await CmdPowershell.RunCMDCommandAsAdmyn_Async("sc config msiserver start= demand && sc config TrustedInstaller start= demand");
            });
        }
    }
    internal class OptimizationItem : SomeItem { }
    internal class CleanItem : SomeItem { }
}
