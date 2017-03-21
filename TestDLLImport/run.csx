#load "test.csx"
#load "processor.csx"
#load "wmi.csx"
#r "System.Runtime.InteropServices"
using System;
using System.Runtime.InteropServices;

public static void Run(string input, TraceWriter log)
{
    log.Info($"C# manually triggered function called with input: {input}");
    // RunThisTest("This is a test", log);
    GetProcessorInfo(log);
    GetProcesses2(log);
}