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
    public class Aggregate_Min : BaseTest {
        [Test]
        public void Test_0() {
            //arrange
            PopulateSimpleCollectionForMaxMin();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
                CriteriaOperator.Parse("OrderItems.Min(ItemPrice)");
            CriteriaOperator filterParentCollection = new BinaryOperator(nameof(Order.OrderName), "FirstName0");
            var result3 = uow.Evaluate<Order>(criterion, filterParentCollection);
            //assert
            Assert.AreEqual(10, result3);
        }
        [Test]
        public void Test_1() {
            //arrange
            PopulateSimpleCollectionForMaxMin();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
                new AggregateOperand(new OperandProperty(nameof(Order.OrderItems)), new OperandProperty(nameof(OrderItem.ItemPrice)), Aggregate.Min, null);
            CriteriaOperator filterParentCollection = new BinaryOperator(nameof(Order.OrderName), "FirstName0");
            var result3 = uow.Evaluate<Order>(criterion, filterParentCollection);
            //assert
            Assert.AreEqual(10, result3);
        }
        [Test]
        public void Test_2() {
            //arrange
            PopulateSimpleCollectionForMaxMin();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
                CriteriaOperator.FromLambda<Order, int>(o => o.OrderItems.Min(oi => oi.ItemPrice));
            CriteriaOperator filterParentCollection = new BinaryOperator(nameof(Order.OrderName), "FirstName0");
            var result3 = uow.Evaluate<Order>(criterion, filterParentCollection);
            //assert
            Assert.AreEqual(10, result3);
        }

        [Test]
        public void Test1_0() {
            //arrange
            PopulateSimpleCollectionForMaxMin();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
                CriteriaOperator.Parse("[OrderItems][IsAvailable=True].Min(ItemPrice)");
            CriteriaOperator filterParentCollection = new BinaryOperator(nameof(Order.OrderName), "FirstName0");
            var result3 = uow.Evaluate<Order>(criterion, filterParentCollection);
            //assert
            Assert.AreEqual(20, result3);
        }
        [Test]
        public void Test1_1() {
            //arrange
            PopulateSimpleCollectionForMaxMin();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                new AggregateOperand(new OperandProperty(nameof(Order.OrderItems)), new OperandProperty(nameof(OrderItem.ItemPrice)), Aggregate.Min, new BinaryOperator(nameof(OrderItem.IsAvailable), true));
            CriteriaOperator filterParentCollection = new BinaryOperator(nameof(Order.OrderName), "FirstName0");
            var result3 = uow.Evaluate<Order>(criterion, filterParentCollection);
            //assert
            Assert.AreEqual(20, result3);
        }
        [Test]
        public void Test1_2() {
            //arrange
            PopulateSimpleCollectionForMaxMin();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                CriteriaOperator.FromLambda<Order, int>(o => o.OrderItems.Where(oi => oi.IsAvailable == true).Min(oi => oi.ItemPrice)); ;
            CriteriaOperator filterParentCollection = new BinaryOperator(nameof(Order.OrderName), "FirstName0");
            var result3 = uow.Evaluate<Order>(criterion, filterParentCollection);
            //assert
            Assert.AreEqual(20, result3);
        }
    }
}
