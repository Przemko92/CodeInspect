using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using CodeInspect.Attributes;

namespace CodeInspect.ValidProject.WcfContract
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
        
        [CodeInspectIgnore]
        public string NoDataMemberProperty { get; set; }
    }
}
