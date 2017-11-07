using System.Collections.Generic;
using csharp.Logic;
using NUnit.Framework;

namespace csharp.Tests
{
    [TestFixture]
    class InventoryShould
    {
        [Test]
        public void HaveCorrectItems()
        {
            List<string> expectedListOfItemNames = new List<string>();
            expectedListOfItemNames.Add("+5 Dexterity Vest");
            expectedListOfItemNames.Add("Aged Brie");
            expectedListOfItemNames.Add("Elixir of the Mongoose");
            expectedListOfItemNames.Add("Sulfuras, Hand of Ragnaros");
            expectedListOfItemNames.Add("Sulfuras, Hand of Ragnaros");
            expectedListOfItemNames.Add("Backstage passes to a TAFKAL80ETC concert");
            expectedListOfItemNames.Add("Backstage passes to a TAFKAL80ETC concert");
            expectedListOfItemNames.Add("Backstage passes to a TAFKAL80ETC concert");
            expectedListOfItemNames.Add("Conjured Mana Cake");

            var inventory = new Inventory();
            List<string> actualListOfItemNames = new List<string>();

            IList<Item> actualListOfItems = inventory.GetStock();

            foreach (var item in actualListOfItems)
            {
                actualListOfItemNames.Add(item.Name);
            }

            CollectionAssert.AreEqual(expectedListOfItemNames, actualListOfItemNames);

        }
    }
}
