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
    public class BetweenOperatorTest : BaseTest {
        [Test]
        public void Test0_0() {
            //arrange
            PopulateSimpleCollectionForMaxMin();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.Parse("[ItemPrice] Between(10,30)");
            var xpColl = new XPCollection<OrderItem>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(3, result3);
        }
        [Test]
        public void Test0_1() {
            //arrange
            PopulateSimpleCollectionForMaxMin();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = new BetweenOperator(nameof(OrderItem.ItemPrice), 10, 30);
            var xpColl = new XPCollection<OrderItem>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(3, result3);
        }

        [Test]
        public void Test0_2() {
            //arrange
            PopulateSimpleCollectionForMaxMin();
            var uow = new UnitOfWork();
            //act
            //Although there is no LINQ expression that generates the BetweenOperator you can solve this taks using the following expression
            CriteriaOperator criterion = CriteriaOperator.FromLambda<OrderItem>(oi => oi.ItemPrice >= 10 && oi.ItemPrice <= 30);
            var xpColl = new XPCollection<OrderItem>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(3, result3);
        }

    }
}
