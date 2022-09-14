using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriteriaOperatorCheatSheetXAF.Module.BusinessObjects {
    public class Department: BaseObject {
        public Department(Session session) : base(session) {

        }


        string departmentName;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string DepartmentName {
            get => departmentName;
            set => SetPropertyValue(nameof(DepartmentName), ref departmentName, value);
        }

    }
}
