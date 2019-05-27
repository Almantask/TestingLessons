using System;

namespace Playground.Tests.X
{
    public class ChickenTestsFixture:IDisposable
    {
        public Hatchery Hatchery;

        // Test suite setup
        public ChickenTestsFixture()
        {
            Hatchery = new Hatchery();
        }

        // Test suite cleanup
        public void Dispose()
        {
        }
    }
}