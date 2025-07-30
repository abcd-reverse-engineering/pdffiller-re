// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.EmptyFolders.EmptyFolderCollection
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Utils;
using System;
using System.Collections.Generic;

#nullable disable
namespace pdfFiller.UI.EmptyFolders;

public static class EmptyFolderCollection
{
  private static Dictionary<long, Tuple<string, string>> collection = new Dictionary<long, Tuple<string, string>>();

  static EmptyFolderCollection()
  {
    EmptyFolderCollection.collection.Add(-20L, new Tuple<string, string>("/pdfFiller;component/Resources/Images/EmptyFolders/empty_all_documents.png", ResourcesUtils.GetStringResource("empty_all_documents_message")));
    EmptyFolderCollection.collection.Add(-100L, new Tuple<string, string>("/pdfFiller;component/Resources/Images/EmptyFolders/empty_trashbin.png", ResourcesUtils.GetStringResource("empty_trashbin_message")));
    EmptyFolderCollection.collection.Add(-10L, new Tuple<string, string>("/pdfFiller;component/Resources/Images/EmptyFolders/empty_fax.png", ResourcesUtils.GetStringResource("empty_outbox_fax_message")));
    EmptyFolderCollection.collection.Add(-11L, new Tuple<string, string>("/pdfFiller;component/Resources/Images/EmptyFolders/empty_fax.png", ResourcesUtils.GetStringResource("empty_inbox_fax_message")));
    EmptyFolderCollection.collection.Add(-4L, new Tuple<string, string>("/pdfFiller;component/Resources/Images/EmptyFolders/empty_s2s.png", ResourcesUtils.GetStringResource("empty_s2s_message")));
    EmptyFolderCollection.collection.Add(-3L, new Tuple<string, string>("/pdfFiller;component/Resources/Images/EmptyFolders/empty_s2s.png", ResourcesUtils.GetStringResource("empty_signature_requested_message")));
    EmptyFolderCollection.collection.Add(-17L, new Tuple<string, string>("/pdfFiller;component/Resources/Images/EmptyFolders/empty_l2f.png", ResourcesUtils.GetStringResource("empty_l2f_message")));
    EmptyFolderCollection.collection.Add(-15L, new Tuple<string, string>("/pdfFiller;component/Resources/Images/EmptyFolders/empty_l2f.png", ResourcesUtils.GetStringResource("empty_l2f_message")));
    EmptyFolderCollection.collection.Add(-9L, new Tuple<string, string>("/pdfFiller;component/Resources/Images/EmptyFolders/empty_email.png", ResourcesUtils.GetStringResource("empty_outbox_email_message")));
    EmptyFolderCollection.collection.Add(0L, new Tuple<string, string>("/pdfFiller;component/Resources/Images/EmptyFolders/empty_unsorted.png", ResourcesUtils.GetStringResource("empty_unsorted_message")));
    EmptyFolderCollection.collection.Add(-35L, new Tuple<string, string>("/pdfFiller;component/Resources/Images/EmptyFolders/empty_usps.png", ResourcesUtils.GetStringResource("empty_usps_message")));
    EmptyFolderCollection.collection.Add(-14L, new Tuple<string, string>("/pdfFiller;component/Resources/Images/EmptyFolders/empty_encrypted.png", ResourcesUtils.GetStringResource("empty_encrypted_message")));
    EmptyFolderCollection.collection.Add(-2L, new Tuple<string, string>("/pdfFiller;component/Resources/Images/EmptyFolders/empty_share.png", ResourcesUtils.GetStringResource("empty_shared_with_me_message")));
    EmptyFolderCollection.collection.Add(-7L, new Tuple<string, string>("/pdfFiller;component/Resources/Images/EmptyFolders/empty_share.png", ResourcesUtils.GetStringResource("empty_share_message")));
    EmptyFolderCollection.collection.Add(-33L, new Tuple<string, string>("/pdfFiller;component/Resources/Images/Clouds/dropbox.png", ResourcesUtils.GetStringResource("empty_cloud_folder_message").Replace("%s", "Dropbox")));
    EmptyFolderCollection.collection.Add(-36L, new Tuple<string, string>("/pdfFiller;component/Resources/Images/Clouds/box.png", ResourcesUtils.GetStringResource("empty_cloud_folder_message").Replace("%s", "Box")));
    EmptyFolderCollection.collection.Add(-34L, new Tuple<string, string>("/pdfFiller;component/Resources/Images/Clouds/gdrive.png", ResourcesUtils.GetStringResource("empty_cloud_folder_message").Replace("%s", "Google Drive")));
    EmptyFolderCollection.collection.Add(-37L, new Tuple<string, string>("/pdfFiller;component/Resources/Images/Clouds/one_drive.png", ResourcesUtils.GetStringResource("empty_cloud_folder_message").Replace("%s", "OneDrive")));
    EmptyFolderCollection.collection.Add(-60L, new Tuple<string, string>("/pdfFiller;component/Resources/Images/Folders/folder_templates.png", ResourcesUtils.GetStringResource("empty_templates_message")));
  }

  public static Tuple<string, string> GetEmptyData(long folderId)
  {
    try
    {
      return EmptyFolderCollection.collection[folderId];
    }
    catch (KeyNotFoundException ex)
    {
      return (Tuple<string, string>) null;
    }
  }
}
