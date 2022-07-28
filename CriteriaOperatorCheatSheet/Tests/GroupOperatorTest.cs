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
    public class GroupOperatorTest : BaseTest {
        [Test]
        public void Test0_0() {
            //arrange
            PopulateSimpleCollectionForGroupOperator();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.Parse("Price=20 or OrderName='Order3'");
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resColl = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resColl.Count;
            //assert
            Assert.AreEqual(2, result3);
            Assert.AreEqual("Order1", resColl[0].OrderName);
            Assert.AreEqual("Order3", resColl[1].OrderName);
        }
        [Test]
        public void Test0_1() {
            //arrange
            PopulateSimpleCollectionForGroupOperator();
            var uow = new UnitOfWork();
            //act
            BinaryOperator operator1 = new BinaryOperator(nameof(Order.Price), 20);
            BinaryOperator operator2 = new BinaryOperator(nameof(Order.OrderName), "Order3");
            CriteriaOperator criterion = GroupOperator.Or(operator1, operator2);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resColl = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resColl.Count;
            //assert
            Assert.AreEqual(2, result3);
            Assert.AreEqual("Order1", resColl[0].OrderName);
            Assert.AreEqual("Order3", resColl[1].OrderName);
        }
        [Test]
        public void Test0_2() {
            //arrange
            PopulateSimpleCollectionForGroupOperator();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.FromLambda<Order>(o => o.Price==20 || o.OrderName == "Order3");
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resColl = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resColl.Count;
            //assert
            Assert.AreEqual(2, result3);
            Assert.AreEqual("Order1", resColl[0].OrderName);
            Assert.AreEqual("Order3", resColl[1].OrderName);
        }
    }
}
