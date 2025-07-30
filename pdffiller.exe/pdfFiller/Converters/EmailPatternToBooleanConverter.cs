// Decompiled with JetBrains decompiler
// Type: pdfFiller.Converters.EmailPatternToBooleanConverter
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.Utils.Validators;

#nullable disable
namespace pdfFiller.Converters;

public class EmailPatternToBooleanConverter : StringPatternToBooleanConverter
{
  private ValidationRulesCollection.EmailFieldValidationRule validationRule = new ValidationRulesCollection.EmailFieldValidationRule();

  protected override bool IsDataCorrect(string data) => this.validationRule.checkRule(data);
}
