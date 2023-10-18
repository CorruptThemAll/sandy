using sandy.codewars;
using System;
using System.Runtime.CompilerServices;

namespace sandy
{
    public class Program
    {
        public static string Decode(string morseCode)
        {
            string[] splitCode = morseCode.Split(" ");
            bool addSpace = false;
            string translatedFromMorseCode = "";
            bool beginning = true;
            for ( int i = 0; i < splitCode.Length; i++ )
            {
                // denne virker kun en codewars
                // translatedFromMorseCode += MorseCode.Get(splitCode[i]);
                if (splitCode[i] != "" && beginning)
                {
                    beginning = false;
                }
                else if (beginning) continue;
                
                if(!beginning) {
                    if (splitCode[i] == "" && addSpace == false)
                    {
                        addSpace = true;
                    }
                    else if (addSpace == true)
                    {
                        addSpace = false;
                    }
                    if (addSpace == true)
                    {
                        translatedFromMorseCode += " ";
                    }
                }
            }

            while (translatedFromMorseCode.EndsWith(" "))
            {
                translatedFromMorseCode = translatedFromMorseCode.Remove(translatedFromMorseCode.Length - 1);
            }

            return translatedFromMorseCode;
        }
        public static int DigitalRoot(long n)
        {
            long currentNumber = n;
            while(currentNumber > 9)
            {
                var numbers = currentNumber.ToString().ToCharArray();
                currentNumber = numbers.Select(x => (long)char.GetNumericValue(x))
                    .Sum();
            }
            return (int)currentNumber;
        }
        public static bool validBraces(String braces)
        {
            //stores index values that have been used for a valid bracket
            List<int> taken = new List<int>();
            //Fast invalid check
            if (braces[0] == ')' || braces[0] == ']' || braces[0] == '}')
            {
                return false;
            }

            for (int i = 0; i < braces.Length; i++)
            {
                char oldchar = braces[i];
                for (int j = i + 1; j < braces.Length; j++)
                {
                    if (oldchar == '(')
                    {
                        if (braces[j] == ']' || braces[j] == '}')
                            return false;
                    }
                    if (oldchar == '{')
                    {
                        if (braces[j] == ']' || braces[j] == ')')
                            return false;
                    }
                    if (oldchar == '[')
                    {
                        if (braces[j] == ')' || braces[j] == '}')
                            return false;
                    }
                    oldchar = braces[j];

                    if (!taken.Contains(i) && !taken.Contains(j))
                    {
                        if (braces[i] == '(')
                        {
                            if (braces[j] == ')')
                            {
                                taken.Add(i);
                                taken.Add(j);
                            }
                        }
                        if (braces[i] == '[')
                        {
                            if (braces[j] == ']')
                            {
                                taken.Add(i);
                                taken.Add(j);
                            }
                        }
                        if (braces[i] == '{')
                        {
                            if (braces[j] == '}')
                            {
                                taken.Add(i);
                                taken.Add(j);
                            }
                        }
                    }
                }
            }
            return braces.Length == taken.Count;
        }

        static void Main(string[] args)
        {
            Decode(".... . -.--   .--- ..- -.. .");
            var hey = validBraces("()");
            var yo = DigitalRoot(195);
            Console.WriteLine(yo);
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