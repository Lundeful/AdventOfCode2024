using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day02.Part1;

public sealed class Solver : ISolver
{
    public string Solve(string[] input)
    {
        var safeReports = 0;
        foreach (var line in input)
        {
            var levels = line.Split(' ');
            var isSafe = true;
            var i = 0;
            var originalDirection = int.Parse(levels[0]) - int.Parse(levels[1]) > 0;
            while (isSafe && i + 1 < levels.Length)
            {
                var level = int.Parse(levels[i]);
                var nextLevel = int.Parse(levels[i + 1]);
                if (level == nextLevel)
                {
                    isSafe = false;
                    break;
                }

                var diff = level - nextLevel;
                if (Math.Abs(diff) is < 1 or > 3)
                {
                    isSafe = false;
                    break;
                }

                var currentDirection = diff > 0;
                if (originalDirection != currentDirection)
                {
                    isSafe = false;
                    break;
                }

                i++;
            }

            if (isSafe)
            {
                safeReports++;
            }
        }

        return safeReports.ToString();
    }
}