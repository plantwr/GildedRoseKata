using Xunit;
using GildedRoseKata;
using GildedRoseKata.ItemQualityCalculator;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        private const string AgedBrie = "Aged Brie";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private const string Other = "Elixir of the Mongoose";
        private const string Conjured = "Conjured Mana Cake";

        private void UpdateQuality(Item item)
        {
            var sut = new GildedRose([item], ItemQualityCalculatorProvider.CreateDefault());
            sut.UpdateQuality();
        }

        [Theory]
        [InlineData(AgedBrie, 1, 0, 1)]
        [InlineData(AgedBrie, 0, 0, 2)]
        [InlineData(AgedBrie, -1, 0, 2)]
        [InlineData(AgedBrie, -1, 50, 50)]
        [InlineData(Sulfuras, 0, 80, 80)]
        [InlineData(Sulfuras, -1, 80, 80)]
        [InlineData(BackstagePasses, 11, 5, 6)]
        [InlineData(BackstagePasses, 11, 50, 50)]
        [InlineData(BackstagePasses, 10, 5, 7)]
        [InlineData(BackstagePasses, 6, 5, 7)]
        [InlineData(BackstagePasses, 6, 50, 50)]
        [InlineData(BackstagePasses, 5, 5, 8)]
        [InlineData(BackstagePasses, 1, 5, 8)]
        [InlineData(BackstagePasses, 1, 50, 50)]
        [InlineData(BackstagePasses, 0, 5, 0)]
        [InlineData(BackstagePasses, -1, 5, 0)]
        [InlineData(Other, 1, 1, 0)]
        [InlineData(Other, 0, 1, 0)]
        [InlineData(Other, -1, 1, 0)]
        [InlineData(Other, 1, 5, 4)]
        [InlineData(Other, 0, 5, 3)]
        [InlineData(Other, -1, 5, 3)]
        [InlineData(Conjured, 1, 1, 0)]
        [InlineData(Conjured, 0, 1, 0)]
        [InlineData(Conjured, -1, 1, 0)]
        [InlineData(Conjured, 1, 5, 3)]
        [InlineData(Conjured, 0, 5, 1)]
        [InlineData(Conjured, -1, 5, 1)]
        public void Quality(string name, int sellIn, int quality, int expectedQuality)
        {
            var item = new Item { Name = name, SellIn = sellIn, Quality = quality };
            UpdateQuality(item);
            Assert.Equal(expectedQuality, item.Quality);
        }

        [Theory]
        [InlineData(AgedBrie, 1, 0, 0)]
        [InlineData(AgedBrie, 0, 0, -1)]
        [InlineData(AgedBrie, -1, 0, -2)]
        [InlineData(Sulfuras, 0, 80, 0)]
        [InlineData(Sulfuras, -1, 80, -1)]
        [InlineData(BackstagePasses, 1, 5, 0)]
        [InlineData(BackstagePasses, 0, 5, -1)]
        [InlineData(BackstagePasses, -1, 5, -2)]
        [InlineData(Other, 1, 5, 0)]
        [InlineData(Other, 0, 5, -1)]
        [InlineData(Other, -1, 5, -2)]
        public void SellIn(string name, int sellIn, int quality, int expectedSellIn)
        {
            var item = new Item { Name = name, SellIn = sellIn, Quality = quality };
            UpdateQuality(item);
            Assert.Equal(expectedSellIn, item.SellIn);
        }
    }
}
