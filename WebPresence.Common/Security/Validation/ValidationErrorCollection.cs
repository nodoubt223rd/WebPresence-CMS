﻿using System;
using System.Collections.ObjectModel;

namespace WebPresence.Common.Security.Validation
{
    public class ValidationErrorCollection : Collection<ValidationError>
    {
        public void Add(string name, object attemptedValue, string message)
        {
            Add(new ValidationError(name, attemptedValue, message));
        }

        public void Add(string name, object attemptedValue, Exception exception)
        {
            Add(new ValidationError(name, attemptedValue, exception));
        }
    }
}
