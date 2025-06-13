using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    public class Sulfuras
    {
        [Test]
        public void SulfurasDay1()
        {
            var items = new List<Item>
        {
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }
        };
            var sut = new GildedRose(items);
            sut.UpdateQuality();
            Assert.That(items[0].SellIn, Is.EqualTo(0));
            Assert.That(items[0].Quality, Is.EqualTo(80));
        }

        [Test]
        public void SulfurasDay2()
        {
            var items = new List<Item>
        {
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }
        };
            var sut = new GildedRose(items);
            sut.UpdateQuality();
            sut.UpdateQuality();
            Assert.That(items[0].SellIn, Is.EqualTo(0));
            Assert.That(items[0].Quality, Is.EqualTo(80));
        }
    }

    public class AgedBrie
    {
        [Test]
        public void AgedBrieDay1()
        {
            var items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 }
            };

            var sut = new GildedRose(items);
            sut.UpdateQuality();
            Assert.That(items[0].SellIn, Is.EqualTo(9));
            Assert.That(items[0].Quality, Is.EqualTo(21));
        }

        [Test]
        public void AgedBrieDay2()
        {
            var items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 }
            };

            var sut = new GildedRose(items);
            sut.UpdateQuality();
            sut.UpdateQuality();
            Assert.That(items[0].SellIn, Is.EqualTo(8));
            Assert.That(items[0].Quality, Is.EqualTo(22));
        }

        [Test]
        public void AgedBrieDoubleAfterExpired()
        {
            var items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 0, Quality = 20 }
            };

            var sut = new GildedRose(items);
            sut.UpdateQuality();
            Assert.That(items[0].SellIn, Is.EqualTo(-1));
            Assert.That(items[0].Quality, Is.EqualTo(22));
        }

        [Test]
        public void QualityNeverMoreThan50()
        {
            //Makes an aged brie and iterators updatequality 50 times
            var items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 }
            };
            var sut = new GildedRose(items);
            for (int i = 0; i < 50; i++)
            {
                sut.UpdateQuality();
            }

            Assert.That(items[0].SellIn, Is.EqualTo(-40));
            Assert.That(items[0].Quality, Is.EqualTo(50)); // Quality should not exceed 50
        }
    }

    public class BackstagePass
    {
        [Test]
        public void BackstagePassNormal()
        {
            var items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 }
            };
            var sut = new GildedRose(items);
            sut.UpdateQuality();
            Assert.That(items[0].SellIn, Is.EqualTo(14));
            Assert.That(items[0].Quality, Is.EqualTo(21));
        }

        [Test]
        public void BackstagePass10DaysRemain()
        {
            var items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 }
            };

            var sut = new GildedRose(items);

            for (int i = 0; i < 5; i++)
            {
                sut.UpdateQuality();
            }

            Assert.That(items[0].SellIn, Is.EqualTo(10));
            Assert.That(items[0].Quality, Is.EqualTo(25));
        }

        [Test]
        public void BackstagePass09DaysRemain()
        {
            var items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 }
            };

            var sut = new GildedRose(items);

            for (int i = 0; i < 5; i++)
            {
                sut.UpdateQuality();
            }
            sut.UpdateQuality();

            Assert.That(items[0].SellIn, Is.EqualTo(9));
            Assert.That(items[0].Quality, Is.EqualTo(27));
        }

        [Test]
        public void BackstagePass4DaysRemain()
        {
            var items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 }
            };

            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.That(items[0].SellIn, Is.EqualTo(4));
            Assert.That(items[0].Quality, Is.EqualTo(23));
        }

        [Test]
        public void BackstagePass1DaysRemain()
        {
            var items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 20 }
            };

            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.That(items[0].SellIn, Is.EqualTo(1));
            Assert.That(items[0].Quality, Is.EqualTo(23));
        }

        [Test]
        public void BackstagePass00DaysRemain()
        {
            var items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 }
            };

            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.That(items[0].SellIn, Is.EqualTo(-1));
            Assert.That(items[0].Quality, Is.EqualTo(0));
        }
    }

    public class BusinessRules
    {
        [Test]
        public void ItemDecrementSellIn()
        {
            var items = new List<Item>
            {
                new Item { Name = "Some Item", SellIn = 10, Quality = 20 }
            };
            var sut = new GildedRose(items);
            sut.UpdateQuality();
            Assert.That(items[0].SellIn, Is.EqualTo(9));
            sut.UpdateQuality();
            Assert.That(items[0].SellIn, Is.EqualTo(8));
        }

        [Test]
        public void ItemDecrementQuality()
        {
            var items = new List<Item>
            {
                new Item { Name = "Some Item", SellIn = 10, Quality = 20 }
            };
            var sut = new GildedRose(items);
            sut.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(19));
            sut.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(18));
        }

        [Test]
        public void ItemDecrementQualityDoubleAfterSell()
        {
            var items = new List<Item>
            {
                new Item { Name = "Some Item", SellIn = 0, Quality = 20 }
            };
            var sut = new GildedRose(items);
            sut.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(19));
            sut.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(17));
        }

        [Test]
        public void ItemDecrementQualityNeverNegative()
        {
            var items = new List<Item>
            {
                new Item { Name = "Some Item", SellIn = 5, Quality = 0 }
            };
            var sut = new GildedRose(items);
            sut.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(0));
        }

        [Test]
        public void RandomItem10Days()
        {
            var items = new List<Item>
            {
                new Item { Name = "Some Item", SellIn = 10, Quality = 20 }
            };

            var sut = new GildedRose(items);

            for (int i = 0; i < 10; i++)
            {
                sut.UpdateQuality();
            }

            Assert.That(items[0].SellIn, Is.EqualTo(0));
            Assert.That(items[0].Quality, Is.EqualTo(10));
        }
    }


}