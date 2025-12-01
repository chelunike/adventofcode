using System;
using System.IO;

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("input.txt");

        // Start position
        int position = 50;
        int clickCount = 0;

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            char direction = line[0];               // 'L' o 'R'
            int amount = int.Parse(line.Substring(1));

            if (direction == 'L')
            {
                for (int i = 0; i < amount; i++)
                {
                    position = (position - 1 + 100) % 100;
                    if (position == 0)
                        clickCount++;
                }
            }
            else if (direction == 'R')
            {
                for (int i = 0; i < amount; i++)
                {
                    position = (position + 1) % 100;
                    if (position == 0)
                        clickCount++;
                }
            }
            else
            {
                throw new Exception("Invalid Rotation: " + line);
            }
        }

        Console.WriteLine($"CLICK password = {clickCount}");
    }
}
