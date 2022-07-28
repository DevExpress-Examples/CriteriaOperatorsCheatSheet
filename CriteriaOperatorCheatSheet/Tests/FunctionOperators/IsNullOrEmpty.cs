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
    public class FunctionOperator_IsNullOrEmpty : BaseTest {
        [Test]
        public void Test0_0() {
            //arrange
            PopulateSimpleCollectionForIsNullOrEmpty();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.Parse("IsNullOrEmpty(Description)");
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("FirstName3", xpColl[0].OrderName);
        }
        [Test]
        public void Test0_1() {
            //arrange
            PopulateSimpleCollectionForIsNullOrEmpty();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = new FunctionOperator(FunctionOperatorType.IsNullOrEmpty, new CriteriaOperator[] { new OperandProperty(nameof(Order.Description)) });
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("FirstName3", xpColl[0].OrderName);
        }
        [Test]
        public void Test0_2() {
            //arrange
            PopulateSimpleCollectionForIsNullOrEmpty();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.FromLambda<Order>(o => string.IsNullOrEmpty(o.Description));
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("FirstName3", xpColl[0].OrderName);
        }
    }
}
