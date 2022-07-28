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
    public class Aggregate_Exists : BaseTest {
        [Test]
        public void Task0_0() {
            //arrange
            PopulateSelectFromCollectionForCount();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.Parse("OrderItems.Exists()");
            CriteriaOperator filterParentCollection = new BinaryOperator(nameof(Order.OrderName), "FirstName0");
            var result3 = uow.Evaluate<Order>(criterion, filterParentCollection);
            //assert
            Assert.AreEqual(true, result3);
        }
        [Test]
        public void Task0_0_false() {
            //arrange
            PopulateSelectFromCollectionForCount();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.Parse("OrderItems.Exists()");
            CriteriaOperator filterParentCollection = new BinaryOperator(nameof(Order.OrderName), "FirstName1");
            var result3 = uow.Evaluate<Order>(criterion, filterParentCollection);
            //assert
            Assert.AreEqual(false, result3);
        }
        [Test]
        public void Task0_1() {
            //arrange
            PopulateSelectFromCollectionForCount();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = new AggregateOperand(nameof(Order.OrderItems), Aggregate.Exists);
            CriteriaOperator filterParentCollection = new BinaryOperator(nameof(Order.OrderName), "FirstName0");
            var result3 = uow.Evaluate<Order>(criterion, filterParentCollection);
            //assert
            Assert.AreEqual(true, result3);
        }
        [Test]
        public void Task0_2() {
            //arrange
            PopulateSelectFromCollectionForCount();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.FromLambda<Order>(o => o.OrderItems.Any());
            CriteriaOperator filterParentCollection = new BinaryOperator(nameof(Order.OrderName), "FirstName0");
            var result3 = uow.Evaluate<Order>(criterion, filterParentCollection);
            //assert
            Assert.AreEqual(true, result3);
        }
        [Test]
        public void Task1_0() {
            //arrange
            PopulateSelectFromCollectionForCount();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.Parse("[OrderItems][ItemPrice=20]");
            CriteriaOperator filterParentCollection = new BinaryOperator(nameof(Order.OrderName), "FirstName2");
            var result3 = uow.Evaluate<Order>(criterion, filterParentCollection);
            //assert
            Assert.AreEqual(true, result3);
        }
        [Test]
        public void Task1_0_false() {
            //arrange
            PopulateSelectFromCollectionForCount();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.Parse("[OrderItems][ItemPrice=30]");
            CriteriaOperator filterParentCollection = new BinaryOperator(nameof(Order.OrderName), "FirstName2");
            var result3 = uow.Evaluate<Order>(criterion, filterParentCollection);
            //assert
            Assert.AreEqual(false, result3);
        }
        [Test]
        public void Task1_1() {
            //arrange
            PopulateSelectFromCollectionForCount();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = new AggregateOperand(nameof(Order.OrderItems), Aggregate.Exists,new BinaryOperator(nameof(OrderItem.ItemPrice),20));
            CriteriaOperator filterParentCollection = new BinaryOperator(nameof(Order.OrderName), "FirstName2");
            var result3 = uow.Evaluate<Order>(criterion, filterParentCollection);
            //assert
            Assert.AreEqual(true, result3);
        }
        [Test]
        public void Task1_2() {
            //arrange
            PopulateSelectFromCollectionForCount();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.FromLambda<Order>(o => o.OrderItems.Any(oi=>oi.ItemPrice==20)); ;
            CriteriaOperator filterParentCollection = new BinaryOperator(nameof(Order.OrderName), "FirstName2");
            var result3 = uow.Evaluate<Order>(criterion, filterParentCollection);
            //assert
            Assert.AreEqual(true, result3);
        }

    }
}
