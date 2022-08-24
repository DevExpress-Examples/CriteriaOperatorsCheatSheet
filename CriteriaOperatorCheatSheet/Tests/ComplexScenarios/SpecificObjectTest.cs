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
    public class SpecificObjectTest : BaseTest {
        [Test]
        public void SpecificObject_String() {
            //arrange
            PopulateForComplex();
            var uow = new UnitOfWork();
            //act
            using(uow.CreateParseCriteriaSessionScope()) {
                var criterion = CriteriaOperator.Parse("Order=##XpoObject#dxTestSolutionXPO.Module.BusinessObjects.Order(2)#");
                var resultCollection = new XPCollection<OrderItem>(uow, criterion).OrderBy(x => x.OrderItemName).ToList();

                //assert
                Assert.AreEqual(2, resultCollection.Count);
                Assert.AreEqual("Item1-1", resultCollection[0].OrderItemName);
                Assert.AreEqual("Item1-2", resultCollection[1].OrderItemName);
            }
        }
        [Test]
        public void SpecificObject_Typed() {
            //arrange
            PopulateForComplex();
            var uow = new UnitOfWork();
            //act
            var obj = uow.GetObjectByKey<Order>(2);
            var criterion = new BinaryOperator(nameof(OrderItem.Order), obj);
            var resultCollection = new XPCollection<OrderItem>(uow, criterion).OrderBy(x => x.OrderItemName).ToList();

            //assert
            Assert.AreEqual(2, resultCollection.Count);
            Assert.AreEqual("Item1-1", resultCollection[0].OrderItemName);
            Assert.AreEqual("Item1-2", resultCollection[1].OrderItemName);
        }
        [Test]
        public void SpecificObject_Linq() {
            //arrange
            PopulateForComplex();
            var uow = new UnitOfWork();
            //act
            var obj = uow.GetObjectByKey<Order>(2);
            var criterion = CriteriaOperator.FromLambda<OrderItem>(x => x.Order == obj);
            var resultCollection = new XPCollection<OrderItem>(uow, criterion).OrderBy(x => x.OrderItemName).ToList();

            //assert
            Assert.AreEqual(2, resultCollection.Count);
            Assert.AreEqual("Item1-1", resultCollection[0].OrderItemName);
            Assert.AreEqual("Item1-2", resultCollection[1].OrderItemName);
        }
    }
}
