using System;
using System.Collections.Generic;

namespace Playground
{
    public class Chicken
    {
        private double _energy;
        private double _energyPerEgg;
        private int _eggsLayedToday;

        public Chicken(float energyNeededPerEgg)
        {
            _energyPerEgg = energyNeededPerEgg;
        }

        public IEnumerable<Egg> LayEggs(List<Worm> worms)
        {
            var eggs = new List<Egg>();
            foreach (var worm in worms)
            {
                var egg = EatWorm(worm);
                if (egg != null)
                {
                    eggs.Add(egg);
                }
            }

            return eggs;
        }

        private Egg EatWorm(Worm worm)
        {
            _energy += worm.Weight;
            if (_energy >= _energyPerEgg)
            {
                var egg = LayEgg();
                return egg;
            }

            return null;
        }

        public Egg LayEgg()
        {
            _energy -= _energyPerEgg;
            _eggsLayedToday++;

            const int unhealthyEggNumber = 3;
            var isHealthy = _eggsLayedToday % unhealthyEggNumber == 0;

            return new Egg(isHealthy);
        }
    }
}