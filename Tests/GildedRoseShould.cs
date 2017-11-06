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
        public void DecreaseTheQualityTwiceAsFastWhenPastSellInDate()
        {
            IList<Item> actualItems = new List<Item> { new Item { Name = "apple", SellIn = -1, Quality = 5 } };
            var qualityUpdater = new GildedRose(actualItems);

            qualityUpdater.UpdateQuality();

            var expectedItems = new List<Item> { new Item { Name = "apple", SellIn = -2, Quality = 3 } };
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

        private static readonly object[] QualityIncreaseScenarios =
        {
            new object[] {new Item{ Name = "Aged Brie", SellIn = 4, Quality = 50 }, new Item{ Name = "Aged Brie", SellIn = 5, Quality = 50 }},
            new object[] {new Item{ Name = "Aged Brie", SellIn = 4, Quality = 50 }, new Item{ Name = "Aged Brie", SellIn = 5, Quality = 49 }},
            new object[] {new Item{ Name = "Aged Brie", SellIn = -1, Quality = 50 }, new Item{ Name = "Aged Brie", SellIn = 0, Quality = 49 }},
            new object[] {new Item{ Name = "Aged Brie", SellIn = -1, Quality = 50 }, new Item{ Name = "Aged Brie", SellIn = 0, Quality = 50 }}

        };

        [Test]
        [TestCaseSource(nameof(QualityIncreaseScenarios))]
        public void NotIncreaseTheQualityOfAnItemMoreThan50(Item expected, Item initialState)
        {
            IList<Item> actualItems = new List<Item> { initialState };
            var qualityUpdater = new GildedRose(actualItems);

            qualityUpdater.UpdateQuality();

            var expectedItems = new List<Item> { expected };
            Assert.AreEqual(expectedItems[0].Quality, actualItems[0].Quality);

        }

        private static readonly object[] SulfurasNotSellingScenarios =
        {
            new object[] {new Item{ Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 50 }, new Item{ Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 50 }},
            new object[] {new Item{ Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 50 }, new Item{ Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 50 }},
            new object[] {new Item{ Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 50 }, new Item{ Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 50 }}

        };

        [Test]
        [TestCaseSource(nameof(SulfurasNotSellingScenarios))]
        public void NotDecreaseQualityForSulfuras(Item expected, Item initialState)
        {
            IList<Item> actualItems = new List<Item> { initialState };
            var qualityUpdater = new GildedRose(actualItems);

            qualityUpdater.UpdateQuality();

            var expectedItems = new List<Item> { expected };
            Assert.AreEqual(expectedItems[0].Quality, actualItems[0].Quality);

        }

        [Test]
        [TestCaseSource(nameof(SulfurasNotSellingScenarios))]
        public void NotDecreaseSellInDaysForSulfuras(Item expected, Item initialState)
        {
            IList<Item> actualItems = new List<Item> { initialState };
            var qualityUpdater = new GildedRose(actualItems);

            qualityUpdater.UpdateQuality();

            var expectedItems = new List<Item> { expected };
            Assert.AreEqual(expectedItems[0].SellIn, actualItems[0].SellIn);

        }

        private static readonly object[] BackstagePassesWhereSellInIsLessThanFiveDaysScenarios =
        {
            new object[] {new Item{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 23 }, new Item{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 }},
            new object[] {new Item{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 23 }, new Item{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 20 }}

        };

        [Test]
        [TestCaseSource(nameof(BackstagePassesWhereSellInIsLessThanFiveDaysScenarios))]
        public void IncreaseQualityOfBackStagePassesByThreeWhenFiveOrLessDaysToConcert(Item expected, Item initialState)
        {
            IList<Item> actualItems = new List<Item> { initialState };
            var qualityUpdater = new GildedRose(actualItems);

            qualityUpdater.UpdateQuality();

            var expectedItems = new List<Item> { expected };
            Assert.AreEqual(expectedItems[0].SellIn, actualItems[0].SellIn);

        }

        private static readonly object[] BackstagePassesWhereSellInIsBetweenFiveAndTenDaysScenarios =
        {
            new object[] {new Item{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 22 }, new Item{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 20 }}

        };

        [Test]
        [TestCaseSource(nameof(BackstagePassesWhereSellInIsBetweenFiveAndTenDaysScenarios))]
        public void IncreaseQualityOfBackStagePassesByTwoWhenBetweenFiveAndTenDaysToConcert(Item expected, Item initialState)
        {
            IList<Item> actualItems = new List<Item> { initialState };
            var qualityUpdater = new GildedRose(actualItems);

            qualityUpdater.UpdateQuality();

            var expectedItems = new List<Item> { expected };
            Assert.AreEqual(expectedItems[0].SellIn, actualItems[0].SellIn);

        }

        private static readonly object[] ExpiredBackstagePassesScenarios =
        {
            new object[] {new Item{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0 }, new Item{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 }}

        };

        [Test]
        [TestCaseSource(nameof(ExpiredBackstagePassesScenarios))]
        public void MakePassesHaveNoQualityWhenPassesExpire(Item expected, Item initialState)
        {
            IList<Item> actualItems = new List<Item> { initialState };
            var qualityUpdater = new GildedRose(actualItems);

            qualityUpdater.UpdateQuality();

            var expectedItems = new List<Item> { expected };
            Assert.AreEqual(expectedItems[0].SellIn, actualItems[0].SellIn);

        }

        private static readonly object[] IncreaseQualityScenarios =
        {
            new object[] {50, new Item{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 50 }},
            new object[] {50, new Item{ Name = "Aged Brie", SellIn = 4, Quality = 50 }}

        };

        [Test]
        [TestCaseSource(nameof(IncreaseQualityScenarios))]
        public void NotAllowQualityToGoBeyondFifty(int expectedQuality, Item initialState)
        {
            IList<Item> actualItems = new List<Item> { initialState };
            var qualityUpdater = new GildedRose(actualItems);

            qualityUpdater.UpdateQuality();

            Assert.IsTrue(expectedQuality == actualItems[0].Quality);

        }








    }
}
