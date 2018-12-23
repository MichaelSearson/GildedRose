using System.Collections.Generic;

namespace GildedRose.Console
{
    /// <summary>
    /// Handles the end of day processes necessary for the Guilded Rose.
    /// </summary>
    public class EndOfDayProcessor
    {
        private readonly IList<Item> _inventoryItems;

        public EndOfDayProcessor(IList<Item> inventoryItems)
        {
            _inventoryItems = inventoryItems;
        }

        /// <summary>
        /// Works through the provided inventory updates the quality and sell in values
        /// as appropriate.
        /// </summary>
        public void UpdateInventory()
        {
            for (var i = 0; i < _inventoryItems.Count; i++)
            {
                if (_inventoryItems[i].Name != "Aged Brie" && _inventoryItems[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (_inventoryItems[i].Quality > 0)
                    {
                        if (_inventoryItems[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            _inventoryItems[i].Quality = _inventoryItems[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (_inventoryItems[i].Quality < 50)
                    {
                        _inventoryItems[i].Quality = _inventoryItems[i].Quality + 1;

                        if (_inventoryItems[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (_inventoryItems[i].SellIn < 11)
                            {
                                if (_inventoryItems[i].Quality < 50)
                                {
                                    _inventoryItems[i].Quality = _inventoryItems[i].Quality + 1;
                                }
                            }

                            if (_inventoryItems[i].SellIn < 6)
                            {
                                if (_inventoryItems[i].Quality < 50)
                                {
                                    _inventoryItems[i].Quality = _inventoryItems[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (_inventoryItems[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    _inventoryItems[i].SellIn = _inventoryItems[i].SellIn - 1;
                }

                if (_inventoryItems[i].SellIn < 0)
                {
                    if (_inventoryItems[i].Name != "Aged Brie")
                    {
                        if (_inventoryItems[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (_inventoryItems[i].Quality > 0)
                            {
                                if (_inventoryItems[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    _inventoryItems[i].Quality = _inventoryItems[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            _inventoryItems[i].Quality = _inventoryItems[i].Quality - _inventoryItems[i].Quality;
                        }
                    }
                    else
                    {
                        if (_inventoryItems[i].Quality < 50)
                        {
                            _inventoryItems[i].Quality = _inventoryItems[i].Quality + 1;
                        }
                    }
                }
            }
        }

        #region Helpers

        private void UpdateQuality()
        {
        }

        private void UpdateSellIn()
        {
        }

        #endregion Helpers
    }
}