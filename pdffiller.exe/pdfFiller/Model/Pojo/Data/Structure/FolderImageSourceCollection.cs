// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Pojo.Data.FolderImageSourceCollection
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Utils;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace pdfFiller.Model.Pojo.Data;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct FolderImageSourceCollection
{
  private static Dictionary<long, Tuple<string, string>> folderResources = new Dictionary<long, Tuple<string, string>>();

  static FolderImageSourceCollection()
  {
    FolderImageSourceCollection.folderResources.Add(-20L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_all_documents"), "/pdfFiller;component/Resources/Images/Folders/folder_all_documents.png"));
    FolderImageSourceCollection.folderResources.Add(0L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_unsorted"), "/pdfFiller;component/Resources/Images/Folders/folder_unsorted.png"));
    FolderImageSourceCollection.folderResources.Add(-14L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_encrypted"), "/pdfFiller;component/Resources/Images/Folders/folder_encrypted.png"));
    FolderImageSourceCollection.folderResources.Add(-60L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_templates"), "/pdfFiller;component/Resources/Images/Folders/folder_templates.png"));
    FolderImageSourceCollection.folderResources.Add(-1L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_email"), "/pdfFiller;component/Resources/Images/Folders/folder_email.png"));
    FolderImageSourceCollection.folderResources.Add(-11L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_faxes"), "/pdfFiller;component/Resources/Images/Folders/folder_faxes.png"));
    FolderImageSourceCollection.folderResources.Add(-15L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_l2f"), "/pdfFiller;component/Resources/Images/Folders/folder_l_2_f.png"));
    FolderImageSourceCollection.folderResources.Add(-9L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_email_outbox"), "/pdfFiller;component/Resources/Images/Folders/folder_email.png"));
    FolderImageSourceCollection.folderResources.Add(-10L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_faxes"), "/pdfFiller;component/Resources/Images/Folders/folder_faxes.png"));
    FolderImageSourceCollection.folderResources.Add(-7L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_share"), "/pdfFiller;component/Resources/Images/Folders/folder_shared_with_me.png"));
    FolderImageSourceCollection.folderResources.Add(-3L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_s2s"), "/pdfFiller;component/Resources/Images/Folders/folder_sign_request.png"));
    FolderImageSourceCollection.folderResources.Add(-17L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_l2f"), "/pdfFiller;component/Resources/Images/Folders/folder_l_2_f.png"));
    FolderImageSourceCollection.folderResources.Add(-2L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_shared_with_me"), "/pdfFiller;component/Resources/Images/Folders/folder_shared_with_me.png"));
    FolderImageSourceCollection.folderResources.Add(-4L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_signature_request"), "/pdfFiller;component/Resources/Images/Folders/folder_sign_request.png"));
    FolderImageSourceCollection.folderResources.Add(-35L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_usps"), "/pdfFiller;component/Resources/Images/Folders/folder_usps.png"));
    FolderImageSourceCollection.folderResources.Add(-33L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_dropbox"), "/pdfFiller;component/Resources/Images/Clouds/dropbox.png"));
    FolderImageSourceCollection.folderResources.Add(-34L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_google_drive"), "/pdfFiller;component/Resources/Images/Clouds/gdrive.png"));
    FolderImageSourceCollection.folderResources.Add(-36L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_box"), "/pdfFiller;component/Resources/Images/Clouds/box.png"));
    FolderImageSourceCollection.folderResources.Add(-37L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_one_drive"), "/pdfFiller;component/Resources/Images/Clouds/one_drive.png"));
    FolderImageSourceCollection.folderResources.Add(-12L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_suggested_documents"), "/pdfFiller;component/Resources/Images/Folders/folder_suggested_documents.png"));
    FolderImageSourceCollection.folderResources.Add(-38L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_smart_folders"), "/pdfFiller;component/Resources/Images/Folders/smart_folder.png"));
    FolderImageSourceCollection.folderResources.Add(-39L, new Tuple<string, string>(ResourcesUtils.GetStringResource("folder_notarize"), "/pdfFiller;component/Resources/Images/Folders/folder_notarize.png"));
  }

  public static Tuple<string, string> GetFolderResources(long id)
  {
    try
    {
      return FolderImageSourceCollection.folderResources[id];
    }
    catch (KeyNotFoundException ex)
    {
      return (Tuple<string, string>) null;
    }
  }
}
