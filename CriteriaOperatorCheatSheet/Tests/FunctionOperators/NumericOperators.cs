using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using dxTestSolutionXPO.Module.BusinessObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxTestSolutionXPO.Tests.FunctionOperators {
    [TestFixture]
    public class NumericOperators:BaseTest {

        [Test]
        public void Test0_0() {
            //arrange
            PopulateForNumeric();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.Parse("Abs(Price)>10");
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
            PopulateForNumeric();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator funccriterion = new FunctionOperator(FunctionOperatorType.Abs, new OperandProperty(nameof(Order.Price)));
            CriteriaOperator criterion = new BinaryOperator(funccriterion, new ConstantValue(10), BinaryOperatorType.Greater);
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
            PopulateForNumeric();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.FromLambda<Order>(o => Math.Abs(o.Price)>10);
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
