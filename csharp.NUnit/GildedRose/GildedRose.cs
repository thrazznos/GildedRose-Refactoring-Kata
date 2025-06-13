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
                    item.Quality = item.Quality + (item.SellIn <= 0 ? 2 :1);
                    break;
                case { Name: "Backstage passes to a TAFKAL80ETC concert" }:
                    if (item.SellIn <= 0)
                    {
                        item.Quality = 0;
                    }
                    else if (item.SellIn <= 5 )
                    {
                        item.Quality = item.Quality + 3;
                    }
                    else if (item.SellIn <= 10)
                    {
                        item.Quality = item.Quality + 2;
                    }
                    else
                    {
                        item.Quality = item.Quality + 1;
                    }
                    break;
                //case { Name: string name } when name.Contains("Conjured"):
                //    item.Quality = item.Quality - 2;
                //    break;
                default:
                    item.Quality = item.Quality - (item.SellIn <= 0 ? 2 : 1);
                    break;
            }

            item.SellIn--;

            if(item.Quality > 50)
            {
                item.Quality = 50;
            }
            else if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }
    }
}