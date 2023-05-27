using System.Management;

namespace WpfApp1.MVVM.Model.SystemMethods
{
    class SystemService
    {
        public static void CloseService(ManagementObject? service)
        {
            if (service != null)
            {
                // Call the StopService() method to stop the service
                service.InvokeMethod("StopService", null);

                // Set the value of the StartMode property to Disabled so that the service does not start when the OS boots
                var inParams = service.GetMethodParameters("ChangeStartMode");
                inParams["StartMode"] = "Disabled";
            }
        }
        public static void RunService(ManagementObject? service)
        {
            if (service != null)
            {
                // Call the StopService() method to stop the service
                service.InvokeMethod("StopService", null);

                // Set the value of the StartMode property to Disabled so that the service does not start when the OS boots
                var inParams = service.GetMethodParameters("ChangeStartMode");
                inParams["StartMode"] = "Automatic";
            }
        }

    }
}
