using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day02.Part2;

public sealed class Solver : ISolver
{
    public string Solve(string[] input)
    {
        var safeReports = 0;
        foreach (var line in input)
        {
            var levels = line.Split(' ').Select(int.Parse).ToList();
            var isSafe = IsReportSafe(levels);
            var i = 0;
            while (i < levels.Count && !isSafe)
            {
                var newList = levels.ToArray().ToList();
                newList.RemoveAt(i);
                isSafe = IsReportSafe(newList);
                i++;
            }

            if (isSafe)
            {
                safeReports++;
            }
        }

        return safeReports.ToString();
    }

    private static bool IsReportSafe(List<int> levels)
    {
        var isSafe = true;
        var i = 0;
        var originalDirection = levels[0] - levels[1] > 0;
        while (isSafe && i + 1 < levels.Count)
        {
            var level = levels[i];
            var nextLevel = levels[i + 1];
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

        return isSafe;
    }
}