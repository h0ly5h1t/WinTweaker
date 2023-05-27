using Microsoft.Win32;
using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp1.Core;
using WpfApp1.MVVM.Model.SystemMethods;

namespace WpfApp1.MVVM.Model
{
    class InterfaceModel : ObservableObject
    {
        public List<ShortcutItem> ShortcutList { get; set; } = new List<ShortcutItem>(){
            new ShortcutItem() {Action  = () => AddBecomeOwnerDir_Async(), Title="Add the item \"Become the owner of the directory\" in the context menu", IsChecked = false},
            new ShortcutItem() {Action  = () => AddCMDDesktop_Async(), Title="Add the item \"Command Promp (cmd)\" in the context menu", IsChecked = false },
            new ShortcutItem() {Action  = () => AddEthernetAbility_Async(), Title="Add the item \"Allow/Deny Internet acces\" in the context menu", IsChecked = false },
            new ShortcutItem() {Action  = () => AddCleanFold_Async(), Title="Add the item \"Delete Folder Content\" in the context menu", IsChecked = false },
            new ShortcutItem() {Action  = () => AddGetHashCode_Async(), Title="Add the item \"Get Hash-Sum\" in the context menu for files", IsChecked = false },
        };
        public List<GUIItem> GUIList { get; set; } = new List<GUIItem>(){
            new GUIItem() {Action  = () => AccelerateCursor_Async(), Title="Accelerate the frequency of cursor flickering (default - 530ms)", IsChecked = false },
            new GUIItem() {Action  = () => AcceleratePanel_Async(), Title="Make app previews appear faster on the taskbar (default - 400ms)", IsChecked = false },
            new GUIItem() {Action  = () => AddTray_Async(), Title="Add display of all app tray icons", IsChecked = false },
            new GUIItem() {Action  = () => AddOffWindow_Async(), Title="Restore folder windows to their previous size when you log on", IsChecked = false },
            new GUIItem() {Action  = () => AddEditScrollBar_Async(), Title="Make the scroll bar thinne", IsChecked = false },
            new GUIItem() {Action  = () => RemoveShortcutsIco_Async(), Title="Remove arrows from desktop shortcuts", IsChecked = false },
        };

        public async void AddItemsShortcutMenuExecute()
        {
            foreach (var item in ShortcutList)
            {
                if (item.IsChecked == true)
                {
                    await item.Action();
                    item.IsChecked = false;
                }
            }
        }
        public async void AddGUIExecute()
        {
            foreach (var item in GUIList)
            {
                if (item.IsChecked == true)
                {
                    await item.Action();
                    item.IsChecked = false;
                }
            }
        }
        #region Logic
        private async static Task AddBecomeOwnerDir_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\*\shell\runas");
                key.SetValue("Icon", "imageres.dll,101");
                key.SetValue("NoWorkingDirectory", "");
                key.SetValue("", "Become the owner of the directory");

                using var key1 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\*\shell\runas\command");
                key1.SetValue("IsolatedCommand", @"cmd.exe /c takeown /f ""%1"" && icacls ""%1"" /grant administrators:F");
                key1.SetValue("", @"cmd.exe /c takeown /f ""%1"" && icacls ""%1"" /grant administrators:F");

                using var key2 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\Directory\shell\runas");
                key2.SetValue("Icon", "imageres.dll,101");
                key2.SetValue("NoWorkingDirectory", "");
                key2.SetValue("", "Become the owner of the directory");

                using var key3 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\Directory\shell\runas\command");
                key3.SetValue("IsolatedCommand", @"cmd.exe /c takeown /f ""%1"" /r /d y && icacls ""%1"" /grant administrators:F /t");
                key3.SetValue("", @"cmd.exe /c takeown /f ""%1"" /r /d y && icacls ""%1"" /grant administrators:F /t");

                using var key4 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\dllfile\shell\runas");
                key4.SetValue("HasLUAShield", "");
                key4.SetValue("NoWorkingDirectory", "");
                key4.SetValue("Icon", "imageres.dll,101");
                key4.SetValue("", "Become the owner of the directory");

                using var key5 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\dllfile\shell\runas\command");
                key5.SetValue("IsolatedCommand", @"cmd.exe /c takeown /f ""%1"" && icacls ""%1"" /grant administrators:F");
                key5.SetValue("", @"cmd.exe /c takeown /f ""%1"" && icacls ""%1"" /grant administrators:F");

                using var key6 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\exefile\shell\runas2");
                key6.SetValue("HasLUAShield", "");
                key6.SetValue("NoWorkingDirectory", "");
                key6.SetValue("Icon", "imageres.dll,101");
                key6.SetValue("", "Become the owner of the directory");

