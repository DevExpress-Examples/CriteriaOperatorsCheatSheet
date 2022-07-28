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
    public class Aggregate_Single : BaseTest {
        [Test]
        public void Task0_0() {
            //arrange
            PopulateSelectFromCollection();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.Parse("[OrderItems][ItemPrice=40].Single(OrderItemName)");
            CriteriaOperator filterParentCollection = new BinaryOperator(nameof(Order.OrderName), "FirstName2");
            var result3 = uow.Evaluate<Order>(criterion, filterParentCollection);
            //assert
            Assert.AreEqual("Task2-1", result3);
        }
        [Test]
        public void Task0_1() {
            //arrange
            PopulateSelectFromCollection();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = new AggregateOperand(new OperandProperty(nameof(Order.OrderItems)), new OperandProperty(nameof(OrderItem.OrderItemName)), Aggregate.Single, new BinaryOperator(nameof(OrderItem.ItemPrice), 40));
            CriteriaOperator filterParentCollection = new BinaryOperator(nameof(Order.OrderName), "FirstName2");
            var result3 = uow.Evaluate<Order>(criterion, filterParentCollection);
            //assert
            Assert.AreEqual("Task2-1", result3);
        }
        [Test]
        public void Task0_2() {
            //arrange
            PopulateSelectFromCollection();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.FromLambda<Order, string>(o => o.OrderItems.SingleOrDefault(oi => oi.ItemPrice == 40).OrderItemName);
            CriteriaOperator filterParentCollection = new BinaryOperator(nameof(Order.OrderName), "FirstName2");
            var result3 = uow.Evaluate<Order>(criterion, filterParentCollection);
            //assert
            Assert.AreEqual("Task2-1", result3);
        }
        [Test]
        public void Task1_0() {
            //arrange
            PopulateSelectFromCollection();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.Parse("[OrderItems][ItemPrice=40].Single()");
            CriteriaOperator filterParentCollection = new BinaryOperator(nameof(Order.OrderName), "FirstName2");
            var result3 = uow.Evaluate<Order>(criterion, filterParentCollection);
            //assert
            var reqId = uow.FindObject<OrderItem>(new BinaryOperator(nameof(OrderItem.OrderItemName), "Task2-1")).Oid;
            Assert.AreEqual(reqId, result3);
        }
        [Test]
        public void Task1_1() {
            //arrange
            PopulateSelectFromCollection();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = new AggregateOperand(new OperandProperty(nameof(Order.OrderItems)), new OperandProperty("This"), Aggregate.Single, new BinaryOperator(nameof(OrderItem.ItemPrice), 40));
            CriteriaOperator filterParentCollection = new BinaryOperator(nameof(Order.OrderName), "FirstName2");
            var result = uow.Evaluate<Order>(criterion, filterParentCollection);
            //assert
            var reqId = uow.FindObject<OrderItem>(new BinaryOperator(nameof(OrderItem.OrderItemName), "Task2-1")).Oid;
            Assert.AreEqual(reqId, result);
        }
        [Test]
        public void Task1_2() {
            //arrange
            PopulateSelectFromCollection();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.FromLambda<Order, OrderItem>(o => o.OrderItems.SingleOrDefault(oi => oi.ItemPrice == 40));
            CriteriaOperator filterParentCollection = new BinaryOperator(nameof(Order.OrderName), "FirstName2");
            var result = uow.Evaluate<Order>(criterion, filterParentCollection);
            //assert
            var reqId = uow.FindObject<OrderItem>(new BinaryOperator(nameof(OrderItem.OrderItemName), "Task2-1")).Oid;
            Assert.AreEqual(reqId, result);
        }


        [Test]
        public void Task2_0() {
            //arrange
            PopulateDiffItems();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.Parse("Order=[<Order>][[OrderItems][ItemPrice=456]].Single()");
            var resultCriterion = new XPCollection<OrderItem>(uow, criterion);
            //assert
            Assert.AreEqual(4, resultCriterion.Count);
        }
        [Test]
        public void Task2_1() {
            //arrange
            PopulateDiffItems();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = new AggregateOperand(new OperandProperty(nameof(Order.OrderItems)), null, Aggregate.Exists, new BinaryOperator(nameof(OrderItem.ItemPrice), 456));
            CriteriaOperator joinCriterion = new JoinOperand(nameof(Order), criterion, Aggregate.Single, new OperandProperty("This"));
            CriteriaOperator resultCriterion = new BinaryOperator(nameof(OrderItem.Order), joinCriterion);
            var result3 = new XPCollection<OrderItem>(uow, resultCriterion);
            //assert
            Assert.AreEqual(4, result3.Count);
        }
        [Test]
        public void Task2_2() {
            //arrange
            PopulateDiffItems();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator resultCriterion = CriteriaOperator.FromLambda<OrderItem>(oi => oi.Order == FromLambdaFunctions.FreeJoin<Order>(o => o.OrderItems.Any(oii => oii.ItemPrice == 456)).SingleOrDefault());
            var result3 = new XPCollection<OrderItem>(uow, resultCriterion);
            //assert
            Assert.AreEqual(4, result3.Count);
        }
    }
}
