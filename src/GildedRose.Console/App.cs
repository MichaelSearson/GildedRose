using GildedRose.Core.Inventory;

namespace GildedRose.Console
{
    /// <summary>
    /// Represents the logical application entry point. This can be run from the console
    /// application itself or unit tests.
    /// </summary>
    public class App
    {
        private readonly IEndOfDayProcessor _endOfDayProcessor;

        public App(IEndOfDayProcessor endOfDayProcessor)
        {
            _endOfDayProcessor = endOfDayProcessor;
        }

        public void Run()
        {
            _endOfDayProcessor.UpdateInventory();
        }
    }
}