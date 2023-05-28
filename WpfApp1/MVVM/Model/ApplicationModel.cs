using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp1.Core;
using WpfApp1.MVVM.Model.SystemMethods;

namespace WpfApp1.MVVM.Model
{
    class ApplicationModel : ObservableObject
    {
        public List<AppsItem> AppsList { get; set; } = new List<AppsItem>(){
            new AppsItem() { Action  = () =>  DeleteXBox(), Title="Xbox Live", Source=@"\Resources\Applications\Select\xbox.png", IsChecked = true},
            new AppsItem() { Action  = () => DeleteSkype(), Title="Skype", Source=@"\Resources\Applications\Select\skype.png", IsChecked = true },
            new AppsItem() { Action  = () => DeleteMSOffice(), Title="Office", Source=@"\Resources\Applications\Select\Office.png", IsChecked = true },
            new AppsItem() { Action  = () => DeleteOneNotes(), Title="OneNote", Source=@"\Resources\Applications\Select\bebra.png", IsChecked = true },
            new AppsItem() { Action  = () => DeletePhone(), Title="Your Phone", Source=@"\Resources\Applications\Select\phone.png", IsChecked = true },
            new AppsItem() { Action  = () => DeleteGroove(), Title="Groove Music", Source=@"\Resources\Applications\Select\grove.png", IsChecked = true },
            new AppsItem() { Action  = () => DeleteTips(), Title="Tips (Hints)", Source=@"\Resources\Applications\Select\hints.png", IsChecked = true },
            new AppsItem() { Action  = () => DeleteMixReality(), Title="Mixed Reality", Source=@"\Resources\Applications\Select\mixedreality.png", IsChecked = true },
            new AppsItem() { Action  = () => DeleteSolitare(), Title="Solitare", Source=@"\Resources\Applications\Select\solitare.png", IsChecked = true },
            new AppsItem() { Action  = () => DeleteVoiceRec(), Title="Voice Recorder", Source=@"\Resources\Applications\Select\voicerec.png", IsChecked = true },
            new AppsItem() { Action  = () => DeleteNotes(), Title="Sticky Notes", Source=@"\Resources\Applications\Select\stickynotes.png", IsChecked = true },
            new AppsItem() { Action  = () => DeleteAlarms(), Title="Alarms & Clock", Source=@"\Resources\Applications\Select\alarm.png", IsChecked = true },
            new AppsItem() { Action  = () => DeletePeople(), Title="People", Source=@"\Resources\Applications\Select\people.png", IsChecked = true },
            new AppsItem() { Action  = () => Delete3DViewer(), Title="3D Viewer", Source=@"\Resources\Applications\Select\3d.png", IsChecked = true },
            new AppsItem() { Action  = () => DeleteWeather(), Title="Weather", Source=@"\Resources\Applications\Select\weather.png", IsChecked = true },
            new AppsItem() { Action  = () => DeleteMail(), Title="Mail & Calendar", Source=@"\Resources\Applications\Select\email.png", IsChecked = true },
            new AppsItem() { Action  = () => DeleteXBoxGameBar(), Title="Xbox Game Bar", Source=@"\Resources\Applications\Select\gamebar.png", IsChecked = true },
            new AppsItem() { Action  = () => DeletePaint3D(), Title="Paint 3D", Source=@"\Resources\Applications\Select\paint.png", IsChecked = true },
            new AppsItem() { Action  = () => DeleteTechSupport(), Title="Tech Support", Source=@"\Resources\Applications\Select\support.png", IsChecked = true },
            new AppsItem() { Action  = () => DeleteFeedback(), Title="Review Center", Source=@"\Resources\Applications\Select\feedback.png", IsChecked = true },
            new AppsItem() { Action  = () => DeleteCortana(), Title="Cortana", Source=@"\Resources\Applications\Select\cortana.png", IsChecked = true },
            new AppsItem() { Action  = () => DeleteMaps(), Title="Maps", Source=@"\Resources\Applications\Select\maps.png", IsChecked = true },
            new AppsItem() { Action  = () => DeleteOneDrive(), Title="OneDrive", Source=@"\Resources\Applications\Select\onedrive.png", IsChecked = false },
            new AppsItem() { Action  = () => DeletePhotos(), Title="Photos", Source=@"\Resources\Applications\Select\photos.png", IsChecked = false },
            new AppsItem() { Action  = () => DeleteCamera(), Title="Camera", Source=@"\Resources\Applications\Select\camera.png", IsChecked = false },
            new AppsItem() { Action  = () => DeleteMSStore(), Title="Microsoft Store", Source=@"\Resources\Applications\Select\winstore.png", IsChecked = false },
            new AppsItem() { Action  = () => DeleteCalc(), Title="Calculator", Source=@"\Resources\Applications\Select\calc.png", IsChecked = false },
            new AppsItem() { Action  = () => DeleteMovies(), Title="Movies & TV", Source=@"\Resources\Applications\Select\movies.png", IsChecked = false },
            new AppsItem() { Action  = () => DeleteScreen(), Title="Snipping Tool", Source=@"\Resources\Applications\Select\screen.png", IsChecked = false },
        };
        public async Task DeleteAppExecute()
        {
            foreach (var item in AppsList)
            {
                if (item.IsChecked == true)
                {
                    await item.Action();
                    item.IsChecked = false;
                }
            }
        }

