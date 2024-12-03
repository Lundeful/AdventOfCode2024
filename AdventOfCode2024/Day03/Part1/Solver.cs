using System.Text.RegularExpressions;
using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day03.Part1;

public sealed partial class Solver : ISolver
{
    public string Solve(string[] input)
    {
        var combinedString = string.Join("", input);
        var regex = MultiplyRegex();
        var multiplications = regex
            .Split(combinedString)
            .Select(x => regex.Match(x).Value)
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToArray();

        var sum = 0;
        foreach (var multiplication in multiplications)
        {
            var parts = multiplication.Split(',');
            var leftNumber = int.Parse(parts[0].Split('(')[1]);
            var rightNumber = int.Parse(parts[1].Split(")")[0]);
            sum += leftNumber * rightNumber;
        }

        return sum.ToString();
    }

    [GeneratedRegex(@"(mul\(\d{1,3},\d{1,3}\))")]
    private static partial Regex MultiplyRegex();
}