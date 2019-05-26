using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Playground.Tests.X;

namespace Playground.Tests.N
{
    [TestFixture]
    public class ChickenTests
    {
        private Hatchery _hatchery;

        [Theory]
        [TestCase(new[] { 5.6, 1.44, 2.7, 3.4, 2.2 }, ChickenType.Productive, 5)]
        [TestCaseSource(typeof(ChickenEatNormalTestData))]
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

        [Test]
        public void HatchEgg_AfterEating_JustEnough_Worms_Ok()
        {
            var chic = new Chicken(1);
            var worms = new List<Worm>() { new Worm(1) };

            var eggs = chic.LayEggs(worms);
            eggs.Should().NotContainNulls()
                .And.HaveCount(1);
        }

        [OneTimeSetUp]
        public void InitTestSuite()
        {
            _hatchery = new Hatchery();
        }

        [SetUp]
        public void InitTestCase()
        {
            _hatchery = new Hatchery();
        }

        [OneTimeTearDown]
        public void CleanTestSuite()
        {

        }

        [TearDown]
        public void CleanTestCase()
        {

        }
    }
}
