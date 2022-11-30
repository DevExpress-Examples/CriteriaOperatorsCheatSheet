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
    public class IIfOperator : BaseTest {
        [Test]
        public void Test0_0() {
            //arrange
            PopulateForIif();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                CriteriaOperator.Parse("OrderColor=Iif(OrderType='Type1','Blue',OrderType='Type2','Orange','SomeNullValue')");
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resultList = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resultList.Count;
            //assert
            Assert.AreEqual(2, result3);
            Assert.AreEqual("Order2", resultList[0].OrderName);
            Assert.AreEqual("Order4", resultList[1].OrderName);
        }
        [Test]
        public void Test0_1() {
            //arrange
            PopulateForIif();
            var uow = new UnitOfWork();
            //act
            var iifOperator = new FunctionOperator(FunctionOperatorType.Iif, new BinaryOperator(nameof(Order.OrderType), "Type1"), new ConstantValue("Blue"), new BinaryOperator(nameof(Order.OrderType), "Type2"), new ConstantValue("Orange"), new ConstantValue("SomeNullValue"));
            var finalCriterion = new BinaryOperator(nameof(Order.OrderColor), iifOperator);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = finalCriterion;
            var resultList = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resultList.Count;
            //assert
            Assert.AreEqual(2, result3);
            Assert.AreEqual("Order2", resultList[0].OrderName);
            Assert.AreEqual("Order4", resultList[1].OrderName);
        }
        [Test]
        public void Test0_2() {
            //arrange
            PopulateForIif();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                CriteriaOperator.FromLambda<Order>(o => o.OrderColor == (o.OrderType == "Type1" ? "Blue" : o.OrderType == "Type2" ? "Orange" : "SomeNullValue"));
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resultList = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resultList.Count;
            //assert
            Assert.AreEqual(2, result3);
            Assert.AreEqual("Order2", resultList[0].OrderName);
            Assert.AreEqual("Order4", resultList[1].OrderName);
        }

    }
}
