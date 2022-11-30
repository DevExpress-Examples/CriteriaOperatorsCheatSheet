using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using dxTestSolutionXPO.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;

namespace dxTestSolutionXPO {
    class Program {
        static void Main(string[] args) {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            MakeInitialData();
            //var tester = new Tester();
            //tester.AggregateOperandAvg_PlainCollection_1();
            //tester.AggregateOperandAvg_PlainCollection_2();
            //tester.AggregateOperandAvg_PlainCollection_3();
            //tester.AggregateOperandAvg_PlainCollection_Crit_1();
            //tester.AggregateOperandAvg_PlainCollection_Crit_2();
            //tester.AggregateOperandAvg_PlainCollection_Crit_3();
            var session = new Session();
            var lst = new XPCollection<OrderItem>(session);
            var cnt = lst.Count;
            var c = new XPCollection<Order>(session)[0].OrderItems.ToList();
        }


    public    static void MakeInitialData() {
            var session = new Session();
            var c = new XPCollection<Order>(session).Count;
            if (c > 0) {
                return;
            }
            for (int i = 0; i < 10; i++) {
                string contactName = "FirstName" + i;
                var contact = CreateObject<Order>("FirstName", contactName, session);
                contact.LastName = "LastName" + i;
                contact.Price = i * 10;
                contact.IsActive = i % 2 == 0;
                for (int j = 0; j < 5; j++) {
                    string taskName = "Subject" + i + " - " + j;
                    var task = CreateObject<OrderItem>("Subject", taskName, session);
                    task.Order = contact;
                    task.ItemPrice = i * 100;
                    task.Save();
                }
                contact.Save();
            }

        }
        static T CreateObject<T>(string propertyName, string value, Session session) {

            T theObject = session.FindObject<T>(new OperandProperty(propertyName) == value);
            if (theObject == null) {
                theObject = (T)Activator.CreateInstance(typeof(T), new object[] { session });
                ((XPCustomObject)(object)theObject).SetMemberValue(propertyName, value);
            }

            return theObject;

        }
    }
}
