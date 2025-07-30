// Decompiled with JetBrains decompiler
// Type: pdfFiller.Properties.Resources
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace pdfFiller.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Resources
{
  private static ResourceManager resourceMan;
  private static CultureInfo resourceCulture;

  internal Resources()
  {
  }

  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal static ResourceManager ResourceManager
  {
    get
    {
      if (pdfFiller.Properties.Resources.resourceMan == null)
        pdfFiller.Properties.Resources.resourceMan = new ResourceManager("pdfFiller.Properties.Resources", typeof (pdfFiller.Properties.Resources).Assembly);
      return pdfFiller.Properties.Resources.resourceMan;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal static CultureInfo Culture
  {
    get => pdfFiller.Properties.Resources.resourceCulture;
    set => pdfFiller.Properties.Resources.resourceCulture = value;
  }
}
