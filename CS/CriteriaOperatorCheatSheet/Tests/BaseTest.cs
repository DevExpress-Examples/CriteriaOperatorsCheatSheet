﻿using DevExpress.Xpo;
using dxTestSolutionXPO.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxTestSolutionXPO.Tests {
    public class BaseTest {
        public void PopulatePlainCollection() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            ConnectionHelper.AddOrder(uow, "FirstName0", 10);
            ConnectionHelper.AddOrder(uow, "FirstName1", 20);
            uow.CommitChanges();
        }
        public void PopulatePlainCollectionForConcat() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            ConnectionHelper.AddOrder(uow, "TestValue", 10);
            ConnectionHelper.AddOrder(uow, "FirstName1", 20);
            uow.CommitChanges();
        }
        public void PopulateForNumeric() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            ConnectionHelper.AddOrder(uow, "Order1", 3);
            ConnectionHelper.AddOrder(uow, "Order2", 11);
            ConnectionHelper.AddOrder(uow, "Order3", -15);

            uow.CommitChanges();
        }
        public void PopulateForDates() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            ConnectionHelper.AddOrder(uow, "Order11", new DateTime(2022, 2, 10));
            ConnectionHelper.AddOrder(uow, "Order22", new DateTime(2022, 3, 10));
            ConnectionHelper.AddOrder(uow, "Order33", new DateTime(2022, 4, 10));

            uow.CommitChanges();
        }
        public void PopulateForDates_AddMilliseconds() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            ConnectionHelper.AddOrder(uow, "Order11", new DateTime(2022, 2, 10));
            ConnectionHelper.AddOrder(uow, "Order22", new DateTime(2022, 3, 10));
            uow.CommitChanges();
        }
        public void PopulateСollectionWithActive() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            ConnectionHelper.AddOrder(uow, "FirstName0", 10, false);
            ConnectionHelper.AddOrder(uow, "FirstName0", 20, false);
            ConnectionHelper.AddOrder(uow, "FirstName0", 30, true);
            ConnectionHelper.AddOrder(uow, "FirstName0", 40, true);
            ConnectionHelper.AddOrder(uow, "FirstName0", 50, true);
            uow.CommitChanges();
        }

        public void PopulateSelectFromCollection() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var c0 = ConnectionHelper.AddOrder(uow, "FirstName0");
            var t00 = ConnectionHelper.AddOrderItem(uow, c0, "Task0-0", 10);
            var t01 = ConnectionHelper.AddOrderItem(uow, c0, "Task0-1", 20);
            var c1 = ConnectionHelper.AddOrder(uow, "FirstName1");
            var t10 = ConnectionHelper.AddOrderItem(uow, c1, "Task1-0", 100);
            var t11 = ConnectionHelper.AddOrderItem(uow, c1, "Task1-1", 200);

            var c2 = ConnectionHelper.AddOrder(uow, "FirstName2");
            var t20 = ConnectionHelper.AddOrderItem(uow, c2, "Task2-0", 30);
            var t21 = ConnectionHelper.AddOrderItem(uow, c2, "Task2-1", 40, 55);
            var c3 = ConnectionHelper.AddOrder(uow, "FirstName3");
            var t30 = ConnectionHelper.AddOrderItem(uow, c3, "Task3-0", 300);
            var t31 = ConnectionHelper.AddOrderItem(uow, c3, "Task3-1", 400);
            uow.CommitChanges();
        }
        public void PopulateSelectFromCollectionForCount() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var c0 = ConnectionHelper.AddOrder(uow, "FirstName0");
            var t00 = ConnectionHelper.AddOrderItem(uow, c0, "Task0-0", 10);
            var c1 = ConnectionHelper.AddOrder(uow, "FirstName1");
            var c2 = ConnectionHelper.AddOrder(uow, "FirstName2");
            var t20 = ConnectionHelper.AddOrderItem(uow, c2, "Task2-0", 10);
            var t21 = ConnectionHelper.AddOrderItem(uow, c2, "Task2-0", 20);
            uow.CommitChanges();
        }
        public void PopulateSimpleCollectionForMaxMin() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var c0 = ConnectionHelper.AddOrder(uow, "FirstName0", 44);
            var t00 = ConnectionHelper.AddOrderItem(uow, c0, "Item0-1", 10, false);
            var t01 = ConnectionHelper.AddOrderItem(uow, c0, "Item0-1", 20, true);
            var t02 = ConnectionHelper.AddOrderItem(uow, c0, "Item0-1", 30, true);
            var t03 = ConnectionHelper.AddOrderItem(uow, c0, "Item0-1", 40, false);
            uow.CommitChanges();
        }
        public void PopulateForComplex() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var c0 = ConnectionHelper.AddOrder(uow, "Order0", 44);
            var t00 = ConnectionHelper.AddOrderItem(uow, c0, "Item0-1", 10, false);
            var t01 = ConnectionHelper.AddOrderItem(uow, c0, "Item0-2", 20, true);
            var c1 = ConnectionHelper.AddOrder(uow, "Order1", 55);
            var t10 = ConnectionHelper.AddOrderItem(uow, c1, "Item1-1", 10, false);
            var t11 = ConnectionHelper.AddOrderItem(uow, c1, "Item1-2", 20, true);
            t11.Company = new Company(uow);
            t11.Company.CompanyName = "Company1";
            uow.CommitChanges();
        }
        public void PopulateForEscaping() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var c0 = ConnectionHelper.AddOrder(uow, "Order0", 44);
            var c1 = ConnectionHelper.AddOrder(uow, "Order1", 55);
            c0.Contains = "TestLike0";
            c1.Contains = "TestLike1";
            uow.CommitChanges();
        }

        public void PopulateForFreeJoin() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var c0 = ConnectionHelper.AddOrder(uow, "Order0", 44);
            var t00 = ConnectionHelper.AddFreeOrderItem(uow, c0, "FreeItem0-1", 10, new DateTime(2022, 11, 2));
            var t01 = ConnectionHelper.AddFreeOrderItem(uow, c0, "FreeItem0-2", 20, new DateTime(2022, 11, 1));
            var c1 = ConnectionHelper.AddOrder(uow, "Order1", 55);
            var t10 = ConnectionHelper.AddFreeOrderItem(uow, c1, "FreeItem1-1", 100, new DateTime(2022, 11, 4));
            var t11 = ConnectionHelper.AddFreeOrderItem(uow, c1, "FreeItem1-2", 200, new DateTime(2022, 11, 5));
            var t12 = ConnectionHelper.AddFreeOrderItem(uow, c1, "FreeItem1-3", 300, new DateTime(2022, 11, 3));

            uow.CommitChanges();
        }
        public void PopulateForFreeJoin_User() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var c0 = ConnectionHelper.AddOrder(uow, "Order0", "Owner0", new DateTime(2022, 11, 3));
            var t00 = ConnectionHelper.AddFreeOrderItem(uow, c0, "FreeItem0-1", 10, new DateTime(2022, 11, 2),"Owner0");
            var t01 = ConnectionHelper.AddFreeOrderItem(uow, c0, "FreeItem0-2", 20, new DateTime(2022, 11, 1),"Owner0");
            var c1 = ConnectionHelper.AddOrder(uow, "Order1", "Owner1", new DateTime(2022, 11, 25));
            var t10 = ConnectionHelper.AddFreeOrderItem(uow, c1, "FreeItem1-1", 100, new DateTime(2022, 11, 14),"Owner1");
            var t11 = ConnectionHelper.AddFreeOrderItem(uow, c1, "FreeItem1-2", 200, new DateTime(2022, 11, 25), "Owner1");
            uow.CommitChanges();
        }
        public void PopulateForFreeJoin_Order_Owner() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var c0 = ConnectionHelper.AddOrder(uow, "Order0", "Owner0", new DateTime(2022, 11, 3));
            var c1 = ConnectionHelper.AddOrder(uow, "Order1", "Owner0", new DateTime(2022, 11, 4));
            var c2 = ConnectionHelper.AddOrder(uow, "Order2", "Owner1", new DateTime(2022, 11, 6));
            var c3 = ConnectionHelper.AddOrder(uow, "Order3", "Owner1", new DateTime(2022, 11, 5));
            uow.CommitChanges();
        }
        public void PopulateForFreeJoinAssociation() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var c0 = ConnectionHelper.AddOrder(uow, "Order0", 44);
            var t00 = ConnectionHelper.AddOrderItem(uow, c0, "Item0-1", 10);
            var t01 = ConnectionHelper.AddOrderItem(uow, c0, "Item0-2", 20);
            var c1 = ConnectionHelper.AddOrder(uow, "Order1", 55);
            var t10 = ConnectionHelper.AddOrderItem(uow, c1, "Item1-1", 100);
            var t11 = ConnectionHelper.AddOrderItem(uow, c1, "Item1-2", 200);
            var t12 = ConnectionHelper.AddOrderItem(uow, c1, "Item1-3", 300);

            uow.CommitChanges();
        }

        public void PopulateForEnum() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var o0 = ConnectionHelper.AddOrder(uow, "order0", OrderStatusEnum.Active);
            var o1 = ConnectionHelper.AddOrder(uow, "order1", OrderStatusEnum.Delayed);

            uow.CommitChanges();
        }
        public void PopulateForComplexSum() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var o0 = ConnectionHelper.AddOrder(uow, "order0");
            var o1 = ConnectionHelper.AddOrder(uow, "order1");

            var oi00 = ConnectionHelper.AddOrderItem(uow, o0, "Item00");

            var p000 = ConnectionHelper.AddPosition(uow, oi00, "position000", 1);
            var p001 = ConnectionHelper.AddPosition(uow, oi00, "position001", 2);

            var oi01 = ConnectionHelper.AddOrderItem(uow, o0, "Item01");

            var p010 = ConnectionHelper.AddPosition(uow, oi01, "position010", 3);
            var p011 = ConnectionHelper.AddPosition(uow, oi01, "position011", 4);

            var oi10 = ConnectionHelper.AddOrderItem(uow, o1, "Item10");

            var p100 = ConnectionHelper.AddPosition(uow, oi10, "position100", 10);
            var p101 = ConnectionHelper.AddPosition(uow, oi10, "position101", 20);

            var oi11 = ConnectionHelper.AddOrderItem(uow, o1, "Item11");

            var p110 = ConnectionHelper.AddPosition(uow, oi11, "position110", 30);
            var p111 = ConnectionHelper.AddPosition(uow, oi11, "position111", 40);



            uow.CommitChanges();
        }
        public void PopulateForUpcasting() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var extendedOrder0 = new ExtendedOrder(uow);
            extendedOrder0.OrderName = "exOrder0";
            extendedOrder0.ExtendedDescription = "description0";

            var extendedOrder1 = new ExtendedOrder(uow);
            extendedOrder1.OrderName = "exOrder1";
            extendedOrder1.ExtendedDescription = "description1";

            var plainOrder = ConnectionHelper.AddOrder(uow, "orderPlain");

            uow.CommitChanges();
        }
        public void PopulateForComplexDateTwoWeek() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();

            var o0 = ConnectionHelper.AddOrder(uow, "order0", new DateTime(2022, 8, 8));
            var o1 = ConnectionHelper.AddOrder(uow, "order1", new DateTime(2022, 6, 19));
            var o2 = ConnectionHelper.AddOrder(uow, "order2", new DateTime(2022, 7, 27));
            var o3 = ConnectionHelper.AddOrder(uow, "order3", new DateTime(2022, 7, 20));
            var o4 = ConnectionHelper.AddOrder(uow, "order4", new DateTime(2022, 8, 1));

            uow.CommitChanges();
        }

        public void PopulateForComplexParentRelating() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();

            var o0 = ConnectionHelper.AddOrder(uow, "order0", new DateTime(2022, 8, 2));
            var o1 = ConnectionHelper.AddOrder(uow, "order1", new DateTime(2022, 8, 3));

            var oi00 = ConnectionHelper.AddOrderItem(uow, o0, "Item00", new DateTime(2022, 9, 3));
            var oi01 = ConnectionHelper.AddOrderItem(uow, o0, "Item01", new DateTime(2022, 9, 4));

            var oi10 = ConnectionHelper.AddOrderItem(uow, o1, "Item10", new DateTime(2022, 9, 5));
            var oi11 = ConnectionHelper.AddOrderItem(uow, o1, "Item11", new DateTime(2022, 8, 3));
            uow.CommitChanges();
        }
        public void PopulateForComplexMax() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();

            var o0 = ConnectionHelper.AddOrder(uow, "order0", new DateTime(2022, 8, 2), "red");
            var o1 = ConnectionHelper.AddOrder(uow, "order1", new DateTime(2022, 7, 5), "red");
            var o2 = ConnectionHelper.AddOrder(uow, "order2", new DateTime(2022, 8, 2), "red");
            var o3 = ConnectionHelper.AddOrder(uow, "order3", new DateTime(2022, 6, 12), "red");
            var o4 = ConnectionHelper.AddOrder(uow, "order4", new DateTime(2022, 5, 17), "green");
            var o5 = ConnectionHelper.AddOrder(uow, "order5", new DateTime(2022, 9, 22), "green");

            uow.CommitChanges();

        }
        public void PopulateForComplContains() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var c0 = ConnectionHelper.AddOrder(uow, "Order0", 44);
            c0.DefaultCompanyName = "RandomName";
            var comp00 = ConnectionHelper.AddCompany(uow, "Company00");
            var comp01 = ConnectionHelper.AddCompany(uow, "Company01");
            var comp10 = ConnectionHelper.AddCompany(uow, "Company10");
            var comp11 = ConnectionHelper.AddCompany(uow, "Company11");

            var t00 = ConnectionHelper.AddOrderItem(uow, c0, "Item0-1", 10, false, comp00);
            var t01 = ConnectionHelper.AddOrderItem(uow, c0, "Item0-2", 20, true, comp01);
            var c1 = ConnectionHelper.AddOrder(uow, "Order1", 55);
            c1.DefaultCompanyName = "Company11";
            var t10 = ConnectionHelper.AddOrderItem(uow, c1, "Item1-1", 10, false, comp10);
            var t11 = ConnectionHelper.AddOrderItem(uow, c1, "Item1-2", 20, true, comp11);
            t11.Company = new Company(uow);

            uow.CommitChanges();
        }

        public void PopulateSimpleCollectionForMaxMinTest() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var c0 = ConnectionHelper.AddOrder(uow, "FirstName0", 44);
            var t00 = ConnectionHelper.AddOrderItem(uow, c0, "Item0-1", 10, false);
            var t01 = ConnectionHelper.AddOrderItem(uow, c0, "Item0-1", 20, true);
            var t02 = ConnectionHelper.AddOrderItem(uow, c0, "Item0-1", 30, true);
            var t03 = ConnectionHelper.AddOrderItem(uow, c0, "Item0-1", 40, false);
            var c1 = ConnectionHelper.AddOrder(uow, "FirstName1", 99);
            var t10 = ConnectionHelper.AddOrderItem(uow, c1, "Item0-1", 10, false);
            var t11 = ConnectionHelper.AddOrderItem(uow, c1, "Item0-1", 44, true);
            uow.CommitChanges();
        }
        public void PopulateSimpleCollectionForGroupOperator() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var c0 = ConnectionHelper.AddOrder(uow, "Order0", 10);
            var c1 = ConnectionHelper.AddOrder(uow, "Order1", 20);
            var c2 = ConnectionHelper.AddOrder(uow, "Order2", 30);
            var c3 = ConnectionHelper.AddOrder(uow, "Order3", 40);

            uow.CommitChanges();
        }

        public void ForUnary() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var o1 = ConnectionHelper.AddOrder(uow, "TestOrder");
            var oi0 = ConnectionHelper.AddOrderItem(uow, o1, "OrderItem0");
            var oi1 = ConnectionHelper.AddOrderItem(uow, null, "OrderItem1");

            uow.CommitChanges();
        }
        public void PopulateSimpleCollectionForIsNullOrEmpty() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var c0 = ConnectionHelper.AddOrder(uow, "FirstName0", "TestDescription");
            var c1 = ConnectionHelper.AddOrder(uow, "FirstName3");
            uow.CommitChanges();
        }
        public void PopulateSimpleCollectionForIsNull() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var c0 = ConnectionHelper.AddOrder(uow, "FirstName0", "TestDescription");
            var c1 = ConnectionHelper.AddOrder(uow, "FirstName3");
            var c2 = ConnectionHelper.AddOrder(uow, "FirstName5", "WrongValue");
            uow.CommitChanges();
        }
        public void PopulateForIif() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var c0 = ConnectionHelper.AddOrder(uow, "Order1", "Type1", "Red");
            var c1 = ConnectionHelper.AddOrder(uow, "Order2", "Type1", "Blue");
            var c2 = ConnectionHelper.AddOrder(uow, "Order3", "Type2", "Green");
            var c3 = ConnectionHelper.AddOrder(uow, "Order4", "Type2", "Orange");
            uow.CommitChanges();
        }

        public void PopulateSimpleCollectionForBinary() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var c0 = ConnectionHelper.AddOrder(uow, "FirstName0", 30);
            var c1 = ConnectionHelper.AddOrder(uow, "FirstName0", 40);
            var c2 = ConnectionHelper.AddOrder(uow, "FirstName0", 50);
            var c3 = ConnectionHelper.AddOrder(uow, "FirstName0", 60);
            uow.CommitChanges();
        }

        public void PopulateDiffItems() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var c0 = ConnectionHelper.AddOrder(uow, "FirstName0");
            var t00 = ConnectionHelper.AddOrderItem(uow, c0, "Task0-0", 10);
            var t01 = ConnectionHelper.AddOrderItem(uow, c0, "Task0-1", 20);
            var c4 = ConnectionHelper.AddOrder(uow, "FirstName4");
            var t40 = ConnectionHelper.AddOrderItem(uow, c4, "Task4-0", 300);
            var t41 = ConnectionHelper.AddOrderItem(uow, c4, "Task4-1", 400);
            var t42 = ConnectionHelper.AddOrderItem(uow, c4, "Task4-2", 456);
            var t43 = ConnectionHelper.AddOrderItem(uow, c4, "Task4-3", 456);
            uow.CommitChanges();
        }
        public void PopulateOrderItemsWithSameValues() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var c0 = ConnectionHelper.AddOrder(uow, "FirstName0");
            var t00 = ConnectionHelper.AddOrderItem(uow, c0, "Task0-0", 10);
            var t01 = ConnectionHelper.AddOrderItem(uow, c0, "Task0-1", 10);
            var t02 = ConnectionHelper.AddOrderItem(uow, c0, "Task0-2", 20);
            uow.CommitChanges();
        }
        public void PopulateComplexCollection() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            var c0 = ConnectionHelper.AddOrder(uow, "FirstName0");
            var t00 = ConnectionHelper.AddOrderItem(uow, c0, "Task0-0");
            var t01 = ConnectionHelper.AddOrderItem(uow, c0, "Task0-1");

            var c1 = ConnectionHelper.AddOrder(uow, "FirstName1");
            var t10 = ConnectionHelper.AddOrderItem(uow, c1, "Task1-0");

            var c2 = ConnectionHelper.AddOrder(uow, "FirstName2");
            var t20 = ConnectionHelper.AddOrderItem(uow, c2, "Task2-0");
            var t21 = ConnectionHelper.AddOrderItem(uow, c2, "Task2-1");




            uow.CommitChanges();
        }
        public void PopulateComplexCollectionWithAvailable() {
            ConnectionHelper.Connect(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();

            var c0 = ConnectionHelper.AddOrder(uow, "FirstName0");
            var t00 = ConnectionHelper.AddOrderItem(uow, c0, "Task0-0", 10);
            var t01 = ConnectionHelper.AddOrderItem(uow, c0, "Task0-1", 20);

            var c1 = ConnectionHelper.AddOrder(uow, "FirstName1");
            var t10 = ConnectionHelper.AddOrderItem(uow, c1, "Task1-0", 100, true);
            var t11 = ConnectionHelper.AddOrderItem(uow, c1, "Task1-1", 200);

            var c2 = ConnectionHelper.AddOrder(uow, "FirstName2");
            var t20 = ConnectionHelper.AddOrderItem(uow, c2, "Task2-0", 30, true);
            var t21 = ConnectionHelper.AddOrderItem(uow, c2, "Task2-1", 40);
            uow.CommitChanges();
        }

    }
}
