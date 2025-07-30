// Decompiled with JetBrains decompiler
// Type: pdfFiller.Converters.MainControlContentConverter
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.di;
using pdfFiller.UI.FindPdf;
using pdfFiller.UI.Main;
using pdfFiller.UI.MyDocs;
using pdfFiller.UI.TrashBin;
using pdfFiller.Utils;
using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

#nullable disable
namespace pdfFiller.Converters;

public class MainControlContentConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    UserControl control = (UserControl) null;
    int num = (int) value;
    if (num == 4)
      control = MainControlNavigationHelper.Back();
    if (num == 0)
    {
      control = (UserControl) new MyDocsControl();
      MainControlNavigationHelper.SetRoot(control);
    }
    if (num == 1)
    {
      MainControlNavigationHelper.Add((UserControl) new FindPdfControll());
      control = MainControlNavigationHelper.GetCurrentItem();
    }
    if (num == 2)
    {
      MainControlNavigationHelper.Add((UserControl) new TrashBinControl());
      control = MainControlNavigationHelper.GetCurrentItem();
    }
    this.Track(control);
    try
    {
      DIManager.BusManager.GetRouter(MainViewModel.KEY).SendData("BottomMenuViewModel", (object) !MainControlNavigationHelper.IsTrashBin());
    }
    catch (Exception ex)
    {
    }
    return (object) control;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }

  private void Track(UserControl control)
  {
    if (control is MyDocsControl)
      DIManager.AnalyticsManager.TrackPage("my_docs_main_screen");
    if (control is FindPdfControll)
      DIManager.AnalyticsManager.TrackPage("my_docs_find_pdf");
    if (!(control is TrashBinControl))
      return;
    DIManager.AnalyticsManager.TrackPage("my_docs_trash_bin");
    DIManager.AmplitudeManager.AddEvent("Trash Bin Opened");
  }
}
