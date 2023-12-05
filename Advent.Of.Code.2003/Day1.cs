﻿using System.Text.RegularExpressions;

namespace Advent.Of.Code._2003;

public static class Day1
{
    public static void Go()
    {
        var filePath = "..\\..\\..\\input-day1.txt";
        Lines = File.ReadAllLines(filePath);
        PartA();
        PartB();
    }

    public static int PartA()
    {
        var total = 0;
        foreach (var line in Lines)
        {
            var firstDigit = line.FirstOrDefault(char.IsDigit);
            var lastDigit = line.LastOrDefault(char.IsDigit);
            total += int.Parse($"{firstDigit}{lastDigit}");
        }

        Console.WriteLine(total);
        return total;
    }

    public static int PartB()
    {
        var total = 0;

        var digits = new Dictionary<string, int>()
        {
            { "one", 1 }, { "two", 2 }, { "three", 3 }, { "four", 4 }, { "five", 5 },
            { "six", 6 }, { "seven", 7 }, { "eight", 8 }, { "nine", 9 }
        };
        var pattern = @"\d|one|two|three|four|five|six|seven|eight|nine";

        int GetNum(string m)
        {
            if (char.IsDigit(m[0]))
                return m[0] - '0';
            return digits[m];
        }

        foreach (var line in Lines)
        {
            var tens = Regex.Match(line, pattern).Value;
            var firstDigit = GetNum(tens) * 10;

            var units = Regex.Match(line, pattern, RegexOptions.RightToLeft).Value;
            var lastDigit = GetNum(units);

            total += firstDigit + lastDigit;
        }

        Console.WriteLine(total);
        return total;
    }

    public static string[] Lines = Array.Empty<string>();
}