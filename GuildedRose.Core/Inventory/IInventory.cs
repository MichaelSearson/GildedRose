using GuildedRose.Core.Products;
using System.Collections.Generic;

namespace GildedRose.Core.Inventory
{
    public interface IInventory
    {
        IList<Product> GetCurrentInventory();
    }
}