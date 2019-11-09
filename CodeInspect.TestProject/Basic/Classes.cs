namespace CodeInspect.TestProject.Basic
{
    public class Class1 : Interface1
    {
        private int _privateField;
        protected int _protectedField;
        internal int _internalField;
        public int _publicField;

        public void Method1()
        {

        }

        public bool Method2()
        {
            return default(bool);
        }

        public void Method3(int arg)
        {

        }

        public bool Method4(int arg)
        {
            return default(bool);
        }

        public bool Method5(int Arg)
        {
            return default(bool);
        }

        private static void Method6()
        {

        }

        private static string Method7()
        {
            return default(string);
        }
    }

    public abstract class Class2
    {
        public string GetSetProperty { get; set; }
        public string OnlyGetProperty { get; }
        private string PrivateOnlyGetProperty { get; }
        public string PrivateSetProperty { get; private set; }
        public string PrivateGetProperty { private get; set; }
        public string ProtectedSetProperty { get; protected set; }
        public string InternalGetProperty { internal get; set; }

        public void Test()
        {

        }

        public void get_MyTest()
        {

        }
    }
}
