namespace CodeInspect.InValidProject
{
    public class StandardClass
    {
        private int _privateField;
        protected string _protectedField;
        public string PublicFieldWithVeryVeryVeryLongName;

        private static int privateStaticField;
        protected static int protectedStaticField;

        private string a;

        public string Property { get; }

        public void PublicMethod()
        {

        }

        public void PublicMethodWithALotOfArgs(int a, string b, int AAA, string z, string y, string pp, long aa, string ee)
        {

        }

        private void IgnoredVoidPrivateMethod()
        {

        }

        private string ReturnTypePrivateMethod()
        {
            return string.Empty;
        }
    }
}
