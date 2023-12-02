namespace bazzed.net8;

public class Advent01
{
    public void Part1()
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
            Console.WriteLine("digit: " + digit);
            sum += int.Parse(digit);
            Console.WriteLine(sum);
        }
    }
}