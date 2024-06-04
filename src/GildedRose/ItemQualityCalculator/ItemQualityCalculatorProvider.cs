using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata.ItemQualityCalculator
{
    public class ItemQualityCalculatorProvider : IItemQualityCalculatorProvider
    {
        public static ItemQualityCalculatorProvider CreateDefault()
        {
            return new ItemQualityCalculatorProvider([
                new AgedBrieQualityCalculator(),
                new BackstagePassesQualityCalculator(),
                new ConjuredQualityCalculator(),
                new SulfurasQualityCalculator()
            ]);
        }

        private static readonly IItemQualityCalculator _defaultCalculator = new DefaultQualityCalculator();

        private readonly IEnumerable<IItemQualityCalculator> _specialisedCalculators;

        public ItemQualityCalculatorProvider(IEnumerable<IItemQualityCalculator> specialisedCalculators)
        {
            _specialisedCalculators = specialisedCalculators;
        }

        public IItemQualityCalculator Get(string name)
        {
            var calculator = _specialisedCalculators.FirstOrDefault(calc => calc.CanUpdateItem(name));
            return calculator ?? _defaultCalculator;
        }
    }
}