using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using dxTestSolutionXPO.Module.BusinessObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxTestSolutionXPO.Tests.FunctionOperators {
    [TestFixture]
    public class StringOperators2: BaseTest {
        [Test]
        public void Test0_0() {
            //arrange
            PopulatePlainCollectionForConcat();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
                CriteriaOperator.Parse("OrderName=Concat('Test','Value')");
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual(10, xpColl[0].Price);
        }
        [Test]
        public void Test0_1() {
            //arrange
            PopulatePlainCollectionForConcat();
            var uow = new UnitOfWork();
            //act

            var concatOperator = new FunctionOperator(FunctionOperatorType.Concat, "Test", "Value");
            CriteriaOperator criterion =
               new BinaryOperator(nameof(Order.OrderName), concatOperator);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual(10, xpColl[0].Price);
        }
        [Test]
        public void Test0_2() {
            //arrange
            PopulatePlainCollectionForConcat();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
                //CriteriaOperator.Parse("OrderName=Concat('Test','Value')");
                CriteriaOperator.FromLambda<Order>(o=>o.OrderName=="Test"+"Value");
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual(10, xpColl[0].Price);
        }
    }
}
