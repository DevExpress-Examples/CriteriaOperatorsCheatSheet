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
    public class BinaryOperatorTest : BaseTest {
        [Test]
        public void Test0_0() {
            //arrange
            PopulateSimpleCollectionForBinary();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.Parse("Price>=50");
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(2, result3);
        }
        [Test]
        public void Test0_1() {
            //arrange
            PopulateSimpleCollectionForBinary();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = new BinaryOperator(nameof(Order.Price), 50, BinaryOperatorType.GreaterOrEqual);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(2, result3);
        }
        [Test]
        public void Test0_2() {
            //arrange
            PopulateSimpleCollectionForBinary();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.FromLambda<Order>(o => o.Price >= 50);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(2, result3);
        }
    }
}
