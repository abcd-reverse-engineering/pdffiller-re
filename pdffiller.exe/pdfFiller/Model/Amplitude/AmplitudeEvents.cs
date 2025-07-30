// Decompiled with JetBrains decompiler
// Type: pdfFiller.Model.Amplitude.AmplitudeEvents
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.Runtime.InteropServices;

#nullable disable
namespace pdfFiller.Model.Amplitude;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct AmplitudeEvents
{
  [StructLayout(LayoutKind.Sequential, Size = 1)]
  public struct UserProperties
  {
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct UserPropertiesLocalisationProperty
    {
      public const string name = "Localisation";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct UserPropertiesBiometricProperty
    {
      public const string name = "Biometric";

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct UserPropertiesBiometricValue
      {
        public const string ON = "on";
        public const string OFF = "off";
      }
    }
  }

  [StructLayout(LayoutKind.Sequential, Size = 1)]
  public struct AppFlow
  {
    public const string FIRST_OPEN = "First Open";
    public const string FORGOT_PASSWORD_FLOW_LAUNCHED = "Forgot Password Flow Launched";
    public const string SORTING_COMPLETED = "Sorting Completed";

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct Tabs
    {
      public const string CLOUD_TAB_OPENED = "Cloud Tab Opened";
      public const string INBOX_TAB_OPENED = "Inbox Tab Opened";
      public const string OUTBOX_TAB_OPENED = "Outbox Tab Opened";
      public const string TRASH_BIN_OPENED = "Trash Bin Opened";
      public const string INTERNAL_DOC_SEARCHED = "Internal Doc Searched";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct Editor
    {
      public const string EDITOR_OPENED = "Editor Opened";
      public const string EDITOR_CLOSED = "Editor Closed";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct AddDocument
    {
      public const string DOCUMENT_ADDED = "Document Added";
      public const string ADD_DOCUMENT_CLICKED = "Add Document Clicked";

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct AddDocumentProperty
      {
        public const string name = "add_type";

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct AddDocumentValue
        {
          public const string UPLOAD = "upload";
          public const string SEARCH = "search";
        }
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct PricingFlow
    {
      public const string PAYWALL_SHOWN = "Flow Paywall Shown";
      public const string PAYWALL_CLOSED = "close_pricing_screen";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct Auth
    {
      public const string USER_REGISTERED = "User Registered";
      public const string USER_LOGGED_IN = "User Logged In";
      public const string USER_LOGGED_OUT = "User Logged Out";

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct AuthProperty
      {
        public const string name = "auth_type";

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct AuthValue
        {
          public const string FACEBOOK = "FB";
          public const string EMAIL = "Email";
        }
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct Export
    {
      public const string DOCUMENT_ACTION_CLICKED = "Document Action Clicked";
      public const string DOCUMENT_ACTION_COMPLETED = "Document Action Completed";

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct ExportActionProperty
      {
        public const string name = "action_type";
        public const string OPEN = "open";
        public const string SAVE_AS = "save_as";
        public const string RENAME = "rename";
        public const string DELETE = "delete";
        public const string CONVERT_TO_TEMPLATE = "convert_to_template";
        public const string REVERT_FROM_TEMPLATE = "revert_from_template";
        public const string CREATE_FROM_TEMPLATE = "create_from_template";
        public const string TRASH_BIN_PUT_BACK = "TRASH_BIN_PUT_BACK";
        public const string TRASH_BIN_DELETE = "TRASH_BIN_DELETE";
        public const string ADD_TO_MY_FORMS = "ADD_TO_MY_FORMS";
      }

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct ExportFormatProperty
      {
        public const string name = "doc_format";

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct ExportFormatValue
        {
          public const string PDF = "pdf";
          public const string DOCX = "docx";
          public const string PPTX = "pptx";
          public const string XLS = "xls";
        }
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct Settings
    {
      public const string BIOMETRIC_USED = "Biometric Used";

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct SwitcherStateProperty
      {
        public const string name = "switcher";

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct SwitcherStateValue
        {
          public const string on = "on";
          public const string off = "off";
        }
      }
    }
  }
}
