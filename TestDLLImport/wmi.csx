#r "System.Management"
using System.Management;
using System.Diagnostics;

public static void GetProcesses( TraceWriter log )
{   
    var searcher = new ManagementObjectSearcher("root\\CIMV2", 
                    "SELECT * FROM Win32_Process"); 

    foreach (var queryObj in searcher.Get())
    {
        log.Info( queryObj["Caption"].ToString() );
    }
}

public static void GetProcesses2( TraceWriter log )
{
    Process.GetProcesses().ToList().ForEach( a => log.Info(a.ProcessName) );
}