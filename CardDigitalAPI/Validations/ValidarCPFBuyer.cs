using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CardDigitalAPI.Validations
{
    public class ValidarCPFBuyer : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            string regexCPF = @"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$";



            if (value is string cpf && Regex.IsMatch(cpf, regexCPF))
            {
                if (cpf.Contains(".") || cpf.Contains("-"))
                {
                    cpf = cpf.Replace(".", "").Replace("-", "");
                }

                int somaPrimeiroVerificadorCPF = 0;
                int multiplicadorCPF = 1;

                for (int i = 0; i < cpf.Length - 2; i++)
                {
                    somaPrimeiroVerificadorCPF += (int)cpf[i] * multiplicadorCPF;
                    multiplicadorCPF++;
                }

                double primeiroDigitoCPF = somaPrimeiroVerificadorCPF % 11;

                int somaSegundoVerificadorCPF = 0;
                multiplicadorCPF = 0;

                for (int i = 0; i < cpf.Length - 1; i++)
                {
                    somaSegundoVerificadorCPF += (int)cpf[i] * multiplicadorCPF;
                    multiplicadorCPF++;
                }

                double segundoDigitoCPF = somaSegundoVerificadorCPF % 11;

                if (cpf[9] == primeiroDigitoCPF && cpf[10] == segundoDigitoCPF)
                {
                    return ValidationResult.Success;
                }

            }
            return new ValidationResult("CPF não é valido");
        }
    }
}
