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
            if(item.Name == "Sulfuras, Hand of Ragnaros")
            {
                // Sulfuras does not need to be updated
                continue;
            }

            switch (item)
            {
                case { Name: "Aged Brie" }:
                    item.Quality = item.Quality + 1;
                    break;
                default:
                    item.Quality = item.Quality - (item.SellIn < 0 ? 2 : 1);
                    break;
            }

            item.SellIn--;

            //No item ever greater than 50
            item.Quality = item.Quality > 50 ? 50 : item.Quality;
        }
    }
}