using GuildedRose.Core.Products;

namespace GildedRose.Core.Inventory
{
    /// <summary>
    /// Handles the end of day processes necessary for the Guilded Rose.
    /// </summary>
    public class EndOfDayProcessor : IEndOfDayProcessor
    {
        private readonly IInventory _inventory;

        public EndOfDayProcessor(IInventory inventory)
        {
            _inventory = inventory;
        }

        /// <summary>
        /// Processes each product according to its specific implementation of
        /// <see cref="Product.SellIn"/> and <see cref="Product.Quality"/> update logic.
        /// </summary>
        public void UpdateInventory()
        {
            var products = _inventory.GetCurrentInventory();

            foreach (var product in products)
            {
                product.Update();
            }
        }
    }
}