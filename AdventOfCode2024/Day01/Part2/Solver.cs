using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day01.Part2;

public sealed class Solver : ISolver
{
    public string Solve(string[] input)
    {
        var leftList = new List<int>();
        var rightList = new List<int>();

        foreach (var line in input)
        {
            var parts = line.Split(" ");
            leftList.Add(int.Parse(parts[0]));
            rightList.Add(int.Parse(parts[^1]));
        }

        if (leftList.Count != rightList.Count)
            throw new InvalidOperationException("Side lengths do not match");

        var result = 0;
        foreach (var left in leftList)
        {
            var left1 = left;
            result += rightList.Count(right => right == left1) * left;
        }

        return result.ToString();
    }
}