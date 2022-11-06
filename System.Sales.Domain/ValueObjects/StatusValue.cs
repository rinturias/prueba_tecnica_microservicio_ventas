
using Sharedkernel.Core;

namespace System.Sales.Domain.ValueObjects
{
    public record StatusValue : ValueObject
    {
        public string Value { get; }
        public StatusValue(string value)
        {

            if (value == "")
            {
                throw new BussinessRuleValidationException("El estado no puede registrarse sin dato");
            }
            if (value.Length > 1)
            {
                throw new BussinessRuleValidationException("El estado solo puede tener un caracter");
            }

            Value = value;

        }

        public static implicit operator string(StatusValue value)
        {
            return value.Value;
        }

        public static implicit operator StatusValue(string value)
        {
            return new StatusValue(value);
        }
    }
}
