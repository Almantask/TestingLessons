using System.Collections;
using System.Collections.Generic;

namespace Playground.Tests.X
{
    public class ChickenEatNormalTestData: IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            {
                yield return new object[] {new double[] {1, 1, 1, 1, 1}, ChickenType.Productive, 5};
                yield return new object[] { new double[] { 1, 5, 1, 0, 1 }, ChickenType.Productive, 5 };
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}