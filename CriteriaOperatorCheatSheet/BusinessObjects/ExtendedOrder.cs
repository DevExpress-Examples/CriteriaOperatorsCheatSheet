using DevExpress.Xpo;
using dxTestSolutionXPO.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxTestSolutionXPO.Module.BusinessObjects {
    public class ExtendedOrder:Order {
        public ExtendedOrder(Session session) : base(session) {

        }


        string extendedString;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ExtendedDescription {
            get => extendedString;
            set => SetPropertyValue(nameof(ExtendedDescription), ref extendedString, value);
        }
    }
}
