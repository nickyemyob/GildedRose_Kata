using System.Collections.Generic;

namespace csharp.Logic
{
    public class GildedRose
    {
        IList<Item> _items;
        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < _items.Count; i++)
            {

                DecreaseNormalItemQualityByOne(i);
                IncreasesQualityOfBackStagePassses(i);
                IncreaseBrieNormally(i);
                UpdateSellInDays(i);

                if (_items[i].SellIn < 0)
                {
                    DecreaseNormalItemQualityWhenPassedSellByDate(i);
                    BackstagePassQualityIsZeroWhenPassedSellInDate(i);
                    IncreaseQualityOfOlderAgedBrie(i);
                }
            }
        }


        public void DecreaseNormalItemQualityByOne(int index)
        {
            if (_items[index].Name == "Aged Brie" ||
                _items[index].Name == "Backstage passes to a TAFKAL80ETC concert" ||
                _items[index].Name == "Sulfuras, Hand of Ragnaros"||
                _items[index].Quality <= 0)
                return;

                _items[index].Quality = _items[index].Quality - 1;
            
        }

        public void IncreasesQualityOfBackStagePassses(int i)
        {
            if (_items[i].Name != "Backstage passes to a TAFKAL80ETC concert" || _items[i].Quality >= 50) return;
            _items[i].Quality = _items[i].Quality + 1;
            if (_items[i].SellIn < 11)
            {
                if (_items[i].Quality < 50)
                {
                    _items[i].Quality = _items[i].Quality + 1;
                }
            }

            if (_items[i].SellIn >= 6) return;
            if (_items[i].Quality < 50)
            {
                _items[i].Quality = _items[i].Quality + 1;
            }
        }

        public void IncreaseBrieNormally(int i)
        {
            if (_items[i].Name == "Aged Brie" && _items[i].Quality < 50)
            {
                _items[i].Quality = _items[i].Quality + 1;
            }

        }

        public void UpdateSellInDays(int i)
        {
            if (_items[i].Name != "Sulfuras, Hand of Ragnaros")
            {
                _items[i].SellIn = _items[i].SellIn - 1;
            }
        }

        public void DecreaseNormalItemQualityWhenPassedSellByDate(int index)
        {
            if (_items[index].Name == "Aged Brie" ||
                _items[index].Name == "Backstage passes to a TAFKAL80ETC concert" ||
                _items[index].Quality <= 0 ||
                _items[index].Name == "Sulfuras, Hand of Ragnaros")
                return;

            _items[index].Quality = _items[index].Quality - 1;

        }

        public void BackstagePassQualityIsZeroWhenPassedSellInDate(int i)
        {
            if (_items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                _items[i].Quality = _items[i].Quality - _items[i].Quality;
            }
        }

        public void IncreaseQualityOfOlderAgedBrie(int i)
        {
            if (_items[i].Name != "Aged Brie") return;
            if (_items[i].Quality < 50)
            {
                _items[i].Quality = _items[i].Quality + 1;
            }
        }


    }
}
