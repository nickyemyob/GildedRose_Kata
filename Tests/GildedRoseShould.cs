using System.Collections.Generic;
using csharp.Logic;
using NUnit.Framework;

namespace csharp.Tests
{
    [TestFixture]
    public class GildedRoseShould
    {
        

        [Test]
        public void DecreaseTheSellInOfAnItemByOne()
        {
            IList<Item> actualItems = new List<Item> { new Item { Name = "apple", SellIn = 1, Quality = 1 } };
            var qualityUpdater = new GildedRose(actualItems);
            
            qualityUpdater.UpdateQuality();

            var expectedItems = new List<Item> { new Item { Name = "apple", SellIn = 0, Quality = 0 } };
            Assert.AreEqual(expectedItems[0].SellIn, actualItems[0].SellIn);
            
        }

        [Test]
        public void DecreaseTheQualityOfAnItemByOne()
        {
            IList<Item> actualItems = new List<Item> { new Item { Name = "apple", SellIn = 1, Quality = 1 } };
            var qualityUpdater = new GildedRose(actualItems);
            
            qualityUpdater.UpdateQuality();

            var expectedItems = new List<Item> { new Item { Name = "apple", SellIn = 0, Quality = 0 } };
            Assert.AreEqual(expectedItems[0].Quality, actualItems[0].Quality);

        }

        [Test]
        public void DecreaseTheQualityTwiceAsFastWhenSellInReachesZero()
        {
            IList<Item> actualItems = new List<Item> { new Item { Name = "apple", SellIn = 0, Quality = 5 } };
            var qualityUpdater = new GildedRose(actualItems);

            qualityUpdater.UpdateQuality();

            var expectedItems = new List<Item> { new Item { Name = "apple", SellIn = 0, Quality = 3 } };
            Assert.AreEqual(expectedItems[0].Quality, actualItems[0].Quality);

        }

        [Test]
        public void NotDecreaseTheQualityWhenThereIsNoQualityLeft()
        {
            IList<Item> actualItems = new List<Item> { new Item { Name = "apple", SellIn = 0, Quality = 0 } };
            var qualityUpdater = new GildedRose(actualItems);
            
            qualityUpdater.UpdateQuality();

            var expectedItems = new List<Item> { new Item { Name = "apple", SellIn = 0, Quality = 0 } };
            Assert.AreEqual(expectedItems[0].Quality, actualItems[0].Quality);

        }

        private static readonly object[] AgedBrieScenarios =
        {
            new object[] {new Item{ Name = "Aged Brie", SellIn = 4, Quality = 6 }, new Item{ Name = "Aged Brie", SellIn = 5, Quality = 5 }},
            new object[] {new Item{ Name = "Aged Brie", SellIn = 0, Quality = 6 }, new Item{ Name = "Aged Brie", SellIn = 5, Quality = 5 }},
            new object[] {new Item{ Name = "Aged Brie", SellIn = -1, Quality = 7 }, new Item{ Name = "Aged Brie", SellIn = 0, Quality = 5 }}

        };

        [Test]
        [TestCaseSource(nameof(AgedBrieScenarios))]
        public void IncreaseTheQualityOfAgedBrieWhenOlder(Item expected, Item initialState)
        {
            IList<Item> actualItems = new List<Item> {initialState};
            var qualityUpdater = new GildedRose(actualItems);
            
            qualityUpdater.UpdateQuality();

            var expectedItems = new List<Item> {expected};
            Assert.AreEqual(expectedItems[0].Quality, actualItems[0].Quality);
            
        }
    }
}
