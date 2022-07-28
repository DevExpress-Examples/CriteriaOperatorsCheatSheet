using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using System.Diagnostics;

namespace dxTestSolutionXPO.Module.BusinessObjects {
   [DebuggerDisplay("FirstName: {OrderName}")]
    public class Order : XPObject { 
        public Order(Session session)
            : base(session) {
        }
        public override void AfterConstruction() {
            base.AfterConstruction();
        }
        string defaultCompanyName;
        DateTime orderDate;
        string orderColor;
        string orderType;
        string description;
        string _orderName;
        public string OrderName {
            get {
                return _orderName;
            }
            set {
                SetPropertyValue(nameof(OrderName), ref _orderName, value);
            }
        }
        string lastName;
        public string LastName {
            get {
                return lastName;
            }
            set {
                SetPropertyValue(nameof(LastName), ref lastName, value);
            }
        }
        int _price;
        public int Price {
            get {
                return _price;
            }
            set {
                SetPropertyValue(nameof(Price), ref _price, value);
            }
        }

        bool isActive;
        public bool IsActive {
            get {
                return isActive;
            }
            set {
                SetPropertyValue("IsActive", ref isActive, value);
            }
        }


        public DateTime OrderDate {
            get => orderDate;
            set => SetPropertyValue(nameof(OrderDate), ref orderDate, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Description {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }

        // DateTime _birthDate;
        // public DateTime BirthDate {
        // get {
        // return _birthDate;
        // }
        // set {
        // SetPropertyValue(nameof(BirthDate), ref _birthDate, value);
        // }
        // }	
        //[EditorAlias(EditorAliases.RichTextPropertyEditor)]
        //public byte[] Text { get; set; }		
        [Association]
        public XPCollection<OrderItem> OrderItems {
            get {
                return GetCollection<OrderItem>(nameof(OrderItems));
            }
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string OrderType {
            get => orderType;
            set => SetPropertyValue(nameof(OrderType), ref orderType, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string OrderColor {
            get => orderColor;
            set => SetPropertyValue(nameof(OrderColor), ref orderColor, value);
        }

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string DefaultCompanyName {
            get => defaultCompanyName;
            set => SetPropertyValue(nameof(DefaultCompanyName), ref defaultCompanyName, value);
        }

    }
}