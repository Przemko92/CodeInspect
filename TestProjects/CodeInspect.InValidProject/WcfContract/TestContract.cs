using System.Runtime.Serialization;

namespace CodeInspect.InValidProject.WcfContract
{
    
    public class TestContract : ContractBase
    {
        public TestContract()
        {

        }

        public TestContract(int param1)
        {

        }

        [DataMember]
        public string Property1 { get; set; }

        [DataMember]
        public string Property2 { get; set; }

        [DataMember]
        public string Property3 { get; set; }
        
        public string NoDataMemberProperty { get; set; }
    }
}
