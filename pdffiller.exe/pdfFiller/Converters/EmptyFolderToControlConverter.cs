// Decompiled with JetBrains decompiler
// Type: pdfFiller.Converters.EmptyFolderToControlConverter
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Model.Pojo.Data;
using pdfFiller.UI.EmptyFolders;
using pdfFiller.Utils;
using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

#nullable disable
namespace pdfFiller.Converters;

public class EmptyFolderToControlConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value == null)
      return (object) null;
    Folder folder = value as Folder;
    if (folder.id == -99999L)
      return (object) this.CreateView("/pdfFiller;component/Resources/Images/LocalSearch/empty_search.png", ResourcesUtils.GetStringResource("empty_search_message"), ResourcesUtils.GetStringResource("empty_search_title"));
    if (folder.id == -88888L)
      return (object) this.CreateView("/pdfFiller;component/Resources/Images/LocalSearch/start_search.png", ResourcesUtils.GetStringResource("start_search_message"), ResourcesUtils.GetStringResource("start_search_title"));
    if (folder.IsInTrash)
    {
      Tuple<string, string> emptyData = EmptyFolderCollection.GetEmptyData(-100L);
      return (object) this.CreateView(emptyData.Item1, emptyData.Item2, "Trash Bin");
    }
    Tuple<string, string> emptyData1 = EmptyFolderCollection.GetEmptyData(folder.id);
    if (Folder.IsCloudsFolder(folder.id))
      return (object) this.CreateView(emptyData1.Item1, emptyData1.Item2, "Sign in " + folder.Name);
    return emptyData1 != null ? (object) this.CreateView(emptyData1.Item1, emptyData1.Item2, folder.Name) : CustomEmptyFolderFactory.CreateEmptyFolderView(folder) ?? (object) this.CreateView("/pdfFiller;component/Resources/Images/EmptyFolders/empty_folder.png", ResourcesUtils.GetStringResource("empty_folder_message"));
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) null;
  }

  private UserControl CreateView(string image, string message)
  {
    return this.CreateView(image, message, (string) null);
  }

  private UserControl CreateView(string image, string message, string title)
  {
    EmptyFolder view = new EmptyFolder();
    view.DataContext = (object) new EmptyFolderViewModel()
    {
      ImageSource = image,
      Message = message,
      Title = title
    };
    return (UserControl) view;
  }
}
