using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using dxTestSolutionXPO.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxTestSolutionXPO.Module.BusinessObjects {
    public class FreeOrderItem: XPObject {
        public FreeOrderItem(Session session) : base(session) {

        }
        string freeOrderName;
        Order _order;

        public Order Order {
            get {
                return _order;
            }
            set {
                SetPropertyValue(nameof(Order), ref _order, value);
            }
        }
        int _itemPrice;

     


        public int ItemPrice {
            get {
                return _itemPrice;
            }
            set {
                SetPropertyValue(nameof(ItemPrice), ref _itemPrice, value);
            }
        }

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string FreeOrderName {
            get => freeOrderName;
            set => SetPropertyValue(nameof(FreeOrderName), ref freeOrderName, value);
        }
    }
}
