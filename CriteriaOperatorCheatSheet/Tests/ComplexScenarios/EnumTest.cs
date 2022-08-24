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
    public class EnumTest : BaseTest {
        [Test]
        public void ComplexSum_String() {
            //arrange
            PopulateForEnum();
            var uow = new UnitOfWork();
            //act
            var criterion = CriteriaOperator.Parse("Status=##Enum#dxTestSolutionXPO.Module.BusinessObjects.OrderStatusEnum,Delayed#");
            var resultCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual("order1", resultCollection[0].OrderName);
            Assert.AreEqual(1, resultCollection.Count);
        }
        [Test]
        public void ComplexSum_Typed() {
            //arrange
            PopulateForEnum();
            var uow = new UnitOfWork();
            //act
            var criterion = new BinaryOperator(nameof(Order.Status), OrderStatusEnum.Delayed);
            var resultCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual("order1", resultCollection[0].OrderName);
            Assert.AreEqual(1, resultCollection.Count);
        }
        [Test]
        public void ComplexSum_Linq() {
            //arrange
            PopulateForEnum();
            var uow = new UnitOfWork();
            //act
            var criterion = CriteriaOperator.FromLambda<Order>(x => x.Status == OrderStatusEnum.Delayed);
            var resultCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual("order1", resultCollection[0].OrderName);
            Assert.AreEqual(1, resultCollection.Count);
        }
    }
}
