using System;
using System.ComponentModel.DataAnnotations;

public class AnoMaximoAttribute : ValidationAttribute
{
    public AnoMaximoAttribute() : base("O ano do carro deve ser no máximo dois anos acima do ano atual.")
    {
    }

    public override bool IsValid(object value)
    {
        if (value is int intValue)
        {
            return intValue <= DateTime.Now.Year + 2;
        }
        return false;
    }
}
