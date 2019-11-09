using System;
using System.Collections.Generic;
using System.Text;

namespace CodeInspect.Models.Exceptions
{
    class MethodsValidationException : Exception
    {
        private InspectionResult Result { get; }

        public MethodsValidationException(InspectionResult result)
        {
            this.Result = result;
        }
    }
}
