﻿using Sharedkernel.Core;
using System.Diagnostics.CodeAnalysis;

namespace Sharedkernel.Rules
{
    [ExcludeFromCodeCoverage]
    public class NotNullRule : IBussinessRule
    {
        private readonly object _value;

        public NotNullRule(object value)
        {
            _value = value;
        }

        public string Message => "Object cannot be null";

        public bool IsValid()
        {
            return _value != null;
        }
    }
}
