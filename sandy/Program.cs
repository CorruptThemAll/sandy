using sandy.codewars;

namespace sandy
{
    public class Program
    {
        static void Main(string[] args)
        {
            PersistentBugger persistentBugger = new PersistentBugger();
            Console.WriteLine(persistentBugger.Bugger(25));
            Console.WriteLine(Kata.DescendingOrder(4512));

            Console.WriteLine();

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();


                
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}