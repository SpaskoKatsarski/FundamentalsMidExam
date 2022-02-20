using System;
using System.Collections.Generic;
using System.Linq;

namespace Task._02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "Finish")
            {
                string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];
                int value = int.Parse(cmdArgs[1]);

                if (action == "Add")
                {
                    numbers.Add(value);
                }
                else if (action == "Remove")
                {
                    numbers.Remove(value);
                }
                else if (action == "Replace")
                {
                    int replacement = int.Parse(cmdArgs[2]);

                    if (!CheckIfContains(numbers, value))
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    numbers.Insert(numbers.IndexOf(value), replacement);
                    numbers.RemoveAt(numbers.IndexOf(value));
                }
                else if (action == "Collapse")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] < value)
                        {
                            numbers.Remove(numbers[i]);
                            i--;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
        static bool CheckIfContains(List<int> list, int element)
        {
            return list.Contains(element);
        }
    }
}
