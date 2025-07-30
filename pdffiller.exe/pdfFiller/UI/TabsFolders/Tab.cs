// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.TabsFolders.Tab
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.common;
using pdfFiller.Model.Pojo.Data;
using pdfFiller.Utils;
using System;
using System.Collections.ObjectModel;

#nullable disable
namespace pdfFiller.UI.TabsFolders;

public class Tab : PropertyNotifier
{
  public const int MYBOX_ID = 0;
  public const int CLOUD_ID = 1;
  public const int INBOX_ID = 2;
  public const int OUTBOX_ID = 3;
  public int id;
  private string _iconSource;
  private string _simpleIcon;
  private string _selectedIcon;
  private ObservableCollection<object> folders;
  private Folder _selectedFolder;

  public static ObservableCollection<Tab> GetTabs()
  {
    ObservableCollection<Tab> tabs = new ObservableCollection<Tab>();
    tabs.Add(new Tab(0, ResourcesUtils.GetStringResource("tab_mybox"), "/pdfFiller;component/resources/images/Tabs/mybox.png", "/pdfFiller;component/resources/images/Tabs/mybox_selected.png", (TabCustomizer) new MyBoxTabCustomizer()));
    tabs.Add(new Tab(1, ResourcesUtils.GetStringResource("tab_cloud"), "/pdfFiller;component/resources/images/Tabs/cloud.png", "/pdfFiller;component/resources/images/Tabs/cloud_selected.png", (TabCustomizer) new CloudTabCustomizer()));
    tabs.Add(new Tab(2, ResourcesUtils.GetStringResource("tab_inbox"), "/pdfFiller;component/resources/images/Tabs/inbox.png", "/pdfFiller;component/resources/images/Tabs/inbox_selected.png", (TabCustomizer) new InboxTabCustomizer()));
    tabs.Add(new Tab(3, ResourcesUtils.GetStringResource("tab_outbox"), "/pdfFiller;component/resources/images/Tabs/outbox.png", "/pdfFiller;component/resources/images/Tabs/outbox_selected.png", (TabCustomizer) new OutboxTabCustomizer()));
    return tabs;
  }

  public Tab(
    int id,
    string title,
    string simpleIcon,
    string selectedIcon,
    TabCustomizer tabCustomizer)
  {
    this.id = id;
    this.Title = title;
    this._simpleIcon = simpleIcon;
    this._selectedIcon = selectedIcon;
    this.TabCustomizer = tabCustomizer;
    this.IconSource = this._simpleIcon;
  }

  public string Title { get; set; }

  public string IconSource
  {
    get => this._iconSource;
    set
    {
      this._iconSource = value;
      this.NotifyProperty(nameof (IconSource));
    }
  }

  public ObservableCollection<object> Folders
  {
    get => this.folders;
    set
    {
      this.folders = value;
      this.NotifyProperty(nameof (Folders));
    }
  }

  public Folder SelectedFolder
  {
    get => this._selectedFolder;
    set
    {
      this._selectedFolder = value;
      if (this.FolderSelectedAction != null)
        this.FolderSelectedAction(value);
      this.NotifyProperty(nameof (SelectedFolder));
    }
  }

  public Action<Folder> FolderSelectedAction { get; set; }

  public TabCustomizer TabCustomizer { get; set; }

  internal void ChangeIcon()
  {
    if (this.IconSource == this._simpleIcon)
      this.IconSource = this._selectedIcon;
    else
      this.IconSource = this._simpleIcon;
  }
}
