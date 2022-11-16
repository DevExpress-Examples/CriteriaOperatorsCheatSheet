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
    public class FilterByTypeTests : BaseTest {
        [Test]
        public void Test0_0() {
            //arrange
            PopulateForUpcasting();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
                CriteriaOperator.Parse("IsExactType(This,?)", typeof(ExtendedOrder).FullName);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(2, result3);
        }
        [Test]
        public void Test0_1() {
            //arrange
            PopulateForUpcasting();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
               new FunctionOperator(FunctionOperatorType.Custom, new ConstantValue("IsExactType"), new OperandProperty("This"), typeof(ExtendedOrder).FullName);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(2, result3);
        }
        [Test]
        public void Test0_2() {
            //arrange
            PopulateForUpcasting();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
                //Although there is no LINQ expression that generates the BetweenOperator you can solve this taks using the following expression
                CriteriaOperator.FromLambda<Order>(o => o is ExtendedOrder);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(2, result3);
        }

        [Test]
        public void Test1_0() {
            //arrange
            PopulateForUpcasting();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
                CriteriaOperator.Parse("IsInstanceOfType(This,?)", typeof(ExtendedOrder).FullName);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(2, result3);
        }
        [Test]
        public void Test1_1() {
            //arrange
            PopulateForUpcasting();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
               new FunctionOperator(FunctionOperatorType.Custom, new ConstantValue("IsInstanceOfType"), new OperandProperty("This"), typeof(ExtendedOrder).FullName);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(2, result3);
        }
        [Test]
        public void Test1_2() {
            //arrange
            PopulateForUpcasting();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
                CriteriaOperator.FromLambda<Order>(o => o is ExtendedOrder);
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(2, result3);
        }

        [Test]
        public void Test0_1Test() {
            //arrange
            PopulateForUpcasting();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
                PersistentBase.Fields.ObjectType.TypeName == typeof(ExtendedOrder).FullName;
            var xpColl = new XPCollection<Order>(uow);
            xpColl.Filter = criterion;
            var result3 = xpColl.Count;
            //assert
            Assert.AreEqual(2, result3);
        }

    }
}
