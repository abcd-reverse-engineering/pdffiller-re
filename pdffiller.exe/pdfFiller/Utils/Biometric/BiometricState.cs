// Decompiled with JetBrains decompiler
// Type: pdfFiller.Utils.Biometric.BiometricState
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

#nullable disable
namespace pdfFiller.Utils.Biometric;

public class BiometricState
{
  public const int DISABLED = 1;
  public const int PASSED = 2;
  public const int FAILED = 3;
  public int state;
  public string message;

  public BiometricState(int state, string message)
  {
    this.state = state;
    this.message = message;
  }

  public BiometricState(int state) => this.state = state;
}
