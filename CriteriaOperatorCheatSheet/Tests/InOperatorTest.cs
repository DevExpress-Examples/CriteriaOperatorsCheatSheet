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
    public class InOperatorTest : BaseTest {
        [Test]
        public void Test0_0() {
            //arrange
            PopulateSimpleCollectionForGroupOperator();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                CriteriaOperator.Parse("OrderName In ('Order2', 'Order3','Description5')");
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resColl = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resColl.Count;
            //assert
            Assert.AreEqual(2, result3);
            Assert.AreEqual("Order2", resColl[0].OrderName);
            Assert.AreEqual("Order3", resColl[1].OrderName);
        }
        [Test]
        public void Test0_1() {
            //arrange
            PopulateSimpleCollectionForGroupOperator();
            var uow = new UnitOfWork();
            //act

            CriteriaOperator criterion = 
                new InOperator("OrderName", new string[] { "Order2", "Order3", "Description5" });
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resColl = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resColl.Count;
            //assert
            Assert.AreEqual(2, result3);
            Assert.AreEqual("Order2", resColl[0].OrderName);
            Assert.AreEqual("Order3", resColl[1].OrderName);
        }
        [Test]
        public void Test0_2() {
            //arrange
            PopulateSimpleCollectionForGroupOperator();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                CriteriaOperator.FromLambda<Order, bool>(o => new string[] { "Order2", "Order3", "Description5" }.Contains(o.OrderName));
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resColl = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resColl.Count;
            //assert
            Assert.AreEqual(2, result3);
            Assert.AreEqual("Order2", resColl[0].OrderName);
            Assert.AreEqual("Order3", resColl[1].OrderName);
        }
    }
}
