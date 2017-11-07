using System.Collections.Generic;

namespace csharp.Logic
{
    public class GildedRose
    {
        private readonly IList<Item> _items;
        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {

                DecreaseNormalItemQualityByOne(item);
                IncreasesQualityOfBackStagePassses(item);
                IncreaseBrieNormally(item);
                UpdateSellInDays(item);

                if (item.SellIn < 0)
                {
                    DecreaseNormalItemQualityWhenPassedSellByDate(item);
                    BackstagePassQualityIsZeroWhenPassedSellInDate(item);
                    IncreaseQualityOfOlderAgedBrie(item);
                }
            }
        }


        public void DecreaseNormalItemQualityByOne(Item item)
        {
            if (item.Name == "Aged Brie" ||
                item.Name == "Backstage passes to a TAFKAL80ETC concert" ||
                item.Name == "Sulfuras, Hand of Ragnaros"||
                item.Quality <= 0)
                return;

                item.Quality = item.Quality - 1;
            
        }

        public void IncreasesQualityOfBackStagePassses(Item item)
        {
            if (item.Name != "Backstage passes to a TAFKAL80ETC concert" || item.Quality >= 50) return;
            item.Quality = item.Quality + 1;
            if (item.SellIn < 11)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }

            if (item.SellIn >= 6) return;
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }

        public void IncreaseBrieNormally(Item item)
        {
            if (item.Name == "Aged Brie" && item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }

        }

        public void UpdateSellInDays(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn = item.SellIn - 1;
            }
        }

        public void DecreaseNormalItemQualityWhenPassedSellByDate(Item item)
        {
            if (item.Name == "Aged Brie" ||
                item.Name == "Backstage passes to a TAFKAL80ETC concert" ||
                item.Quality <= 0 ||
                item.Name == "Sulfuras, Hand of Ragnaros")
                return;

            item.Quality = item.Quality - 1;

        }

        public void BackstagePassQualityIsZeroWhenPassedSellInDate(Item item)
        {
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                item.Quality = item.Quality - item.Quality;
            }
        }

        public void IncreaseQualityOfOlderAgedBrie(Item item)
        {
            if (item.Name != "Aged Brie") return;
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }


    }
}
