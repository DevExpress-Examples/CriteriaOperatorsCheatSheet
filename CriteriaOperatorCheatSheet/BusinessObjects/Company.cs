using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxTestSolutionXPO.Module.BusinessObjects {
    public class Company: XPObject {


        public Company(Session session) : base(session) {

        }


        string companyName;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CompanyName {
            get => companyName;
            set => SetPropertyValue(nameof(CompanyName), ref companyName, value);
        }
    }
}
