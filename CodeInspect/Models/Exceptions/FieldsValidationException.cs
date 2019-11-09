using System;
using System.Collections.Generic;
using System.Text;

namespace CodeInspect.Models.Exceptions
{
    public class FieldsValidationException : Exception
    {
        private InspectionResult Result { get; }

        public FieldsValidationException(InspectionResult result)
        {
            this.Result = result;
        }
    }
}
