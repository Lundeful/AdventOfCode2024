using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day01.Part1;

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

        leftList.Sort();
        rightList.Sort();

        if (leftList.Count != rightList.Count)
            throw new InvalidOperationException("Side lengths do not match");

        var distance = 0;
        for (var i = 0; i < leftList.Count; i++)
        {
            var left = leftList[i];
            var right = rightList[i];
            if (left > right)
            {
                distance += left - right;
            }
            else
            {
                distance += right - left;
            }
        }

        return distance.ToString();
    }
}