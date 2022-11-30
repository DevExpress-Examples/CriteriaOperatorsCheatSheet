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
    public class UnaryOperatorTest : BaseTest {
        [Test]
        public void Test0_0() {
            //arrange
            PopulateSimpleCollectionForGroupOperator();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                CriteriaOperator.Parse("Not Price Between (20,30)");
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resColl = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resColl.Count;
            //assert
            Assert.AreEqual(2, result3);
            Assert.AreEqual("Order0", resColl[0].OrderName);
            Assert.AreEqual("Order3", resColl[1].OrderName);
        }
        [Test]
        public void Test0_1() {
            //arrange
            PopulateSimpleCollectionForGroupOperator();
            var uow = new UnitOfWork();
            //act

            CriteriaOperator criterion = 
                new UnaryOperator(UnaryOperatorType.Not, new BetweenOperator(nameof(Order.Price), 20, 30));
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resColl = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resColl.Count;
            //assert
            Assert.AreEqual(2, result3);
            Assert.AreEqual("Order0", resColl[0].OrderName);
            Assert.AreEqual("Order3", resColl[1].OrderName);
        }
        [Test]
        public void Test0_2() {
            //arrange
            PopulateSimpleCollectionForGroupOperator();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                CriteriaOperator.FromLambda<Order>(o => !(o.Price >= 20 && o.Price <= 30));
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resColl = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resColl.Count;
            //assert
            Assert.AreEqual(2, result3);
            Assert.AreEqual("Order0", resColl[0].OrderName);
            Assert.AreEqual("Order3", resColl[1].OrderName);
        }

        [Test]
        public void Test1_0() {
            //arrange
            ForUnary();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                CriteriaOperator.Parse("Order is null");
            var xpColl = new XPCollection<OrderItem>(uow);
            xpColl.Filter = criterion;
            var resColl = xpColl.ToList();
            var result3 = resColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("OrderItem1", resColl[0].OrderItemName);
        }
        [Test]
        public void Test2_1() {
            //arrange
            ForUnary();
            var uow = new UnitOfWork();
            //act

            CriteriaOperator criterion = 
                new UnaryOperator(UnaryOperatorType.IsNull, new OperandProperty(nameof(OrderItem.Order)));
            var xpColl = new XPCollection<OrderItem>(uow);
            xpColl.Filter = criterion;
            var resColl = xpColl.ToList();
            var result3 = resColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("OrderItem1", resColl[0].OrderItemName);
        }

        [Test]
        public void Test1_2() {
            //arrange
            ForUnary();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                CriteriaOperator.FromLambda<OrderItem>(oi => oi.Order == null);
            var xpColl = new XPCollection<OrderItem>(uow);
            xpColl.Filter = criterion;
            var resColl = xpColl.ToList();
            var result3 = resColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("OrderItem1", resColl[0].OrderItemName);
        }
    }
}
