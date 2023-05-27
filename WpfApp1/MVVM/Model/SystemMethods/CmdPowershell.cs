using System.Diagnostics;
using System.Threading.Tasks;

namespace WpfApp1.MVVM.Model.SystemMethods
{
    static class CmdPowershell
    {
        public static async Task RunCMDCommandAsAdmyn_Async(string command)
        {
            using var process = Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c {command}",
                UseShellExecute = false,
                CreateNoWindow = true,
            });

            await process.WaitForExitAsync();
        }
        public static async Task RunPowershellCommandAsAdmyn_Async(string command)
        {
            var process = Process.Start(new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = $"/command {command}",
                UseShellExecute = false,
                CreateNoWindow = true,
            });

            await process.WaitForExitAsync();
        }
    }
}
