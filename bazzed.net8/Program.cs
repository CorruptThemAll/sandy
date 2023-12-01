using System.Net.Sockets;

namespace bazzed.net8
{
    internal class Program
    {
        static bool TryNumber(string input, out int result)
        {
            switch (input)
            {
                case "one":
                    result = 1;
                    return true;
                case "two":
                    result = 2;
                    return true;
                case "three":
                    result = 3;
                    return true;
                case "four":
                    result = 4;
                    return true;
                case "five":
                    result = 5;
                    return true;
                case "six":
                    result = 6;
                    return true;
                case "seven":
                    result = 7;
                    return true;
                case "eight":
                    result = 8;
                    return true;
                case "nine":
                    result = 9;
                    return true;
                default:
                    result = 0;
                    return false;
            }
        }

        static void Main(string[] args)
        {
            var arrayOfStrings = File.ReadAllLines(@"C:\Users\Lukas\Downloads\adventofcode1.txt");
            var sum = 0;
            var firstdigit = 0;
            var seconddigit = 0;
            foreach (var ofString in arrayOfStrings)
            {
                var task = Task.Run(() =>
                {
                    var digit = 0;

                    for (int i = 0; i < ofString.Length; i++)
                    {
                        if (char.IsDigit(ofString[i]))
                        {
                            digit = int.Parse(ofString[i].ToString());
                        }     
                    }
                    return digit;
                });

                var task2 = Task.Run(() =>
                {
                    var digit = 0;
                    for (int i = ofString.Length - 1; i > -1; i--)
                    {
                        if (char.IsDigit(ofString[i]))
                            digit = int.Parse(ofString[i].ToString());
                    }

                    return digit;
                });
                var digit = $"{task2.Result}{task.Result}";
                Console.WriteLine("digit: "+digit);
                sum += int.Parse(digit);
                Console.WriteLine(sum);
            }
        }
    }
}
