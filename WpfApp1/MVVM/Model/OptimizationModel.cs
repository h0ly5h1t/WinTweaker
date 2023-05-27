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

        public async void OptimizationSystemExecute()
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
    }
    internal class OptimizationItem : SomeItem { }
}
