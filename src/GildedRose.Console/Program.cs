namespace GildedRose.Console
{
    /// <summary>
    /// Represents the console application entry point.
    /// </summary>
    public static class Program
    {
        private static void Main()
        {
            System.Console.WriteLine("OMGHAI!");

            var container = Bootstrapper.Build();

            var app = container.GetInstance<App>();
            app.Run();

            System.Console.ReadKey();
        }
    }
}