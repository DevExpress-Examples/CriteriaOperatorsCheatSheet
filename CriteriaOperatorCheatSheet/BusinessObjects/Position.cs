using DevExpress.Xpo;
using System;
using System.Linq;

namespace dxTestSolutionXPO.Module.BusinessObjects {
    public class Position : XPObject {
        public Position(Session session) : base(session) {
        }


        int positionPrice;
        string positionName;
        OrderItem _order;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string PositionName {
            get => positionName;
            set => SetPropertyValue(nameof(PositionName), ref positionName, value);
        }

        
        public int PositionCount {
            get => positionPrice;
            set => SetPropertyValue(nameof(PositionCount), ref positionPrice, value);
        }
        [Association]
        public OrderItem ParentOrderItem {
            get {
                return _order;
            }
            set {
                SetPropertyValue(nameof(Order), ref _order, value);
            }
        }
    }
}