                using var key7 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\exefile\shell\runas2\command");
                key7.SetValue("IsolatedCommand", @"cmd.exe /c takeown /f ""%1"" && icacls ""%1"" /grant administrators:F");
                key7.SetValue("", @"cmd.exe /c takeown /f ""%1"" && icacls ""%1"" /grant administrators:F");

            });
        }
        private async static Task AddCMDDesktop_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.ClassesRoot.CreateSubKey(@"DesktopBackground\Shell\cmd");
                key.SetValue("Position", "bottom");
                key.SetValue("Icon", "imageres.dll,311");
                key.SetValue("", "Command Prompt");

                using var key1 = Registry.ClassesRoot.CreateSubKey(@"DesktopBackground\Shell\cmd\command");
                key1.SetValue("", "cmd.exe");
            });
        }
        private async static Task AddEthernetAbility_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\exefile\shell\Firewall_Allow");
                key.SetValue("Icon", "netcenter.dll,10");
                key.SetValue("", "Allow Internet access");

                using var key1 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\exefile\shell\Firewall_Allow\command");
                key1.SetValue("", @"netsh advfirewall firewall delete rule name=""%1""");

                using var key2 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\exefile\shell\Firewall_Block");
                key2.SetValue("Icon", "netcenter.dll,5");
                key2.SetValue("", "Deny access to the Internet");

                using var key3 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\exefile\shell\Firewall_Block\command");
                key3.SetValue("", @"cmd /d /c ""netsh advfirewall firewall add rule name=""%1"" dir=in action=block program=""%1"" & netsh advfirewall firewall add rule name=""%1"" dir=out action=block program=""%1""""");
            });
        }
        private async static Task AddCleanFold_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\Directory\shell\EmptyThisFolder");
                key.SetValue("Icon", "imageres.dll,257");
                if (key?.GetValue("") != null)
                {
                    key.DeleteValue("");
                    key.SetValue("", "Delete the contents of the folder");
                }

                using var key1 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\Directory\shell\EmptyThisFolder\command");
                if (key1?.GetValue("") != null)
                {
                    key1.DeleteValue("");
                    key1.SetValue("", @"cmd /c ""cd /d %1 && del /s /f /q *.* && rd /s /q .""");
                }
            });
        }
        private async static Task AddGetHashCode_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.ClassesRoot.CreateSubKey(@"*\shell\Get Hash");
                key.SetValue("subcommands", "");
                key.SetValue("icon", "shell32.dll,1");

                #region MD5
                using var key1 = Registry.ClassesRoot.CreateSubKey(@"*\shell\Get Hash\shell\01MD5");
                key1.SetValue("muiverb", "Copy MD5");
                key1.SetValue("icon", "shell32.dll,1");

                using var key2 = Registry.ClassesRoot.CreateSubKey(@"*\shell\Get Hash\shell\01MD5\command");
                key2.SetValue("", @"powershell -windowstyle hidden -command ""(get-filehash -algorithm MD5 -path '%1').hash.tolower().tostring()|set-clipboard""");
                #endregion
                #region SHA256
                using var key3 = Registry.ClassesRoot.CreateSubKey(@"*\shell\Get Hash\shell\03SHA256");
                key3.SetValue("muiverb", "Copy SHA256");
                key3.SetValue("icon", "shell32.dll,1");

                using var key4 = Registry.ClassesRoot.CreateSubKey(@"*\shell\Get Hash\shell\03SHA256\command");
                key4.SetValue("", @"powershell -windowstyle hidden -command ""(get-filehash -algorithm SHA256 -path '%1').hash.tolower().tostring()|set-clipboard""");
                #endregion
                #region SHA512
                using var key5 = Registry.ClassesRoot.CreateSubKey(@"*\shell\Get Hash\shell\05SHA512");
                key5.SetValue("muiverb", "Copy SHA512");
                key5.SetValue("icon", "shell32.dll,1");

                using var key6 = Registry.ClassesRoot.CreateSubKey(@"*\shell\Get Hash\shell\05SHA512\command");
                key6.SetValue("", @"powershell -windowstyle hidden -command ""(get-filehash -algorithm SHA512 -path '%1').hash.tolower().tostring()|set-clipboard""");
                #endregion
            });
        }
        private async static Task AccelerateCursor_Async()
        {
            // ГЕРАСИМОВ ШОЙГУ ГДЕ ПРИПАСЫ?!?!?!??!?!?!?
            await Task.Run(() =>
            {
                using var key = Registry.CurrentUser.CreateSubKey(@"Control Panel\Desktop");
                key.SetValue("CursorBlinkRate", 250);
            });
        }
        private async static Task AcceleratePanel_Async()
        {
            // ГЕРАСИМОВ ШОЙГУ ГДЕ ПРИПАСЫ?!?!?!??!?!?!?
            await Task.Run(() =>
            {
                using var key = Registry.CurrentUser.CreateSubKey(@"Control Panel\Mouse");
                key.SetValue("MouseHoverTime", 35);
            });
        }
        private async static Task AddTray_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer");
                key.SetValue("EnableAutoTray", 0);
            });
        }
        private async static Task AddOffWindow_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced");
                key.SetValue("PersistBrowsers", 1);
            });
        }
        private async static Task AddEditScrollBar_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.CurrentUser.CreateSubKey(@"Control Panel\Desktop\WindowMetrics");
                key.SetValue("ScrollHeight", -210);
                key.SetValue("ScrollWidth", -210);
            });
        }
        private async static Task RemoveShortcutsIco_Async()
        {
            await Task.Run(() =>
            {
                using var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons");
                key.SetValue("29", "");
            });
        } // todo добавить проблему, чтобы качал blanc.ico 
        #endregion
    }

    class ShortcutItem : SomeItem { }
    class GUIItem : SomeItem { }
}
