using System;
using System.Collections.Generic;
using System.Text;

namespace CodeInspect.Models.Exceptions
{
    public class ItemsValidationException : Exception
    {
        private InspectionResult Result { get; }

        public ItemsValidationException(InspectionResult result)
        {
            this.Result = result;
        }
    }
}
