using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input.txt");

        //Start rotor position
        int position = 50;
        int countZero = 0;

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            char direction = line[0];               // 'L' or 'R'
            int amount = int.Parse(line[1..]);      // number after it

            if (direction == 'L')
            {
                position = (position - amount) % 100;
                if (position < 0) position += 100;   // modulo fix
            }
            else if (direction == 'R')
            {
                position = (position + amount) % 100;
            }
            else
            {
                throw new Exception("Invalid rotation: " + line);
            }

            if (position == 0)
                countZero++;
        }

        Console.WriteLine($"Password = {countZero}");
    }
}

