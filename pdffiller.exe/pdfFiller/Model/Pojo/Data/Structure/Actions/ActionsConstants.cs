// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Pojo.Data.Structure.Actions.ActionsConstants
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Newtonsoft.Json;
using System.Collections.Generic;

#nullable disable
namespace pdfFiller.Model.Pojo.Data.Structure.Actions;

public class ActionsConstants
{
  public string[] manage;
  public string[] actions;

  public List<string> GetAvailbaleActions(int[] available)
  {
    List<string> availbaleActions = new List<string>();
    for (int index = 0; index < available.Length; ++index)
    {
      if (available[index] == 1)
        availbaleActions.Add(this.actions[index]);
    }
    return availbaleActions;
  }

  public List<string> GetAvailbaleManageActions(int[] available)
  {
    List<string> availbaleManageActions = new List<string>();
    for (int index = 0; index < available.Length; ++index)
    {
      if (available[index] == 1)
        availbaleManageActions.Add(this.manage[index]);
    }
    return availbaleManageActions;
  }

  public override string ToString() => JsonConvert.SerializeObject((object) this);

  public static ActionsConstants FromString(string json)
  {
    return JsonConvert.DeserializeObject<ActionsConstants>(json);
  }
}
