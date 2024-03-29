﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using dxTestSolutionXPO.Module.BusinessObjects;
using DevExpress.Xpo.DB;

namespace dxTestSolutionXPO {
    public static class ConnectionHelper {
        static Type[] persistentTypes = new Type[] {
            typeof(Order),typeof(OrderItem)
        };
        public static Type[] GetPersistentTypes() {
            Type[] copy = new Type[persistentTypes.Length];
            Array.Copy(persistentTypes, copy, persistentTypes.Length);
            return copy;
        }
        static string ConnectionString;
        static bool UseInMemoryStore;
        public static void Connect(DevExpress.Xpo.DB.AutoCreateOption autoCreateOption, bool threadSafe = false) {
            EnumProcessingHelper.RegisterEnum<OrderStatusEnum>();
            ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            if(threadSafe) {
                var provider = XpoDefault.GetConnectionProvider(ConnectionString, autoCreateOption);
                var dictionary = new DevExpress.Xpo.Metadata.ReflectionDictionary();
                dictionary.GetDataStoreSchema(persistentTypes);
                XpoDefault.DataLayer = new ThreadSafeDataLayer(dictionary, provider);
            } else {
                XpoDefault.DataLayer = XpoDefault.GetDataLayer(ConnectionString, autoCreateOption);
            }
            UseInMemoryStore = true;
            if(UseInMemoryStore) {
                XpoDefault.DataLayer = new SimpleDataLayer(new InMemoryDataStore());
            }
            XpoDefault.Session = null;
        }
        public static DevExpress.Xpo.DB.IDataStore GetConnectionProvider(DevExpress.Xpo.DB.AutoCreateOption autoCreateOption) {
            return XpoDefault.GetConnectionProvider(ConnectionString, autoCreateOption);
        }
        public static DevExpress.Xpo.DB.IDataStore GetConnectionProvider(DevExpress.Xpo.DB.AutoCreateOption autoCreateOption, out IDisposable[] objectsToDisposeOnDisconnect) {
            return XpoDefault.GetConnectionProvider(ConnectionString, autoCreateOption, out objectsToDisposeOnDisconnect);
        }
        public static IDataLayer GetDataLayer(DevExpress.Xpo.DB.AutoCreateOption autoCreateOption) {
            return XpoDefault.GetDataLayer(ConnectionString, autoCreateOption);
        }
        public static Order AddOrder(UnitOfWork _uow, string _orderName) {
            var c = new Order(_uow);
            c.OrderName = _orderName;
            return c;
        }
        public static Order AddOrder(UnitOfWork _uow, string _orderName,OrderStatusEnum _status) {
            var c =AddOrder(_uow, _orderName);
            c.Status = _status;
            return c;
        }
        public static Order AddOrder(UnitOfWork _uow, string _orderName, DateTime _date) {
            var c = AddOrder(_uow, _orderName);
            c.OrderDate = _date;
            return c;
        }

        public static Order AddOrder(UnitOfWork _uow, string _orderName, DateTime _date, string _color) {
            var c = AddOrder(_uow, _orderName, _date);
            c.OrderColor = _color;
            return c;
        }
        public static Order AddOrder(UnitOfWork _uow, string _orderName, string _type, string _color) {
            var c = AddOrder(_uow, _orderName);
            c.OrderType = _type;
            c.OrderColor = _color;
            return c;
        }
        public static Order AddOrder(UnitOfWork _uow, string _firstName, string _description, int _price) {
            var c = AddOrder(_uow, _firstName, _description);
            c.Price = _price;
            return c;
        }
        public static Order AddOrderWithOwner(UnitOfWork _uow, string _firstName, string _owner) {
            var c = AddOrder(_uow, _firstName);
            c.OrderOwnerName = _owner;
            return c;
        }
        public static Order AddOrder(UnitOfWork _uow, string _firstName, string _description) {
            var c = AddOrder(_uow, _firstName);
            c.Description = _description;
            return c;
        }
        public static Order AddOrder(UnitOfWork _uow, string _firstName, string _ownerName,DateTime _date) {
            var c = AddOrder(_uow, _firstName);
            c.OrderOwnerName= _ownerName; 
            c.OrderDate= _date; 
            return c;
        }
        internal static Order AddOrder(UnitOfWork _uow, string _firstName, int _price) {
            var c = AddOrder(_uow, _firstName);
            c.Price = _price;
            return c;

        }
        public static Order AddOrder(UnitOfWork _uow, string _firstName, int _price, bool _isActive) {
            var c = AddOrder(_uow, _firstName, _price);
            c.IsActive = _isActive;
            return c;
        }
        public static   Position AddPosition(UnitOfWork _uow, OrderItem _parent, string _name,int _count) {
            var p = new Position(_uow);
            p.ParentOrderItem = _parent;
            p.PositionName = _name;
            p.PositionCount = _count;
            return p;
        }

        public static OrderItem AddOrderItem(UnitOfWork _uow, Order _parent, string _subject) {
            var t = new OrderItem(_uow);
            t.OrderItemName = _subject;
            t.Order = _parent;
            return t;
        }
        public static OrderItem AddOrderItem(UnitOfWork _uow, Order _parent, string _subject,DateTime _registrationDate) {
            var t = AddOrderItem(_uow,_parent,_subject);
            t.RegistrationDate = _registrationDate;
            return t;
        }
        public static OrderItem AddOrderItem(UnitOfWork _uow, Order _parent, string _subject, int _price, bool _isAvailable, Company _company) {
            var t = AddOrderItem(_uow, _parent, _subject, _price, _isAvailable);
            t.Company = _company;
            return t;
        }
        public static OrderItem AddOrderItem(UnitOfWork _uow, Order _parent, string _subject, int _price) {
            var t = AddOrderItem(_uow, _parent, _subject);
            t.ItemPrice = _price;
            return t;
        }
        public static OrderItem AddOrderItem(UnitOfWork _uow, Order _parent, string _subject, int _price, int _id) {
            var t = AddOrderItem(_uow, _parent, _subject);
            t.Oid = _id;
            t.ItemPrice = _price;
            return t;
        }
        public static OrderItem AddOrderItem(UnitOfWork _uow, Order _parent, string _subject, int _price, bool _isAvailable) {
            var t = AddOrderItem(_uow, _parent, _subject, _price);
            t.IsAvailable = _isAvailable;
            return t;
        }
        public static FreeOrderItem AddFreeOrderItem(UnitOfWork _uow, Order _parent, string _subject, int _price ) {
            var t = new FreeOrderItem(_uow);
            t.FreeOrderName= _subject;
            t.ItemPrice = _price;
            t.Order = _parent;
            return t;
        }
     
        public static FreeOrderItem AddFreeOrderItem(UnitOfWork _uow, Order _parent, string _subject, int _price,DateTime _date) {
            var t = AddFreeOrderItem(_uow, _parent, _subject, _price);
            t.FreeOrderDate = _date;
            return t;
        }
        public static FreeOrderItem AddFreeOrderItem(UnitOfWork _uow, Order _parent, string _subject, int _price, DateTime _date, string _owner) {
            var t = AddFreeOrderItem(_uow, _parent, _subject, _price,_date);
            t.FreeOrderOwnerName = _owner;
            return t;
        }
        public static Company AddCompany(UnitOfWork _uow, string _name) {
            var c = new Company(_uow);
            c.CompanyName = _name;
            return c;
        }
    }

}
