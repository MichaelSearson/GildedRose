namespace GuildedRose.Core.Products
{
    public abstract class Product
    {
        public string Name { get; protected set; }

        public int SellIn { get; protected set; }

        public uint Quality { get; protected set; }

        public ProductEnums.QualityDirection QualityDirection { get; protected set; }

        public void Update()
        {
            UpdateQuality();
            UpdateSellIn();
        }

        protected virtual void UpdateSellIn()
        {
            SellIn--;
        }

        protected virtual void UpdateQuality()
        {
            switch (QualityDirection)
            {
                case ProductEnums.QualityDirection.Increase:
                    if (Quality < 50)
                        Quality++;

                    break;

                case ProductEnums.QualityDirection.Decrease:
                    // When the sell by date has passed the quality degrades twice as
                    // fast.
                    if (Quality > 0 && SellIn <= 0)
                        Quality--;

                    // Quality always degrades by one per day.
                    if (Quality > 0)
                        Quality--;

                    break;
            }
        }
    }
}