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
    public class StringOperators : BaseTest {
        [Test]
        public void Test0_0() {
            //arrange
            PopulatePlainCollection();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                CriteriaOperator.Parse("EndsWith(OrderName,'1')");
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("FirstName1", xpColl[0].OrderName);
        }
        [Test]
        public void Test0_1() {
            //arrange
            PopulatePlainCollection();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                new FunctionOperator(FunctionOperatorType.EndsWith, new OperandProperty(nameof(Order.OrderName)), new ConstantValue("1"));
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("FirstName1", xpColl[0].OrderName);
        }
        [Test]
        public void Test0_2() {
            //arrange
            PopulatePlainCollection();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                CriteriaOperator.FromLambda<Order>(oi => oi.OrderName.EndsWith("1"));
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("FirstName1", xpColl[0].OrderName);
        }


        [Test]
        public void Test1_0() {
            //arrange
            PopulatePlainCollection();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                CriteriaOperator.Parse("ToStr(Price)='20'");
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("FirstName1", xpColl[0].OrderName);
        }
        [Test]
        public void Test1_1() {
            //arrange
            PopulatePlainCollection();
            var uow = new UnitOfWork();
            //act
            var strCriterion = new FunctionOperator(FunctionOperatorType.ToStr, new OperandProperty(nameof(Order.Price)));
            var criterion = new BinaryOperator(strCriterion, new ConstantValue("20"), BinaryOperatorType.Equal);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("FirstName1", xpColl[0].OrderName);
        }
        [Test]
        public void Test1_2() {
            //arrange
            PopulatePlainCollection();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion = 
                CriteriaOperator.FromLambda<Order>(oi => oi.Price.ToString() == "20");
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(1, result3);
            Assert.AreEqual("FirstName1", xpColl[0].OrderName);
        }
    }
}
