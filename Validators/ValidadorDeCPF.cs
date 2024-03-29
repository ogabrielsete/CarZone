﻿namespace CarZone.Validators
{
    public class ValidadorDeCPF
    {
        public bool ValidarCPF(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", ""); 

            if (cpf.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais (caso contrário, é um CPF inválido)
            if (new string(cpf[0], 11) == cpf)
                return false;

            // Calcula o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * (10 - i);

            int resto = soma % 11;
            int digitoVerificador1 = (resto < 2) ? 0 : 11 - resto;

            // Verifica se o primeiro dígito verificador está correto
            if (int.Parse(cpf[9].ToString()) != digitoVerificador1)
                return false;

            // Calcula o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * (11 - i);

            resto = soma % 11;
            int digitoVerificador2 = (resto < 2) ? 0 : 11 - resto;

            // Verifica se o segundo dígito verificador está correto
            if (int.Parse(cpf[10].ToString()) != digitoVerificador2)
                return false;

            return true; 
        }

    }
}
