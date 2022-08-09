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
    public class ParentRelatingOperatorTest: BaseTest {
        [Test]
        public void ParentRelating_String() {
            //arrange
            PopulateForComplexParentRelating();
            var uow = new UnitOfWork();
            //act
            var criterion = CriteriaOperator.Parse("[OrderItems][[^.OrderDate] == RegistrationDate]");
            var resultCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual(new DateTime(2022, 8, 3), resultCollection[0].OrderDate);
            Assert.AreEqual("order1", resultCollection[0].OrderName);
            Assert.AreEqual(1, resultCollection.Count);
        }
        [Test]
        public void ParentRelating_Typed() {
            //arrange
            PopulateForComplexParentRelating();
            var uow = new UnitOfWork();
            //act
            var binaryOperator = new BinaryOperator(new OperandProperty("^.OrderDate"), new OperandProperty(nameof(OrderItem.RegistrationDate)),BinaryOperatorType.Equal);
            var criterion = new AggregateOperand(nameof(Order.OrderItems), Aggregate.Exists, binaryOperator);
            var resultCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual(new DateTime(2022, 8, 3), resultCollection[0].OrderDate);
            Assert.AreEqual("order1", resultCollection[0].OrderName);
            Assert.AreEqual(1, resultCollection.Count);
        }
        [Test]
        public void ParentRelating_Linq() {
            //arrange
            PopulateForComplexParentRelating();
            var uow = new UnitOfWork();
            //act
            var criterion = CriteriaOperator.FromLambda<Order>(o => o.OrderItems.Any(oi => oi.RegistrationDate == o.OrderDate));
            var resultCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual(new DateTime(2022, 8, 3), resultCollection[0].OrderDate);
            Assert.AreEqual("order1", resultCollection[0].OrderName);
            Assert.AreEqual(1, resultCollection.Count);
        }
    }
}
