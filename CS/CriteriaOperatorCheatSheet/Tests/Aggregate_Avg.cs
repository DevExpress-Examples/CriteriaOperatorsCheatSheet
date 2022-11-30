using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using dxTestSolutionXPO.Module.BusinessObjects;
using dxTestSolutionXPO.Tests;
using NUnit.Framework;
using System;
using System.Linq;

namespace dxTestSolutionXPO {
    [TestFixture]
    public class CriteriaOperatorAvg: BaseTest {
     
    

        [Test]
        public void Task1_PlainCollection_1() {
            PopulatePlainCollection();
            CriteriaOperator criterion = 
                CriteriaOperator.Parse("Avg(Price)");
            var uow = new UnitOfWork();
            var result = uow.Evaluate<Order>(criterion, null);
            Assert.AreEqual(15, result);
        }
        [Test]
        public void Task1_PlainCollection_2() {
            PopulatePlainCollection();
            CriteriaOperator criterion = 
                new AggregateOperand(null, nameof(Order.Price), Aggregate.Avg);
            var uow = new UnitOfWork();
            var res = uow.Evaluate<Order>(criterion, null);
            Assert.AreEqual(15, res);
        }
        [Test]
        public void Task1_PlainCollection_3() {
            PopulatePlainCollection();
            CriteriaOperator criterion = 
                CriteriaOperator.FromLambda<Order, double>(x => FromLambdaFunctions.TopLevelAggregate<Order>().Average(c => c.Price));
            var uow = new UnitOfWork();
            var res = uow.Evaluate<Order>(criterion, null);
            Assert.AreEqual(15, res);
        }
        [Test]
        public void Task2_PlainCollection_Crit_1() {
            PopulateСollectionWithActive();
            var crit = 
                CriteriaOperator.Parse("Avg(Price)");
            var crit2 = CriteriaOperator.Parse("IsActive=true");
            var uow = new UnitOfWork();
            var res = uow.Evaluate<Order>(crit, crit2);
            Assert.AreEqual(40, res);
        }
        [Test]
        public void Task2_PlainCollection_Crit_2() {
            PopulateСollectionWithActive();
            var crit = new AggregateOperand(null, nameof(Order.Price), Aggregate.Avg);
            var crit2 = new BinaryOperator(nameof(Order.IsActive), true);
            var uow = new UnitOfWork();
            var res = uow.Evaluate<Order>(crit, crit2);
            Assert.AreEqual(40, res);
        }
   
        [Test]
        public void Task2_PlainCollection_Crit_3() {
            PopulateСollectionWithActive();
            var crit = CriteriaOperator.FromLambda<Order, double>(x => FromLambdaFunctions.TopLevelAggregate<Order>().Average(c => c.Price));
            var crit2 = CriteriaOperator.FromLambda<Order>(x => x.IsActive);
            var uow = new UnitOfWork();
            var res = uow.Evaluate<Order>(crit, crit2);
            Assert.AreEqual(40, res);
        }
   
      

        [Test]
        public void Task3_SelectFromCollection_1() {
            PopulateSelectFromCollection();
            var uow = new UnitOfWork();
            var crit = 
                CriteriaOperator.Parse("OrderItems.Avg(ItemPrice)>100");
            var res = new XPCollection<Order>(uow, crit).OrderBy(x=>x.OrderName).ToList();
            Assert.AreEqual(2, res.Count);
            Assert.AreEqual("FirstName1", res[0].OrderName);
            Assert.AreEqual("FirstName3", res[1].OrderName);
        }

        [Test]
        public void Task3_SelectFromCollection_2() {
            PopulateSelectFromCollection();
            var uow = new UnitOfWork();
            var aggrCriterion = new AggregateOperand(nameof(Order.OrderItems), nameof(OrderItem.ItemPrice) , Aggregate.Avg);
            var resultCriterion = new BinaryOperator(aggrCriterion, 100, BinaryOperatorType.Greater);
            var res = new XPCollection<Order>(uow, resultCriterion).OrderBy(x => x.OrderName).ToList();
            Assert.AreEqual(2, res.Count);
            Assert.AreEqual("FirstName1", res[0].OrderName);
            Assert.AreEqual("FirstName3", res[1].OrderName);
        }

        [Test]
        public void Task3_SelectFromCollection_3() {
            PopulateSelectFromCollection();
            var uow = new UnitOfWork();
            var crit = 
                CriteriaOperator.FromLambda<Order>(x => x.OrderItems.Average(t => t.ItemPrice) > 100);
            var res = new XPCollection<Order>(uow, crit).OrderBy(x=>x.OrderName).ToList();
            Assert.AreEqual(2, res.Count);
            Assert.AreEqual("FirstName1", res[0].OrderName);
            Assert.AreEqual("FirstName3", res[1].OrderName);
        }

    }
   
}
