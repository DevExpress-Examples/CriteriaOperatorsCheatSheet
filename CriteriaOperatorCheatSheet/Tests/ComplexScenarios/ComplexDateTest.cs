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
    public class ComplexDateTest : BaseTest {
        [Test]
        public void DateDiff2Week_String() {
            //arrange
            PopulateForComplexDateTwoWeek();
            var uow = new UnitOfWork();
            //act
            var criterion = CriteriaOperator.Parse("OrderDate >= AddDays(#2022-08-09#, -14)  && OrderDate < #2022-08-09#");
            var resultCollection = new XPCollection<Order>(uow, criterion);
            var filteredResult = resultCollection.OrderBy(x => x.OrderName).ToList();
            //assert
            Assert.AreEqual(3, filteredResult.Count);
            Assert.AreEqual("order0", filteredResult[0].OrderName);
            Assert.AreEqual("order2", filteredResult[1].OrderName);
            Assert.AreEqual("order4", filteredResult[2].OrderName);

        }
        [Test]
        public void DateDiff2Week_Typed() {
            //arrange
            PopulateForComplexDateTwoWeek();
            var uow = new UnitOfWork();
            //act
            var targetDate = new DateTime(2022, 8, 9);
            var startDateCriterion = new FunctionOperator(FunctionOperatorType.AddDays, new OperandValue(targetDate),new OperandValue(-14));
            var startOperator = new BinaryOperator(new OperandProperty(nameof(Order.OrderDate)), startDateCriterion, BinaryOperatorType.GreaterOrEqual);
            var endOperator = new BinaryOperator(new OperandProperty(nameof(Order.OrderDate)), new OperandValue(targetDate), BinaryOperatorType.Less);

            var criterion=new GroupOperator(GroupOperatorType.And,startOperator, endOperator);

            var resultCollection = new XPCollection<Order>(uow, criterion);
            var filteredResult = resultCollection.OrderBy(x => x.OrderName).ToList();
            //assert
            Assert.AreEqual(3, filteredResult.Count);
            Assert.AreEqual("order0", filteredResult[0].OrderName);
            Assert.AreEqual("order2", filteredResult[1].OrderName);
            Assert.AreEqual("order4", filteredResult[2].OrderName);
        }

        [Test]
        public void DateDiff2Week_Linq() {
            //arrange
            PopulateForComplexDateTwoWeek();
            var uow = new UnitOfWork();
            //act
            var targetDate = new DateTime(2022, 8, 9);
            var criterion = CriteriaOperator.FromLambda<Order>(o => o.OrderDate >= targetDate.AddDays(-14) && o.OrderDate < targetDate);

            var resultCollection = new XPCollection<Order>(uow, criterion);
            var filteredResult = resultCollection.OrderBy(x => x.OrderName).ToList();
            //assert
            Assert.AreEqual(3, filteredResult.Count);
            Assert.AreEqual("order0", filteredResult[0].OrderName);
            Assert.AreEqual("order2", filteredResult[1].OrderName);
            Assert.AreEqual("order4", filteredResult[2].OrderName);
        }
    }
}
