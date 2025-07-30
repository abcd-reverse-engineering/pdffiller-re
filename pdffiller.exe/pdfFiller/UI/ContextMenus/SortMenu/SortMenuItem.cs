// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.ContextMenus.SortMenu.SortMenuItem
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Newtonsoft.Json;

#nullable disable
namespace pdfFiller.UI.ContextMenus.SortMenu;

public class SortMenuItem
{
  public const string SORT_TYPE_ASC = "asc";
  public const string SORT_TYPE_DESC = "desc";
  public const string MODIFIED = "modified";
  public const string DATE = "date";
  public const string FILE_NAME = "filename";
  public string id;

  public SortMenuItem(string id, string name, string sortName, string sortType, bool isHeader = false)
  {
    this.id = id;
    this.Name = name;
    this.SortName = sortName;
    this.SortType = sortType;
    this.IsHeader = isHeader;
  }

  public string Name { get; set; }

  public bool IsHeader { get; set; }

  public bool IsSelected { get; set; }

  public string SortName { get; set; }

  public string SortType { get; set; }

  public override bool Equals(object obj)
  {
    switch (obj)
    {
      case string _:
        return ((string) obj).Equals(this.id);
      case SortMenuItem _:
        return ((SortMenuItem) obj).id.Equals(this.id);
      default:
        return false;
    }
  }

  public override string ToString() => JsonConvert.SerializeObject((object) this);

  public static SortMenuItem FromString(string json)
  {
    return json == null ? (SortMenuItem) null : JsonConvert.DeserializeObject<SortMenuItem>(json);
  }
}
