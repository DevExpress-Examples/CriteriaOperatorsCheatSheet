using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using dxTestSolutionXPO.Module.BusinessObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxTestSolutionXPO.Tests.ComplexScenarios {
    [TestFixture]
    public class ComplexContainsTest : BaseTest {
        [Test]
        public void GetOrdersWithSpecificOrderItems_String() {
            //arrange
            PopulateSimpleCollectionForMaxMinTest();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                CriteriaOperator.Parse("[OrderItems][ItemPrice = ?] and Price = ?", 10, 99);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("FirstName1", xpColl[0].OrderName);
        }
        [Test]
        public void GetOrdersWithSpecificOrderItems_Typed() {
            //arrange
            PopulateSimpleCollectionForMaxMinTest();
            var uow = new UnitOfWork();
            //act
            var containsCriterion = new ContainsOperator(nameof(Order.OrderItems), new BinaryOperator(nameof(OrderItem.ItemPrice), 10));
            var simpleCriterion = new BinaryOperator(nameof(Order.Price), 99);
            var criterion = new GroupOperator(containsCriterion, simpleCriterion);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("FirstName1", xpColl[0].OrderName);
        }
        [Test]
        public void GetOrdersWithSpecificOrderItems_Linq() {
            //arrange
            PopulateSimpleCollectionForMaxMinTest();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                CriteriaOperator.FromLambda<Order>(o => o.OrderItems.Any(oi => oi.ItemPrice == 10) && o.Price == 99);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("FirstName1", xpColl[0].OrderName);
        }

        [Test]
        public void GetItemsWithCompanyName_String() {
            //arrange
            PopulateForComplex();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.Parse("[OrderItems][Company.CompanyName = 'Company1']");
            var resCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual(1, resCollection.Count);
            Assert.AreEqual("Order1", resCollection[0].OrderName);
        }
        [Test]
        public void GetItemsWithCompanyName_Typed() {
            //arrange
            PopulateForComplex();
            var uow = new UnitOfWork();
            //act
            var criterionForCollection = new BinaryOperator("Company.CompanyName", "Company1");
            var criterion = new ContainsOperator(nameof(Order.OrderItems), criterionForCollection);
            var resCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual(1, resCollection.Count);
            Assert.AreEqual("Order1", resCollection[0].OrderName);
        }
        [Test]
        public void GetItemsWithCompanyName_Linq() {
            //arrange
            PopulateForComplex();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.FromLambda<Order>(o => o.OrderItems.Any(oi => oi.Company.CompanyName == "Company1"));
            var resCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual(1, resCollection.Count);
            Assert.AreEqual("Order1", resCollection[0].OrderName);
        }
    }
}
