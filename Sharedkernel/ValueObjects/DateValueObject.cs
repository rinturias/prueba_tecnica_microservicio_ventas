using Sharedkernel.Core;
using System.Diagnostics.CodeAnalysis;

namespace Sharedkernel.ValueObjects
{
    [ExcludeFromCodeCoverage]
    public record DateValueObject
    {
        public DateTime Value { get; }
        public DateValueObject(DateTime date_time)
        {
            //   var value = new DateTime(y);

            if (!IsValid(date_time))
            {
                throw new BussinessRuleValidationException("DATE NOT VALIDE");
            }
        }

        public static implicit operator DateTime(DateValueObject value)
        {
            return value.Value;
        }

        public static implicit operator DateValueObject(DateTime value)
        {
            return new DateValueObject(value);
        }

        public static bool IsValid(DateTime date)
        {
            if (new DateTime() == date)
                return false;
            else
                return true;

        }
    }
}
