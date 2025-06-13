using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            switch (item)
            {
                case { Name: "Sulfuras, Hand of Ragnaros" }:
                    // Sulfuras does not need to be updated
                    break;
                default:
                    item.Quality = item.Quality - (item.SellIn < 0 ? 2 : 1);
                    break;
            }

            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn = item.SellIn - 1;
            }
        }
    }
}