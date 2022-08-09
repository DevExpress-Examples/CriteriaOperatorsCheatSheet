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
    [TestFixture(Ignore =true)]
    public class Complex : BaseTest {
        [Test]
        public void GetMax() {
            //arrange
            PopulateСollectionWithActive();
            var uow = new UnitOfWork();
            var join = new JoinOperand("Order", null, Aggregate.Max, new OperandProperty("Price"));
            var join2 = new BinaryOperator(nameof(Order.Price), join);
            //act
            var joinRes = new XPCollection<Order>(uow, join2).ToList();
            //assert
            Assert.AreEqual(50, joinRes[0].Price);

        }

        [Test]
        public void Test0_2() {
            //arrange
            PopulateSimpleCollectionForMaxMinTest();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = CriteriaOperator.FromLambda<OrderItem>(oi => oi.ItemPrice >= 10 && oi.ItemPrice < 30);

            var xpColl = new XPCollection<OrderItem>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(3, result3);


            CriteriaOperator criterion2 = CriteriaOperator.FromLambda<Order>(o => o.OrderItems.Any(oi => oi.ItemPrice == o.Price));
            var xpColl2 = new XPCollection<Order>(uow);
            xpColl2.Filter = criterion2;
            var col = xpColl2.ToList();
            var result4 = xpColl.Count;

        }
        [Test]
        public void Test0_3() {
            //arrange
            PopulateSimpleCollectionForMaxMinTest();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion2 = CriteriaOperator.FromLambda<Order>(o => o.OrderItems.Any(oi => oi.ItemPrice == o.Price));
            var xpColl2 = new XPCollection<Order>(uow);
            xpColl2.Filter = criterion2;
            var col = xpColl2.ToList();
            var result4 = xpColl2.Count;
            Assert.AreEqual(1, result4);

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
