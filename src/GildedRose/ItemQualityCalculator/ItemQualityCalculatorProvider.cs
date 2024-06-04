using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GildedRoseKata.ItemQualityCalculator.Specialised;

namespace GildedRoseKata.ItemQualityCalculator
{
    public class ItemQualityCalculatorProvider : IItemQualityCalculatorProvider
    {
        public static ItemQualityCalculatorProvider Create()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(ISpecialisedItemQualityCalculator)) && t.GetConstructor(Type.EmptyTypes) != null)
                .ToList();

            var instances = new List<ISpecialisedItemQualityCalculator>();
            foreach (var type in types)
            {
                var instance = (ISpecialisedItemQualityCalculator)Activator.CreateInstance(type);
                instances.Add(instance);
            }

            return new ItemQualityCalculatorProvider(instances);
        }

        private static readonly IItemQualityCalculator _defaultCalculator = new DefaultQualityCalculator();

        private readonly IEnumerable<ISpecialisedItemQualityCalculator> _specialisedCalculators;

        public ItemQualityCalculatorProvider(IEnumerable<ISpecialisedItemQualityCalculator> specialisedCalculators)
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