using System;

namespace GildedRoseKata.ItemQualityCalculator.Specialised
{
    class BackstagePassesQualityCalculator : ISpecialisedItemQualityCalculator
    {
        public bool HasToBeSold => true;

        public bool CanUpdateItem(string name)
        {
            return name != null && name.StartsWith("Backstage passes");
        }

        public int GetNextQualityValue(int sellIn, int quality)
        {
            if (sellIn <= 0)
            {
                return 0;
            }

            if (sellIn <= 5)
            {
                return Math.Min(quality + 3, Constants.MaxQuality);
            }

            if (sellIn <= 10)
            {
                return Math.Min(quality + 2, Constants.MaxQuality);
            }

            return Math.Min(quality + Constants.StandardQualityIncrement, Constants.MaxQuality);
        }
    }
}