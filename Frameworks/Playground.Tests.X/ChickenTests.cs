using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Playground.Tests.X
{
    public class ChickenTests:IClassFixture<ChickenTestsFixture>, IDisposable
    {
        private Hatchery _hatchery;

        // Test case setup.
        public ChickenTests()
        {
        }

        // Test suite setup.
        public ChickenTests(ChickenTestsFixture fixture)
        {
            _hatchery = fixture.Hatchery;
        }

        [Theory]
        [InlineData(new[] { 5.6, 1.44, 2.7, 3.4, 2.2 }, ChickenType.Productive, 5)]
        [ClassData(typeof(ChickenEatNormalTestData))]
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

        [Fact]
        public void HatchEgg_AfterEating_JustEnough_Worms_Ok()
        {
            var chic = new Chicken(1);
            var worms = new List<Worm>() {new Worm(1)};

            var eggs = chic.LayEggs(worms);
            eggs.Should().NotContainNulls()
                .And.HaveCount(1);
        }

        // Test case cleanup
        public void Dispose()
        {

        }
    }
}
