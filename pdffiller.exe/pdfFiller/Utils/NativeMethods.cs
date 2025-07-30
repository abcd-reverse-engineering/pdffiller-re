// Decompiled with JetBrains decompiler
// Type: pdfFiller.Utils.NativeMethods
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace pdfFiller.Utils;

internal class NativeMethods
{
  public static readonly IntPtr HWND_BROADCAST = new IntPtr((int) ushort.MaxValue);
  public static readonly int WM_SHOWME = NativeMethods.RegisterWindowMessage(nameof (WM_SHOWME));

  [DllImport("user32")]
  public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

  [DllImport("user32")]
  public static extern int RegisterWindowMessage(string message);

  [DllImport("user32.dll")]
  public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
}
