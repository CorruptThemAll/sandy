using sandy.codewars;
using System;
using System.Runtime.CompilerServices;

namespace sandy
{
    public class Program
    {
        private static double FindMedianSortedArrays2(int[] nums1, int[] nums2)
        {
            var array = new int[nums1.Length + nums2.Length];
            for (int i = 0; i < array.Length; i++) 
            {
                if(i < nums1.Length)
                    array[i] = nums1[i];
                else
                    array[i] = nums2[i-nums1.Length];
            }
            Array.Sort(array);
            if (array.Length % 2 == 0)
            {
                return (array[array.Length/ 2 - 1] + array[array.Length/ 2])/2.0;
            }
            return array[array.Length / 2];
        }
        private static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var mergedArray = new int[nums1.Length + nums2.Length];
            var nums1Length = nums1.Length;
            var nums2Length = nums2.Length;
            var num1 = 0; 
            var num2 = 0;
            var halfLenght = mergedArray.Length / 2;
            for (int i = 0; i < halfLenght + 1; i++)
            {
                if (nums1Length > i)
                    num1 = nums1[i];
                if (nums2Length > i)
                    num2 = nums2[i];
                if(num1 < num2)
                {
                    mergedArray[i] = num1;
                    if(num2 < mergedArray[i + 1])
                        mergedArray[i + 2] = mergedArray[mergedArray[i + 1]];
                    mergedArray[i + 1] = num2;

                }
                else if (num1 > num2) {
                    mergedArray[i] = num2;
                    if (num1 < mergedArray[i + 1])
                        mergedArray[i + 2] = mergedArray[mergedArray[i + 1]];
                    mergedArray[i + 1] = num1;
                }
            }
            if (mergedArray.Length % 2 == 0)
            {
                return (mergedArray[halfLenght] + mergedArray[halfLenght+1])/2.0;
            } else
            {
                return mergedArray[halfLenght];
            }
        }
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
            FindMedianSortedArrays2(new int[] { 1, 2 }, new int[] { 3, 4 });
            var write = FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3, 4 });
            Console.WriteLine(write.ToString());
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