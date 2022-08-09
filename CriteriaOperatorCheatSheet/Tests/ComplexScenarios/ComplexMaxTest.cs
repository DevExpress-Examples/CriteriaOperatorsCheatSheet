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
    public class ComplexMaxTest: BaseTest {
        //FreeJoins
        [Test]
        public void GetItemsWithMaxDate_String() {
            //arrange
            PopulateForComplexMax();
            var uow = new UnitOfWork();
            //act
            var criterion = CriteriaOperator.Parse("OrderDate ==[<Order>][OrderColor=='red'].Max(OrderDate)");
            var resultCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual(new DateTime(2022, 8, 2), resultCollection[0].OrderDate);
            Assert.AreEqual(2, resultCollection.Count);
        }
        [Test]
        public void GetItemsWithMaxDate_Typed() {
            //arrange
            PopulateForComplexMax();
            var uow = new UnitOfWork();
            //act
            var filerJoin = new BinaryOperator(nameof(Order.OrderColor), "red");
            var joinOperand = new JoinOperand(nameof(Order), filerJoin, Aggregate.Max, new OperandProperty(nameof(Order.OrderDate)));
            var criterion = new BinaryOperator(nameof(Order.OrderDate), joinOperand);
            var resultCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual(new DateTime(2022, 8, 2), resultCollection[0].OrderDate);
            Assert.AreEqual(2, resultCollection.Count);
        }
        [Test]
        public void GetItemsWithMaxDate_Linq() {
            //arrange
            PopulateForComplexMax();
            var uow = new UnitOfWork();
            //act
            var criterion = CriteriaOperator.Parse("OrderDate ==[<Order>][OrderColor=='red'].Max(OrderDate)");

            var criterion2 = CriteriaOperator.FromLambda<Order>(o => o.OrderDate == FromLambdaFunctions.FreeJoin<Order>(selectOrder => selectOrder.OrderColor == "red").Max(resultOrder => resultOrder.OrderDate));
            var resultCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual(new DateTime(2022, 8, 2), resultCollection[0].OrderDate);
            Assert.AreEqual(2, resultCollection.Count);
        }

    }
}
