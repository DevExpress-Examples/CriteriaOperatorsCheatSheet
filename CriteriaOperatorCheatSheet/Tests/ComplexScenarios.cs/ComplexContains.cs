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
    public class ComplexContains : BaseTest {
        [Test]
        public void Test0_0() {
            //arrange
            PopulateForComplex();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.Parse("[OrderItems][Company = 'testname']");
            var resCollection = new XPCollection<Order>(uow, criterion);
            var crit2 = new BinaryOperator("Company.Name", "Company10");
            var resCollection2 = uow.FindObject<OrderItem>(crit2);
            //assert
            Assert.AreEqual(1, resCollection.Count);
            Assert.AreEqual("Order1", resCollection[0].OrderName);

        }

        [Test]
        public void Test0_1() {
            //arrange
            PopulateForComplex();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = new ContainsOperator("OrderItems", new BinaryOperator(new OperandProperty("Company"), new OperandProperty("^.DefaultAddress.City"),
            BinaryOperatorType.Equal));

            var resCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual(1, resCollection.Count);
            Assert.AreEqual("Order1", resCollection[0].OrderName);

        }
    }
}
