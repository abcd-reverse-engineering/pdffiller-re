// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Pojo.Data.ProjectsIconsCollection
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.Runtime.InteropServices;

#nullable disable
namespace pdfFiller.Model.Pojo.Data;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct ProjectsIconsCollection
{
  public const string FILE_TYPE_PDF = "PDF";
  public const string FILE_TYPE_DOC = "DOC";
  public const string FILE_TYPE_DOCX = "DOCX";
  public const string FILE_TYPE_RTF = "RTF";
  public const string FILE_TYPE_TXT = "TXT";
  public const string FILE_TYPE_HTM = "HTM";
  public const string FILE_TYPE_PPT = "PPT";
  public const string FILE_TYPE_PPTX = "PPTX";
  public const string FILE_TYPE_XLSX = "XLSX";
  public const string FILE_TYPE_XLS = "XLS";
  public const string FILE_TYPE_JPG = "JPG";
  public const string FILE_TYPE_JPEG = "JPEG";
  public const string FILE_TYPE_PNG = "PNG";
  public const string PDF_SOURCE = "/pdfFiller;component/Resources/Images/Projects/pdf.png";
  public const string DOC_SOURCE = "/pdfFiller;component/Resources/Images/Projects/word.png";
  public const string TXT_SOURCE = "/pdfFiller;component/Resources/Images/Projects/txt.png";
  public const string PPT_SOURCE = "/pdfFiller;component/Resources/Images/Projects/ppt.png";
  public const string XLS_SOURCE = "/pdfFiller;component/Resources/Images/Projects/excel.png";
  public const string IMAGE_SOURCE = "/pdfFiller;component/Resources/Images/Projects/image.png";
  public const string CORRUPTED_SOURCE = "/pdfFiller;component/Resources/Images/Projects/corrupted.png";

  public static string GetIcon(Project project)
  {
    if (project.IsL2F)
      return "/pdfFiller;component/Resources/Images/Folders/folder_custom.png";
    return project.IsSignatureRequest ? ProjectsIconsCollection.GetDocIcon(project.ext) : ProjectsIconsCollection.GetStatusIcon(project) ?? ProjectsIconsCollection.GetDocIcon(project.fileType);
  }

  public static string GetStatusIcon(Project project)
  {
    string statusIcon = (string) null;
    if (project.status.text != null)
    {
      if (project.status.text.Equals("IN_PROGRESS") || project.status.text.Equals("NOT_SEND"))
        statusIcon = "/pdfFiller;component/Resources/Images/Statuses/status_in_progress.png";
      else if (project.status.text.Equals("SENT"))
        statusIcon = "/pdfFiller;component/Resources/Images/Statuses/status_sent.png";
      else if (project.status.text.Equals("SIGNED") || project.status.text.Equals("RECEIVED"))
        statusIcon = "/pdfFiller;component/Resources/Images/Statuses/status_done.png";
      else if (project.status.text.Equals("READ_ONLY"))
        statusIcon = "/pdfFiller;component/Resources/Images/Statuses/status_view_only.png";
      else if (project.status.text.Equals("FULL_ACCESS"))
        statusIcon = "/pdfFiller;component/Resources/Images/Statuses/status_full_access.png";
      else if (project.status.text.Equals("SIGNATURE"))
        statusIcon = "/pdfFiller;component/Resources/Images/Statuses/status_sign.png";
      else if (project.status.text.Equals("PENDING"))
        statusIcon = "/pdfFiller;component/Resources/Images/Statuses/status_pending.png";
      else if (project.status.text.Equals("FAILED") || project.status.text.Equals("REJECT"))
        statusIcon = "/pdfFiller;component/Resources/Images/Statuses/status_failed.png";
      else if (project.status.text.Equals("S2O_SCHEDULED"))
        statusIcon = "/pdfFiller;component/Resources/Images/Statuses/status_scheduled.png";
      else if (project.status.text.Equals("send") || project.status.text.Equals("processed_for_delivery"))
        statusIcon = "/pdfFiller;component/Resources/Images/Statuses/status_scheduled.png";
      else if (project.status.text.Equals("rejected"))
        statusIcon = "/pdfFiller;component/Resources/Images/Statuses/status_rejected.png";
      else if (project.status.text.Equals("in_local_area"))
        statusIcon = "/pdfFiller;component/Resources/Images/Statuses/status_in_local_area.png";
      else if (project.status.text.Equals("in_transit"))
        statusIcon = "/pdfFiller;component/Resources/Images/Statuses/status_in_transit.png";
      else if (project.status.text.Equals("not_send"))
        statusIcon = "/pdfFiller;component/Resources/Images/Statuses/status_not_send.png";
      else if (project.status.text.Equals("re-routed"))
        statusIcon = "/pdfFiller;component/Resources/Images/Statuses/status_re_routed.png";
      else if (project.status.text.Equals("returned_to_sender"))
        statusIcon = "/pdfFiller;component/Resources/Images/Statuses/status_returned_to_sender.png";
    }
    return statusIcon;
  }

  public static string GetDocIcon(string type)
  {
    string docIcon = "/pdfFiller;component/Resources/Images/Projects/corrupted.png";
    if (type == null || type.ToUpper().Equals("PDF"))
      docIcon = "/pdfFiller;component/Resources/Images/Projects/pdf.png";
    else if (type.ToUpper().Equals("DOC") || type.ToUpper().Equals("DOCX") || type.ToUpper().Equals("RTF"))
      docIcon = "/pdfFiller;component/Resources/Images/Projects/word.png";
    else if (type.ToUpper().Equals("TXT"))
      docIcon = "/pdfFiller;component/Resources/Images/Projects/txt.png";
    else if (type.ToUpper().Equals("HTM"))
      docIcon = "/pdfFiller;component/Resources/Images/Projects/txt.png";
    else if (type.ToUpper().Equals("PPT") || type.ToUpper().Equals("PPTX"))
      docIcon = "/pdfFiller;component/Resources/Images/Projects/ppt.png";
    else if (type.ToUpper().Equals("XLS") || type.ToUpper().Equals("XLSX"))
      docIcon = "/pdfFiller;component/Resources/Images/Projects/excel.png";
    else if (type.ToUpper().Equals("JPEG") || type.ToUpper().Equals("JPG") || type.ToUpper().Equals("PNG"))
      docIcon = "/pdfFiller;component/Resources/Images/Projects/image.png";
    return docIcon;
  }
}
