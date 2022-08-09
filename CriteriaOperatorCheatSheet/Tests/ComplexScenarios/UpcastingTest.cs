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
    public class UpcastingTest : BaseTest {
        [Test]
        public void PlainUpcasting_String() {
            //arrange
            PopulateForUpcasting();
            var uow = new UnitOfWork();
            //act
            var criterion = CriteriaOperator.Parse("<ExtendedOrder>ExtendedDescription='description1'");
            var resultCollection = new XPCollection<Order>(uow, criterion).ToList();

            //assert
            Assert.AreEqual(1, resultCollection.Count);
            Assert.AreEqual("exOrder1", resultCollection[0].OrderName);

        }
        [Test]
        public void PlainUpcasting_Typed() {
            //arrange
            PopulateForUpcasting();
            var uow = new UnitOfWork();
            //act
            var criterion = new BinaryOperator(new OperandProperty("<ExtendedOrder>ExtendedDescription"), new OperandValue("description1"), BinaryOperatorType.Equal);
            var resultCollection = new XPCollection<Order>(uow, criterion).ToList();

            //assert
            Assert.AreEqual(1, resultCollection.Count);
            Assert.AreEqual("exOrder1", resultCollection[0].OrderName);

        }
        [Test]
        public void PlainUpcasting_Linq() {
            //arrange
            PopulateForUpcasting();
            var uow = new UnitOfWork();
            //act
            var criterion = CriteriaOperator.FromLambda<Order>(o => ((ExtendedOrder)o).ExtendedDescription == "description1");
            var resultCollection = new XPCollection<Order>(uow, criterion).ToList();

            //assert
            Assert.AreEqual(1, resultCollection.Count);
            Assert.AreEqual("exOrder1", resultCollection[0].OrderName);

        }
    }
}
