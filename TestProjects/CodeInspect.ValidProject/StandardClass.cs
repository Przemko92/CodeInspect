using System;
using CodeInspect.Attributes;

namespace CodeInspect.ValidProject
{
    public class StandardClass
    {
        private int _privateField;
        protected string _protectedField;
        [CodeInspectIgnore]
        public string PublicIgnoredFieldWithVeryLongName;

        private static int privateStaticField;
        [CodeInspectIgnore]
        protected static int protectedIgnoredStaticField;

        [CodeInspectIgnore]
        private string a;

        public string Property { get; }

        public void PublicMethod()
        {

        }

        [CodeInspectIgnore]
        public void PublicMethodWithALotOfArgs(int a, string b, int AAA, string z, string y, string pp, long aa, string ee)
        {

        }

        [CodeInspectIgnore]
        private void IgnoredVoidPrivateMethod()
        {

        }

        private string ReturnTypePrivateMethod()
        {
            return string.Empty;
        }
    }
}