        #region Logic
        private static async Task DeleteMSStore()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *WindowsStore* | Remove-AppxPackage");
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.StorePurchaseApp* | Remove-AppxPackage");
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.Services.Store.Engagement* | Remove-AppxPackage");
        }
        private static async Task DeleteOneNotes()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *OneNote* | Remove-AppxPackage");
        }
        private static async Task DeleteMSOffice()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *officehub* | Remove-AppxPackage");
        }
        private static async Task DeleteSkype()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.SkypeApp* | Remove-AppxPackage");
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.Windows.ParentalControls* | Remove-AppxPackage");
        }
        private static async Task DeleteXBox()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *XboxApp* | Remove-AppxPackage");
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.XboxGameCallableUI* | Remove-AppxPackage");
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.XboxSpeechToTextOverlay* | Remove-AppxPackage");
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.Xbox.TCUI* | Remove-AppxPackage");
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.XboxIdentityProvider* | Remove-AppxPackage");
        }
        private static async Task DeleteGroove()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *ZuneMusic* | Remove-AppxPackage");
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *A025C540.Yandex.Music* | Remove-AppxPackage");
        }
        private static async Task DeleteAlarms()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *WindowsAlarms* | Remove-AppxPackage");
        }
        private static async Task DeleteTips()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Getstarted* | Remove-AppxPackage");
        }
        private static async Task DeleteMixReality()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.MixedReality.Portal* | Remove-AppxPackage");
        }
        private static async Task DeleteSolitare()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *MicrosoftSolitaireCollection* | Remove-AppxPackage");
        }
        private static async Task DeleteVoiceRec()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *soundrecorder* | Remove-AppxPackage");
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.WindowsSoundRecorder* | Remove-AppxPackage");
        }
        private static async Task DeleteNotes()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *MicrosoftStickyNotes* | Remove-AppxPackage");
        }
        private static async Task DeleteCamera()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *WindowsCamera* | Remove-AppxPackage");
        }
        private static async Task DeletePeople()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.People* | Remove-AppxPackage");
        }
        private static async Task DeletePhone()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.YourPhone* | Remove-AppxPackage");
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *windowsphone* | Remove-AppxPackage");
        }
        private static async Task DeleteMail()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *windowscommunicationsapps* | Remove-AppxPackage");
        }
        private static async Task DeleteXBoxGameBar()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.XboxGamingOverlay* | Remove-AppxPackage");
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.XboxGameOverlay* | Remove-AppxPackage");
        }
        private static async Task DeletePaint3D()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *MSPaint* | Remove-AppxPackage");
        }
        private static async Task DeleteTechSupport()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *GetHelp* | Remove-AppxPackage");
        }
        private static async Task Delete3DViewer()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.Microsoft3DViewer* | Remove-AppxPackage");
        }
        private static async Task DeleteFeedback()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.WindowsFeedbackHub* | Remove-AppxPackage");
        }
        private static async Task DeleteWeather()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.BingWeather* | Remove-AppxPackage");
        }
        private static async Task DeleteCortana()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.549981C3F5F10* | Remove-AppxPackage");
        }
        private static async Task DeleteOneDrive()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *onenote* | Remove-AppxPackage");

            await CmdPowershell.RunCMDCommandAsAdmyn_Async(@$"taskkill /f /im OneDrive.exe & %systemroot%\SysWOW64\OneDriveSetup.exe /uninstall");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async(@$"taskkill /f /im OneDrive.exe & %systemroot%\System32\OneDriveSetup.exe /uninstall");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("rd /s /q %userprofile%\\OneDrive");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("reg delete HKCR\\CLSID\\{018D5C66-4533-4307-9B53-224DE2ED1FE6} /f");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("reg delete HKCR\\Wow6432Node\\CLSID\\{018D5C66-4533-4307-9B53-224DE2ED1FE6} /f");
            await CmdPowershell.RunCMDCommandAsAdmyn_Async("rd /s /q \"%allusersprofile%\\Microsoft OneDrive\"");
        }
        private static async Task DeleteMaps()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.WindowsMaps* | Remove-AppxPackage");
        }
        private static async Task DeletePhotos()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.Windows.Photos* | Remove-AppxPackage");
        }
        private static async Task DeleteCalc()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.WindowsCalculator* | Remove-AppxPackage");
        }
        private static async Task DeleteMovies()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *ZuneVideo* | Remove-AppxPackage");
        }
        private static async Task DeleteScreen()
        {
            await CmdPowershell.RunPowershellCommandAsAdmyn_Async("Get-AppxPackage *Microsoft.ScreenSketch* | Remove-AppxPackage");
        }

        #endregion
    }

    class AppsItem : SomeItem 
    {
        public string Source { get; set; }
    }
}
