#r "System.Drawing"
#r "System.Runtime.InteropServices"
using System;
using System.Drawing;
using System.Runtime.InteropServices;

public static class Common
{
    // This will allow us to designate the bin directory as a binary location
    // so that the C++ runtime will load.  Kernel32 is given to us for free :)
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool SetDllDirectory(string lpPathName);

    // Need to set the bin directory as a DLL source
    public static bool SetDLLDirectory( string dirName )
    {
        return SetDllDirectory( dirName );
    }

    // This will pull the image after the effects are added.
    public static Bitmap GetImageFile( string filePath )
    {
        return (Bitmap)Image.FromFile(filePath, true);
    }

    // Return an environment variable or a provided default.
    public static string GetEnvironmentVariable(string variableName, string valIfNull = "")
    {
        return 
            Environment.GetEnvironmentVariable(variableName, EnvironmentVariableTarget.Process)
            ??
            valIfNull;
    }
}