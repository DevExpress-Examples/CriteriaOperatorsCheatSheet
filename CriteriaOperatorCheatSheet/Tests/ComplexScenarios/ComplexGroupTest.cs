using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using dxTestSolutionXPO.Module.BusinessObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxTestSolutionXPO.Tests.ComplexScenarios.cs {
    [TestFixture]
    public class ComplexGroupTest : BaseTest {
        [Test]
        public void Test0_0v0() {
            //arrange
            PopulateForComplex();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.Parse("Order.OrderName == 'FirstName1' AND  !IsNull(Company)");
            var resCollection = new XPCollection<OrderItem>(uow, criterion);
            //assert
            Assert.AreEqual(1, resCollection.Count);
            Assert.AreEqual("Item1-2", resCollection[0].OrderItemName);
        }
        [Test]
        public void Test0_0v1() {
            //arrange
            PopulateForComplex();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.Parse("Order.OrderName == 'FirstName1' AND Not IsNull(Company)");
            var resCollection = new XPCollection<OrderItem>(uow, criterion);
            //assert
            Assert.AreEqual(1, resCollection.Count);
            Assert.AreEqual("Item1-2", resCollection[0].OrderItemName);
        }
        [Test]
        public void Test0_0v2() {
            //arrange
            PopulateForComplex();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.Parse("Order.OrderName == 'FirstName1' AND  Company is not null");
            var resCollection = new XPCollection<OrderItem>(uow, criterion);
            //assert
            Assert.AreEqual(1, resCollection.Count);
            Assert.AreEqual("Item1-2", resCollection[0].OrderItemName);
        }
        [Test]
        public void Test0_1() {
            //arrange
            PopulateForComplex();
            var uow = new UnitOfWork();
            //act
            var operator1 = new BinaryOperator("Order.OrderName", "FirstName1");
            var operator2 = new FunctionOperator(FunctionOperatorType.IsNull, new OperandProperty(nameof(OrderItem.Company)));
            var operator2_2 = new UnaryOperator(UnaryOperatorType.Not, operator2);
            CriteriaOperator criterion = new GroupOperator(GroupOperatorType.And, operator1, operator2_2);
            var resCollection = new XPCollection<OrderItem>(uow, criterion);
            //assert
            Assert.AreEqual(1, resCollection.Count);
            Assert.AreEqual("Item1-2", resCollection[0].OrderItemName);
        }
        [Test]
        public void Test0_2() {
            //arrange
            PopulateForComplex();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.FromLambda<OrderItem>(oi => oi.Order.OrderName == "FirstName1" && oi.Company != null);
            var resCollection = new XPCollection<OrderItem>(uow, criterion);
            //assert
            Assert.AreEqual(1, resCollection.Count);
            Assert.AreEqual("Item1-2", resCollection[0].OrderItemName);
        }
    }
}
