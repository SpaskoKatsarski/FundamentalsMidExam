using System;

namespace Task._03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            decimal pricePerPacketOfFlour = decimal.Parse(Console.ReadLine());
            decimal priceForEgg = decimal.Parse(Console.ReadLine());
            decimal priceForApron = decimal.Parse(Console.ReadLine());

            decimal studentsForApron = Math.Ceiling(1.20m * students);

            decimal normalPriceForFlour = pricePerPacketOfFlour;

            decimal total = 0;

            for (int i = 1; i <= students; i++)
            {
                if (i % 5 == 0)
                {
                    pricePerPacketOfFlour = 0;
                }
                else
                {
                    pricePerPacketOfFlour = normalPriceForFlour;
                }

                total += priceForEgg * 10 + pricePerPacketOfFlour;
            }

            decimal totalForApron = priceForApron * studentsForApron;

            total += totalForApron;

            if (total <= budget)
            {
                Console.WriteLine($"Items purchased for {total:f2}$.");
            }
            else
            {
                Console.WriteLine($"{(total - budget):f2}$ more needed.");
            }
        }
    }
}
