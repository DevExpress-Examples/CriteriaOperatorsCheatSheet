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
    public class Aggregate_Count : BaseTest {
        [Test]
        public void Task1_PlainCount_1() {
            PopulatePlainCollection();
            var uow = new UnitOfWork();
            CriteriaOperator criterion = 
                CriteriaOperator.Parse("Count()");
            var result = uow.Evaluate<Order>(criterion, null);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Task1_PlainCount_2() {
            PopulatePlainCollection();
            var uow = new UnitOfWork();
            CriteriaOperator criterion = 
                new AggregateOperand(null, Aggregate.Count);
            var result = uow.Evaluate<Order>(criterion, null);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Task1_PlainCount_3() {
            PopulatePlainCollection();

            var uow = new UnitOfWork();
            CriteriaOperator criterion = 
                CriteriaOperator.FromLambda<Order, double>(x => FromLambdaFunctions.TopLevelAggregate<Order>().Count());

            var result = uow.Evaluate<Order>(criterion, null);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Task2_CountСollection_1() {
            PopulateComplexCollection();
            var uow = new UnitOfWork();
            CriteriaOperator criterion = 
                CriteriaOperator.Parse("OrderItems.Count()>1");
            var result = new XPCollection<Order>(uow, criterion).ToList();
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void Task2_CountСollection_2() {
            PopulateComplexCollection();
            var uow = new UnitOfWork();
            CriteriaOperator criterion = 
                new AggregateOperand(nameof(Order.OrderItems), Aggregate.Count);
            var crit2 = new BinaryOperator(criterion, 1, BinaryOperatorType.Greater);
            var result = new XPCollection<Order>(uow, crit2).ToList();
            Assert.AreEqual(2, result.Count);
        }
        [Test]
        public void Task2_CountСollection_3() {
            PopulateComplexCollection();
            var uow = new UnitOfWork();
            CriteriaOperator criterion = 
                CriteriaOperator.FromLambda<Order>(x => x.OrderItems.Count() > 1);
            var result = new XPCollection<Order>(uow, criterion).ToList();
            Assert.AreEqual(2, result.Count);
        }


        [Test]
        public void Task3_CountCriteria_1() {
            PopulateComplexCollectionWithAvailable();
            var uow = new UnitOfWork();
            CriteriaOperator criterion = 
                CriteriaOperator.Parse("[OrderItems][IsAvailable=true].Count()>0");
            var result = new XPCollection<Order>(uow, criterion).ToList();
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void Task3_CountCriteria_2() {
            PopulateComplexCollectionWithAvailable();
            var uow = new UnitOfWork();
            var criterion = new AggregateOperand(nameof(Order.OrderItems), Aggregate.Count, new BinaryOperator(nameof(OrderItem.IsAvailable), true));
            var resultCriterion = new BinaryOperator(criterion, 0, BinaryOperatorType.Greater);
            var result = new XPCollection<Order>(uow, resultCriterion).ToList();
            Assert.AreEqual(2, result.Count);
        }
        [Test]
        public void Task3_CountCriteria_3() {
            PopulateComplexCollectionWithAvailable();
            var uow = new UnitOfWork();
            CriteriaOperator criterion = 
                CriteriaOperator.FromLambda<Order>(x => x.OrderItems.Count(i => i.IsAvailable == true) > 0);
            var result = new XPCollection<Order>(uow, criterion).ToList();
            Assert.AreEqual(2, result.Count);
        }
    }
}
