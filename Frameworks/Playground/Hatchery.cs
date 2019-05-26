using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    // Let's say heavy component
    public class Hatchery
    {
        public Chicken Create(ChickenType chickenType)
        {
            var energyNeededPerEgg = 0;
            switch (chickenType)
            {
                case ChickenType.Lazy:
                    energyNeededPerEgg = 10;
                    break;
                case ChickenType.Productive:
                    energyNeededPerEgg = 1;
                    break;
                default:
                    throw new NotImplementedException("No chicken of the type provided");
            }
            return new Chicken(energyNeededPerEgg);
        }
    }
}
