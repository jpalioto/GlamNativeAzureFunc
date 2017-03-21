#r "System.Runtime.InteropServices"
using System;
using System.Runtime.InteropServices;
  
  public static void RunThisTest( string input, TraceWriter log )
  {
    LOGFONT lf = new LOGFONT();
    lf.lfHeight = 9;
    lf.lfFaceName = "Arial";
    IntPtr handle = CreateFontIndirect(lf);

    if (IntPtr.Zero == handle)
    {
          log.Info("Can't creates a logical font.");
    }
    else
    {
          
          if (IntPtr.Size == 4)
                log.Info($"{Convert.ToString(handle.ToInt32())}");
          else
                log.Info("{0:X}", Convert.ToString(handle.ToInt64()));         

          // Delete the logical font created.
          if (!DeleteObject(handle))
                log.Info("Can't delete the logical font");
    }
  }

[DllImport("msvcrt.dll")]
public static extern int puts(
    [MarshalAs(UnmanagedType.LPStr)]
    string m);
[DllImport("msvcrt.dll")]
internal static extern int _flushall();

[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
public static extern IntPtr CreateFontIndirect(
      [In, MarshalAs(UnmanagedType.LPStruct)]
      LOGFONT lplf   // characteristics
      );

[DllImport("gdi32.dll")]
public static extern bool DeleteObject(
      IntPtr handle
      );

[StructLayout(LayoutKind.Sequential)]
public class LOGFONT 
{ 
    public const int LF_FACESIZE = 32;
    public int lfHeight; 
    public int lfWidth; 
    public int lfEscapement; 
    public int lfOrientation; 
    public int lfWeight; 
    public byte lfItalic; 
    public byte lfUnderline; 
    public byte lfStrikeOut; 
    public byte lfCharSet; 
    public byte lfOutPrecision; 
    public byte lfClipPrecision; 
    public byte lfQuality; 
    public byte lfPitchAndFamily;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst=LF_FACESIZE)]
    public string lfFaceName; 
}