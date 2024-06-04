using System;

namespace GildedRoseKata.ItemQualityCalculator.Specialised
{
    class ConjuredQualityCalculator : ISpecialisedItemQualityCalculator
    {
        public bool HasToBeSold => true;

        public bool CanUpdateItem(string name)
        {
            return name != null && name.StartsWith("Conjured");
        }

        public int GetNextQualityValue(int sellIn, int quality)
        {
            return Math.Max(
                quality - (sellIn > 0 ? Constants.StandardQualityIncrement * 2 : Constants.StandardQualityIncrement * 4),
                Constants.MinQuality
            );
        }
    }
}