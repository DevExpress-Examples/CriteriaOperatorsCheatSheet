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
    public class FunctionOperator_IsNull : BaseTest {
        [Test]
        public void Test0_0() {
            //arrange
            ForUnary();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                CriteriaOperator.Parse("IsNull(Order)");
            var xpColl = new XPCollection<OrderItem>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("OrderItem1", xpColl[0].OrderItemName);
        }
        [Test]
        public void Test0_1() {
            //arrange
            ForUnary();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                new FunctionOperator(FunctionOperatorType.IsNull, new OperandProperty(nameof(OrderItem.Order)));
            var xpColl = new XPCollection<OrderItem>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("OrderItem1", xpColl[0].OrderItemName);
        }
        [Test]
        public void Test0_2() {
            //arrange
            ForUnary();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                CriteriaOperator.FromLambda<OrderItem>(oi => oi.Order == null);
            var xpColl = new XPCollection<OrderItem>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("OrderItem1", xpColl[0].OrderItemName);
        }


        [Test] 
        public void Test1_0() {
            //arrange
            PopulateSimpleCollectionForIsNull();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                CriteriaOperator.Parse("'WrongValue'=IsNull(Description,'WrongValue')");
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resultColl=xpColl.OrderBy(x=>x.OrderName).ToList();
            var result3 = resultColl.Count;
            //assert
            Assert.AreEqual(2, result3);
            Assert.AreEqual("FirstName3", resultColl[0].OrderName);
            Assert.AreEqual("FirstName5", resultColl[1].OrderName);
        }
        [Test]
        public void Test1_1() {
            //arrange
            PopulateSimpleCollectionForIsNull();
            var uow = new UnitOfWork();
            //act
            var isNullCriterion = new FunctionOperator(FunctionOperatorType.IsNull, new OperandProperty(nameof(Order.Description)), new ConstantValue("WrongValue"));
            var criterion = new BinaryOperator(isNullCriterion, "WrongValue", BinaryOperatorType.Equal);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resultColl = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resultColl.Count;
            //assert
            Assert.AreEqual(2, result3);
            Assert.AreEqual("FirstName3", resultColl[0].OrderName);
            Assert.AreEqual("FirstName5", resultColl[1].OrderName);
        }
        [Test]
        public void Test1_2() {
            //arrange
            PopulateSimpleCollectionForIsNull();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                CriteriaOperator.FromLambda<Order>(oi => "WrongValue" == (oi.Description ?? "WrongValue"));
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resultColl = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resultColl.Count;
            //assert
            Assert.AreEqual(2, result3);
            Assert.AreEqual("FirstName3", resultColl[0].OrderName);
            Assert.AreEqual("FirstName5", resultColl[1].OrderName);
        }
    }
}
