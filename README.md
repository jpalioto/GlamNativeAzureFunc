# Azure Function Native

There are two Azure Functions in this repo.  GlamNative uses a C++ native library from an Azure Function. **NB: I did not commit the bin directory.  You will need to have your binaries in the bin directory and you will need to use SetDllDirectory (see common.csx in GlamNative for example)**

My bin directory looks like this ...

![Bin Directory](/Content/bin_directory.png)

It contains all the native binaries I need including the proper version of the VC++ libraries.

The second Azure function demonstrates the use of some more complex marshalling as well as WMI through C# libraries.
