using System;

namespace GildedRoseKata.ItemQualityCalculator
{
    class DefaultQualityCalculator : IItemQualityCalculator
    {
        public bool HasToBeSold => true;

        public bool CanUpdateItem(string name)
        {
            return true;
        }

        public int GetNextQualityValue(int sellIn, int quality)
        {
            return Math.Max(
                quality - (sellIn > 0 ? Constants.StandardQualityIncrement : Constants.StandardQualityIncrement * 2),
                Constants.MinQuality
            );
        }
    }
}