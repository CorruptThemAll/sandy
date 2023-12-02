using System.Drawing;
using Newtonsoft.Json;

namespace bazzed.net8;

public static class Advent02
{
    struct Red : IColor
    {
        public Red()
        {
        }

        public string Color { get; set; } = "red";
    }

    struct Green : IColor
    {
        public Green()
        {
        }

        public string Color { get; set; } = "green";
    }

    struct Blue : IColor
    {
        public Blue()
        {
        }

        public string Color { get; set; } = "blue";
    }

    public static List<string> ListOfStrings = File.ReadAllLines(@"C:\Users\Lukas\Downloads\adventofcodeday2.txt").ToList();

    private static Dictionary<IColor, int> Bag;

    private static Dictionary<IColor, int> minimumBag;

    //Determine which games would have been possible if the bag had been loaded with only 12 red cubes, 13 green cubes, and 14 blue cubes.
    static Advent02()
    {
        Bag = new Dictionary<IColor, int>()
        {
            {new Red(), 12},
            {new Green(), 13},
            {new Blue(), 14},
        };
        minimumBag = new Dictionary<IColor, int>()
        {
            {new Red(), 0},
            {new Green(), 0},
            {new Blue(), 0},
        };
    }

    public static void Part1()
    {
        var sum = 0;
        foreach (var s in ListOfStrings)
        {
            var array = s.Split(":");
            var gamenum = int.Parse(array[0].Split(" ").Last());
            if (ValidBag(array))
            {
                sum += gamenum;
            }
        }

        Console.WriteLine("Sum part 1 of day 2: " + sum);
    }

    private static bool ValidBag(string[] array)
    {
        foreach (var subgame in array[1].Split(";"))
            foreach (var color in subgame.Split(","))
            {
                var data = color.Split(" ");
                var value = data[1];
                var colorname = data[2];
                var validValue = Bag.Where(x => x.Key.Color == colorname).Select(x => x.Value).FirstOrDefault();
                if (validValue < int.Parse(value))
                    return false;
            }
        return true;
    }
}

