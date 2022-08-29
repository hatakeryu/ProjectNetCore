using Domain.Enums;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
  public class Document
  {
    public Document(EDocumentType typeDocument, string documentNumber, DateTime? creationDate, DateTime? expirationDate)
    {
      TypeDocument = typeDocument;
      DocumentNumber = documentNumber;
      CreationDate = creationDate;
      ExpirationDate = expirationDate;
    }

    private Document() { }

    public long Id { get; set; }
    public long PersonId { get; set; }
    [JsonIgnore]
    public Person? Person { get; set; }
    public EDocumentType TypeDocument { get; private set; }
    public string DocumentNumber { get; private set; }
    public DateTime? CreationDate { get; private set; }
    public DateTime? ExpirationDate { get; private set; }


    public static bool ValidateDocument(Document document)
    {
      switch (document.TypeDocument)
      {
        case EDocumentType.CPF:
          return ValidCpf(document.DocumentNumber);
        case EDocumentType.PIS:
          return ValidPis(document.DocumentNumber);
        case EDocumentType.CNPJ:
          return ValidCnpj(document.DocumentNumber);
        default:
          break;
      }

      return true;
    }

    public static bool ValidCpf(string cpf)
    {
      int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
      int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
      string tempCpf;
      string digito;
      int soma;
      int resto;
      cpf = cpf.Trim();
      cpf = cpf.Replace(".", "").Replace("-", "");
      if (cpf.Length != 11)
        return false;
      tempCpf = cpf.Substring(0, 9);
      soma = 0;

      for (int i = 0; i < 9; i++)
        soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
      resto = soma % 11;
      if (resto < 2)
        resto = 0;
      else
        resto = 11 - resto;
      digito = resto.ToString();
      tempCpf = tempCpf + digito;
      soma = 0;
      for (int i = 0; i < 10; i++)
        soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
      resto = soma % 11;
      if (resto < 2)
        resto = 0;
      else
        resto = 11 - resto;
      digito = digito + resto.ToString();
      return cpf.EndsWith(digito);
    }

    public static bool ValidCnpj(string cnpj)
    {
      int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
      int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
      int soma;
      int resto;
      string digito;
      string tempCnpj;
      cnpj = cnpj.Trim();
      cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
      if (cnpj.Length != 14)
        return false;
      tempCnpj = cnpj.Substring(0, 12);
      soma = 0;
      for (int i = 0; i < 12; i++)
        soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
      resto = (soma % 11);
      if (resto < 2)
        resto = 0;
      else
        resto = 11 - resto;
      digito = resto.ToString();
      tempCnpj = tempCnpj + digito;
      soma = 0;
      for (int i = 0; i < 13; i++)
        soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
      resto = (soma % 11);
      if (resto < 2)
        resto = 0;
      else
        resto = 11 - resto;
      digito = digito + resto.ToString();
      return cnpj.EndsWith(digito);
    }

    public static bool ValidPis(string pis)
    {
      int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
      int soma;
      int resto;
      if (pis.Trim().Length != 11)
        return false;
      pis = pis.Trim();
      pis = pis.Replace("-", "").Replace(".", "").PadLeft(11, '0');

      soma = 0;
      for (int i = 0; i < 10; i++)
        soma += int.Parse(pis[i].ToString()) * multiplicador[i];
      resto = soma % 11;
      if (resto < 2)
        resto = 0;
      else
        resto = 11 - resto;
      return pis.EndsWith(resto.ToString());
    }
  }
}
