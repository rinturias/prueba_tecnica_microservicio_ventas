﻿
using Sharedkernel.Core;

namespace System.Sales.Domain.ValueObjects
{
    public record CantidadValue : ValueObject
    {
        public int Value { get; }
        public CantidadValue(int value)
        {
            if (value < 0)
            {
                throw new BussinessRuleValidationException("La cantidad no puede ser negativa o cero");
            }
            Value = value;
        }

        public static implicit operator int(CantidadValue value)
        {
            return value.Value;
        }

        public static implicit operator CantidadValue(int value)
        {
            return new CantidadValue(value);
        }
    }
}
