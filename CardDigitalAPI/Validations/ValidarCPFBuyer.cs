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
                if(cpf.Distinct().Count() == 1)
                {
                    return new ValidationResult("CPF inválido.");
                }

                int somaPrimeiroVerificadorCPF = 0;
                int multiplicadorCPF = 1;

                for (int i = 0; i < cpf.Length - 2; i++)
                {
                    somaPrimeiroVerificadorCPF += (int.Parse(cpf[i].ToString()) * multiplicadorCPF);
                    multiplicadorCPF++;
                }

                double primeiroDigitoCPF = somaPrimeiroVerificadorCPF % 11;

                int somaSegundoVerificadorCPF = 0;
                multiplicadorCPF = 0;

                for (int i = 0; i < cpf.Length - 1; i++)
                {
                    somaSegundoVerificadorCPF += (int.Parse(cpf[i].ToString()) * multiplicadorCPF);
                    multiplicadorCPF++;
                }

                double segundoDigitoCPF = somaSegundoVerificadorCPF % 11;

                primeiroDigitoCPF = primeiroDigitoCPF == 10 ? 0 : primeiroDigitoCPF;
                segundoDigitoCPF = segundoDigitoCPF == 10 ? 0 : segundoDigitoCPF;

                //caclulo asciiCode 
                // Código ASCII 0 = 48
                bool cpfValido = (cpf[9] - '0' == primeiroDigitoCPF) && (cpf[10] - '0' == segundoDigitoCPF);

                if (cpfValido)
                {
                    value = cpf;
                    return ValidationResult.Success;

                }

            }
            return new ValidationResult("CPF não é valido");
        }
    }
}
