// Decompiled with JetBrains decompiler
// Type: pdfFiller.Utils.MainControlNavigationHelper
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Bus;
using pdfFiller.di;
using System.Windows.Controls;

#nullable disable
namespace pdfFiller.Utils;

public static class MainControlNavigationHelper
{
  private const string KEY = "MainControlNavigationHelper";
  private static BackStackHandler<UserControl> backStackHandler;

  static MainControlNavigationHelper()
  {
    BusManager busManager = DIManager.BusManager;
    MainControlNavigationHelper.backStackHandler = busManager.GetControlsBackStackHandler(nameof (MainControlNavigationHelper));
    if (MainControlNavigationHelper.backStackHandler != null)
      return;
    MainControlNavigationHelper.backStackHandler = busManager.CreateControlsBackStackHandler(nameof (MainControlNavigationHelper));
  }

  public static bool HasItems() => MainControlNavigationHelper.backStackHandler.HasItems();

  public static void SetRoot(UserControl control)
  {
    MainControlNavigationHelper.backStackHandler.Clear();
    MainControlNavigationHelper.backStackHandler.Root = control;
  }

  public static void Add(UserControl control)
  {
    MainControlNavigationHelper.backStackHandler.Add(control);
  }

  public static UserControl GetCurrentItem()
  {
    return MainControlNavigationHelper.backStackHandler.CurrentItem;
  }

  public static UserControl Back() => MainControlNavigationHelper.backStackHandler.Back();

  public static bool IsTrashBin()
  {
    return MainControlNavigationHelper.backStackHandler.CurrentItem.GetType().Name == "TrashBinControl";
  }

  public static bool IsCurrentSame(string controlName)
  {
    return MainControlNavigationHelper.backStackHandler.CurrentItem.GetType().Name == controlName;
  }

  public static bool IsPrevSame(string controlName)
  {
    return MainControlNavigationHelper.backStackHandler.Previous.GetType().Name == controlName;
  }

  public static string GetCurrentBusKey()
  {
    return !MainControlNavigationHelper.IsTrashBin() ? "TabsAndFoldersViewModel" : "TrashBinFoldersViewModel";
  }
}
