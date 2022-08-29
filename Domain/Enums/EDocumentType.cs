using System.ComponentModel;

namespace Domain.Enums
{
  public enum EDocumentType
  {
    [Description("CPF")]
    CPF = 1,
    [Description("PIS")]
    PIS = 2,
    [Description("CNPJ")]
    CNPJ = 3
  }
}
