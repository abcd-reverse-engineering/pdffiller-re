// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.SideMenu.SideMenuItemCollection
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Utils;
using System.Collections.ObjectModel;

#nullable disable
namespace pdfFiller.UI.SideMenu;

public static class SideMenuItemCollection
{
  public static readonly ObservableCollection<SideMenuItem> Items = new ObservableCollection<SideMenuItem>();
  public static readonly ObservableCollection<SideMenuItem> BottomItems = new ObservableCollection<SideMenuItem>();

  static SideMenuItemCollection()
  {
    SideMenuItemCollection.Items.Add(new SideMenuItem()
    {
      ImageSource = "/pdfFiller;component/Resources/Images/SideMenu/my_account.png",
      Title = ResourcesUtils.GetStringResource("side_menu_my_account")
    });
    SideMenuItemCollection.Items.Add(new SideMenuItem()
    {
      ImageSource = "/pdfFiller;component/Resources/Images/SideMenu/support.png",
      Title = ResourcesUtils.GetStringResource("side_menu_support")
    });
    SideMenuItemCollection.Items.Add(new SideMenuItem()
    {
      ImageSource = "/pdfFiller;component/Resources/Images/SideMenu/help.png",
      Title = ResourcesUtils.GetStringResource("side_menu_help")
    });
    SideMenuItemCollection.BottomItems.Add(new SideMenuItem()
    {
      ImageSource = "/pdfFiller;component/Resources/Images/SideMenu/other_apps.png",
      Title = ResourcesUtils.GetStringResource("side_menu_other_apps")
    });
    SideMenuItemCollection.BottomItems.Add(new SideMenuItem()
    {
      ImageSource = "/pdfFiller;component/Resources/Images/SideMenu/logout.png",
      Title = ResourcesUtils.GetStringResource("side_menu_logout")
    });
  }
}
