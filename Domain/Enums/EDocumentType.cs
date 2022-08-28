using System.ComponentModel;

namespace Domain.Enums
{
  public enum EDocumentType
  {
    [Description("CPF")]
    CPF = 1,
    [Description("RG")]
    RG = 2,
    [Description("CNPJ")]
    CNPJ = 3
  }
}
