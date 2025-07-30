// Decompiled with JetBrains decompiler
// Type: pdfFiller.Utils.FileAssociationHandler
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Properties;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace pdfFiller.Utils;

public class FileAssociationHandler
{
  public const string OPEN_WITH_FILE_PATH_KEY = "OPEN_WITH_FILE_PATH";
  private const int SHCNE_ASSOCCHANGED = 134217728 /*0x08000000*/;
  private const int SHCNF_FLUSH = 4096 /*0x1000*/;
  private Settings LocalStorage = Settings.Default;

  [DllImport("Shell32.dll")]
  private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);

  public static void HandleOpenWithFlow()
  {
    string[] commandLineArgs = Environment.GetCommandLineArgs();
    if (commandLineArgs.GetLength(0) <= 1)
      return;
    string filePath = commandLineArgs[1];
    if (!FileUtils.IsFileAccepted(filePath))
      return;
    // ISSUE: variable of a compiler-generated type
    Settings settings = Settings.Default;
    settings["OPEN_WITH_FILE_PATH"] = (object) filePath;
    settings.Save();
  }

  public bool HasFileToUplaodOnStart()
  {
    return !string.IsNullOrEmpty(this.LocalStorage.OPEN_WITH_FILE_PATH);
  }

  public string GetFileToUpload()
  {
    string fileToUpload = this.LocalStorage["OPEN_WITH_FILE_PATH"] as string;
    this.LocalStorage["OPEN_WITH_FILE_PATH"] = (object) null;
    this.LocalStorage.Save();
    return fileToUpload;
  }
}
