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
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 1 } };
            var qualityUpdater = new GildedRose(items);
            var expectedItems = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            qualityUpdater.UpdateQuality();
            Assert.AreEqual(expectedItems[0].SellIn, items[0].SellIn);
            
        }

        [Test]
        public void DecreaseTheQualityOfAnItemByOne()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 1 } };
            var qualityUpdater = new GildedRose(items);
            var expectedItems = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            qualityUpdater.UpdateQuality();
            Assert.AreEqual(expectedItems[0].Quality, items[0].Quality);

        }
    }
}
