using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using dxTestSolutionXPO.Module.BusinessObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxTestSolutionXPO.Tests {
    [TestFixture]
    public class ContainsOperatorTests : BaseTest {
        [Test]
        public void Test0_0() {
            //arrange
            PopulateSimpleCollectionForMaxMinTest();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.Parse("[OrderItems][ItemPrice = ?]", 44);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("FirstName1", xpColl[0].OrderName);
        }
        [Test]
        public void Test0_1() {
            //arrange
            PopulateSimpleCollectionForMaxMinTest();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = new ContainsOperator("OrderItems", new BinaryOperator("ItemPrice", 44));
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("FirstName1", xpColl[0].OrderName);
        }
        [Test]
        public void Test0_2() {
            //arrange
            PopulateSimpleCollectionForMaxMinTest();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.FromLambda<Order>(o => o.OrderItems.Any(oi => oi.ItemPrice == 44));
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("FirstName1", xpColl[0].OrderName);
        }
    }
}
