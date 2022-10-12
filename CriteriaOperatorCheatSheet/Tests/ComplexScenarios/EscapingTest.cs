using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Exceptions;
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
    public class EscapingTest : BaseTest {
        [Test]
        public void Test0_0() {
            //arrange
            PopulateForEscaping();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
                CriteriaOperator.Parse("OrderName like '%der1'");
            var resCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual(1, resCollection.Count);
        }
        [Test]
        public void Test0_1() {
            //arrange
            PopulateForEscaping();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
                CriteriaOperator.Parse("[OrderName] like '%der1'");
            var resCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual(1, resCollection.Count);
        }

        [Test]
        public void Test0_2() {
            //arrange
            PopulateForEscaping();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
                CriteriaOperator.Parse("[like] like '%ike0'");
            var resCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual(1, resCollection.Count);
        }


        [Test]
        public void Test0_3() {
            //arrange
            PopulateForEscaping();
            var uow = new UnitOfWork();
            //act
            Assert.Throws<CriteriaParserException>(
            () => {
                CriteriaOperator criterion =
                CriteriaOperator.Parse("like like '%ike0'");
            }
            );
        }

        [Test]
        public void Test0_4() {
            //arrange
            PopulateForEscaping();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
                CriteriaOperator.FromLambda<Order>(o => o.like.Contains("ike0"));
            var resCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual(1, resCollection.Count);
        }

        [Test]
        public void Test0_2_1() {
            //arrange
            PopulateForEscaping();
            var uow = new UnitOfWork();
            //act
            CriteriaOperator criterion =
                CriteriaOperator.Parse("@like like '%ike0'");
            var resCollection = new XPCollection<Order>(uow, criterion);
            //assert
            Assert.AreEqual(1, resCollection.Count);
        }
    }
}
