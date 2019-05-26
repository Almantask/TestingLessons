using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Playground.Tests.X;

namespace Playground.Tests.M
{
    [TestClass]
    public class ChickenTests
    {
        private static Hatchery _hatchery;

        [DataRow(new[] { 5.6, 1.44, 2.7, 3.4, 2.2 }, ChickenType.Productive, 5)]
        [DataTestMethod]
        [DynamicData(nameof(GetChickenEatNormalTestData), DynamicDataSourceType.Method)]
        public void HatchEgg_Ok(double[] wormWeights, ChickenType chieckenType, int epxectedEggCount)
        {
            var chic = _hatchery.Create(chieckenType);
            var worms = new List<Worm>();
            foreach (var weight in wormWeights)
            {
                var worm = new Worm(weight);
                worms.Add(worm);
            }

            var eggs = chic.LayEggs(worms);
            eggs.Should().NotContainNulls()
                .And.HaveCount(epxectedEggCount);
        }

        private static IEnumerable<object[]> GetChickenEatNormalTestData()
        {
            {
                yield return new object[] { new double[] { 1, 1, 1, 1, 1 }, ChickenType.Productive, 5 };
                yield return new object[] { new double[] { 1, 5, 1, 0, 1 }, ChickenType.Productive, 5 };
            }
        }

        [TestMethod]
        public void HatchEgg_AfterEating_JustEnough_Worms_Ok()
        {
            var chic = new Chicken(1);
            var worms = new List<Worm> { new Worm(1) };

            var eggs = chic.LayEggs(worms);
            eggs.Should().NotContainNulls()
                .And.HaveCount(1);
        }

        [TestInitialize]
        public void SetupTestCase()
        {
            _hatchery = new Hatchery();
        }

        [ClassInitialize]
        public static void SetupTestSuite(TestContext context)
        {
            _hatchery = new Hatchery();
        }

        [TestCleanup]
        public void CleanupTestCase()
        {

        }


        [ClassCleanup]
        public static void CleanupTestSuite()
        {

        }
    }
}
