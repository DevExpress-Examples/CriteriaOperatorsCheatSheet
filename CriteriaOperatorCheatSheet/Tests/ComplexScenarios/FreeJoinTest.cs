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
    public class FreeJoinTest : BaseTest {
        [Test]
        public void Test0_0() {
            //arrange
            PopulateForFreeJoin();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.Parse("[<OrderItem>][^.Oid = Order.Oid].Sum(ItemPrice) > 100");
            var resCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual(1, resCollection.Count);
            Assert.AreEqual("Order1", resCollection[0].OrderName);
        }
        [Test]
        public void Test0_1() {
            //arrange
            PopulateForFreeJoin();
            var uow = new UnitOfWork();
            //act
            var critCond = new BinaryOperator(new OperandProperty("^.Oid"), new OperandProperty("Order.Oid"), BinaryOperatorType.Equal);
            var critLeft = new JoinOperand(nameof(OrderItem), critCond, Aggregate.Sum, new OperandProperty(nameof(OrderItem.ItemPrice)));
            var criterion = new BinaryOperator(critLeft, 100, BinaryOperatorType.Greater);
            var resCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual(1, resCollection.Count);
            Assert.AreEqual("Order1", resCollection[0].OrderName);
        }
        //
        [Test]
        public void Test0_2() {
            //arrange
            PopulateForFreeJoin();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.FromLambda<Order>(o => FromLambdaFunctions.FreeJoin<OrderItem>(oi => oi.Order.Oid == o.Oid).Sum(oi => oi.ItemPrice) > 100);
            var resCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual(1, resCollection.Count);
            Assert.AreEqual("Order1", resCollection[0].OrderName);
        }
    }
}
