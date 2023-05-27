using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WpfApp1.Core;
using WpfApp1.MVVM.Model.SystemMethods;

namespace WpfApp1.MVVM.Model
{
    class AutoStartAppsModel : ObservableObject
    {
        /// <summary>
        /// Fields for creating a collection, used only in it 
        /// </summary>
        public string Name { get; set; }
        public string Path { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this registry key is selected
        /// </summary>        
        private bool _isChecked;
        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    OnPropertyChanged(nameof(IsChecked));
                }
            }
        }
        /// <summary>
        /// Properties responsible for adding a parameter to the registry 
        /// </summary>
        public string UserPath { get; set; }
        public string UserName { get; set; }
    }

    static class AutoStartAppsService
    {
        private static readonly string _folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup));

        private static List<RegistryKey> _keys = new() {
            Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run"),
            Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run"),
            Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run"),
            Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run")};

        public static List<AutoStartAppsModel> GetAutoStartApps()
        {
            List<AutoStartAppsModel> autoStart = new();

            foreach (var key in _keys)
                SearchRegistryParams(key, autoStart);

            SearchInFolder(_folderPath, autoStart);

            return autoStart;
        }
        private static void SearchInFolder(string path, List<AutoStartAppsModel> autoStart)
        {
            DirectoryInfo directory = new(path);
            foreach (FileInfo file in directory.GetFiles())
            {
                if (file.Name != "desktop.ini")
                    autoStart.Add(new AutoStartAppsModel { IsChecked = false, Name = file.Name, Path = file.FullName });
            }
        }
        private static void SearchRegistryParams(RegistryKey key, List<AutoStartAppsModel> autoStart)
        {
            foreach (var keyName in key.GetValueNames())
                    autoStart.Add(new AutoStartAppsModel { IsChecked = false, Name = keyName, Path = key.GetValue(keyName).ToString() });
        }

        /// <summary>
        /// These methods are called when adding or removing applications from startup
        /// </summary>
        public static async Task DeleteParamsInRegistry(string paramsName)
        {
            foreach (var key in _keys)
            {
                if (key.GetValue(paramsName) != null)
                    key.DeleteValue(paramsName);
            }

            if (File.Exists(@$"{_folderPath}\{paramsName}"))
            {
                string path = $@"{_folderPath}\{paramsName}";
                await CmdPowershell.RunCMDCommandAsAdmyn_Async($"del \"{path}\"");
            }
        }
        public static async Task AddParamsInRegistry(string name, string value)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
                _keys[0].SetValue($"{name}", $"{value.Replace("/", @"\")}");
        }
    }
}