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
    public class ComplexSumTest : BaseTest {
        [Test]
        public void ComplexSum_String() {
            //arrange
            PopulateForComplexSum();
            var uow = new UnitOfWork();
            //act
            var criterion = 
                CriteriaOperator.Parse("OrderItems.Sum(Positions.Sum(PositionCount))==10");
            var resultCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual("order0", resultCollection[0].OrderName);
            Assert.AreEqual(1, resultCollection.Count);
        }
        [Test]
        public void ComplexSum_Typed() {
            //arrange
            PopulateForComplexSum();
            var uow = new UnitOfWork();
            //act
            var positionsExpression = new AggregateOperand(new OperandProperty(nameof(OrderItem.Positions)), new OperandProperty(nameof(Position.PositionCount)), Aggregate.Sum, null);
            var orderItemExpression = new AggregateOperand(new OperandProperty(nameof(Order.OrderItems)), positionsExpression, Aggregate.Sum, null);
            var criterion = new BinaryOperator(orderItemExpression, new OperandValue(10), BinaryOperatorType.Equal);
            var resultCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual("order0", resultCollection[0].OrderName);
            Assert.AreEqual(1, resultCollection.Count);
        }
        [Test]
        public void ComplexSum_Linq() {
            //arrange
            PopulateForComplexSum();
            var uow = new UnitOfWork();
            //act
            var criterion = 
                CriteriaOperator.FromLambda<Order>(o => o.OrderItems.Sum(oi => oi.Positions.Sum(p => p.PositionCount)) == 10);
            var resultCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual("order0", resultCollection[0].OrderName);
            Assert.AreEqual(1, resultCollection.Count);
        }
    }
}
