using GildedRose.Core.Inventory;
using SimpleInjector;

namespace GildedRose.Console
{
    /// <summary>
    /// Initialise a <see cref="SimpleInjector"/> container for resolving dependencies.
    /// </summary>
    public static class Bootstrapper
    {
        private static readonly Container _container;

        static Bootstrapper()
        {
            _container = new Container();
        }

        public static Container Build()
        {
            _container.Register(typeof(IEndOfDayProcessor), typeof(EndOfDayProcessor));
            _container.Register(typeof(IInventory), typeof(Inventory));

            _container.Register<App>();

            _container.Verify();

            return _container;
        }
    }
}