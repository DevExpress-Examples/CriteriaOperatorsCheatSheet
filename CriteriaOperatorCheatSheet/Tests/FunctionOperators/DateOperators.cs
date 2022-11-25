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
    public class DateOperators : BaseTest {
        [Test]
        public void Test0_0() {
            //arrange
            PopulateForDates();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
                CriteriaOperator.Parse("GetMonth(OrderDate)>2");
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resColl = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resColl.Count;
            //assert
            Assert.AreEqual(2, result3);
            Assert.AreEqual("Order22", resColl[0].OrderName);
            Assert.AreEqual("Order33", resColl[1].OrderName);
        }
        [Test]
        public void Test0_1() {
            //arrange
            PopulateForDates();
            var uow = new UnitOfWork();
            //act
            var funcOperator = new FunctionOperator(FunctionOperatorType.GetMonth, new OperandProperty(nameof(Order.OrderDate)));
            var criterion = new BinaryOperator(funcOperator, new ConstantValue(2), BinaryOperatorType.Greater);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resColl = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resColl.Count;
            //assert
            Assert.AreEqual(2, result3);
            Assert.AreEqual("Order22", resColl[0].OrderName);
            Assert.AreEqual("Order33", resColl[1].OrderName);
        }
        [Test]
        public void Test0_2() {
            //arrange
            PopulateForDates();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
                CriteriaOperator.FromLambda<Order>(o => o.OrderDate.Month > 2);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resColl = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resColl.Count;
            //assert
            Assert.AreEqual(2, result3);
            Assert.AreEqual("Order22", resColl[0].OrderName);
            Assert.AreEqual("Order33", resColl[1].OrderName);
        }


        [Test]
        public void Test1_0() {
            //arrange
            PopulateForDates();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
                CriteriaOperator.Parse("OrderDate=?", new DateTime(2022, 3, 10));
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resColl = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("Order22", resColl[0].OrderName);
        }
        [Test]
        public void Test1_1() {
            //arrange
            PopulateForDates();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
                new BinaryOperator(nameof(Order.OrderDate), new DateTime(2022, 3, 10));
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resColl = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("Order22", resColl[0].OrderName);
        }
        [Test]
        public void Test1_2() {
            //arrange
            PopulateForDates();
            var uow = new UnitOfWork();
            //act
            var requiredDate = new DateTime(2022, 3, 10);
            CriteriaOperator criterion =
                CriteriaOperator.FromLambda<Order>(o => o.OrderDate == requiredDate);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resColl = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("Order22", resColl[0].OrderName);
        }

        [Test]
        public void TestAddMilliseconds_0() {
            //arrange
            PopulateForDates_AddMilliseconds();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
                CriteriaOperator.Parse("AddMilliseconds(OrderDate,1000)=?", new DateTime(2022, 3, 10).AddMilliseconds(1000));
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resColl = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("Order22", resColl[0].OrderName);
        }
        [Test]
        public void TestAddMilliseconds_1() {
            //arrange
            PopulateForDates_AddMilliseconds();
            var uow = new UnitOfWork();
            //act
            var functionOp = new FunctionOperator(FunctionOperatorType.AddMilliSeconds, new OperandProperty(nameof(Order.OrderDate)), new ConstantValue(1000));
            var criterion = new BinaryOperator(functionOp, new DateTime(2022, 3, 10).AddMilliseconds(1000), BinaryOperatorType.Equal);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resColl = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("Order22", resColl[0].OrderName);
        }
        [Test]
        public void TestAddMilliseconds_2() {
            //arrange
            PopulateForDates_AddMilliseconds();
            var uow = new UnitOfWork();
            //act
            var targetDate = new DateTime(2022, 3, 10).AddMilliseconds(1000);
            CriteriaOperator criterion = CriteriaOperator.FromLambda<Order>(o => o.OrderDate.AddMilliseconds(1000) == targetDate);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var resColl = xpColl.OrderBy(x => x.OrderName).ToList();
            var result3 = resColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("Order22", resColl[0].OrderName);
        }
    }
}
