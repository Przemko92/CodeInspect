using System;
using CodeInspect.Attributes;

namespace CodeInspect.ValidProject.AnotherNamespace
{
    public class AnotherNamespaceClass
    {
        private int _privateField;
        protected string _protectedField;
        [CodeInspectIgnore]
        public string PublicIgnoredFieldWithVeryLongName;

        private static int privateStaticField;
        [CodeInspectIgnore]
        protected static int protectedIgnoredStaticField;

        public void PublicMethod()
        {

        }

        [CodeInspectIgnore]
        public void PublicMethodWithALotOfArgs(int a, string b, int AAA, string z, string y, string pp, long aa, string ee)
        {

        }

        private string ReturnTypePrivateMethod()
        {
            return string.Empty;
        }
    }
}
