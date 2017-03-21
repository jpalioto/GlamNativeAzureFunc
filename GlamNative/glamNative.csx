#r "System.Runtime.InteropServices"     // Interop Service is required for DLLImport
using System;
using System.Runtime.InteropServices;

public static class EffectsApplication
{
    // The Glam assembly name.  Don't move to enviornment var, needs to be const
    private const string _assembly = "amt_effects.dll";

    // This is the root path binary location.  For an Azure Function, it has to
    // be under our root directory otherwise Access Denied.
    private static string _basePath = Common.GetEnvironmentVariable("BaseOutputPath",
        @"D:\home\site\wwwroot\GlamSample\output\");

    // Glam's functions to be called.
    [DllImport(_assembly, CallingConvention = CallingConvention.Cdecl)]
    public static extern void amt_c_sharp_api_terminate();

    [DllImport(_assembly, CallingConvention = CallingConvention.Cdecl)]
    public static extern void amt_c_sharp_api_init(string input);

    [DllImport(_assembly, CallingConvention = CallingConvention.Cdecl)]
    public static extern void amt_c_sharp_api_process(string config_fname, string input_string);

    public static void init(string config_path)
    {
        amt_c_sharp_api_init(config_path);
    }

    public static void process(string input_string)
    {
        amt_c_sharp_api_process(_basePath + @"config\", input_string);
    }

    public static void terminate()
    {
        amt_c_sharp_api_terminate();
    }
}
