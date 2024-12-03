using System.Text.RegularExpressions;
using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day03.Part2;

public sealed partial class Solver : ISolver
{
    public string Solve(string[] input)
    {
        var combinedString = string.Join("", input);
        var instructions = InstructionsRegex()
            .Split(combinedString)
            .Where(x => InstructionsRegex().IsMatch(x))
            .ToArray();

        var isActive = true;
        var sum = 0;
        foreach (var instruction in instructions)
        {
            if (DoRegex().IsMatch(instruction))
            {
                isActive = true;
                continue;
            }

            if (DontRegex().IsMatch(instruction))
            {
                isActive = false;
                continue;
            }

            if (isActive && MultiplyRegex().IsMatch(instruction))
            {
                var parts = instruction.Split(',');
                var leftNumber = int.Parse(parts[0].Split('(')[1]);
                var rightNumber = int.Parse(parts[1].Split(")")[0]);
                sum += leftNumber * rightNumber;
            }
        }

        return sum.ToString();
    }

    [GeneratedRegex(@"(do\(\))")]
    private static partial Regex DoRegex();

    [GeneratedRegex(@"(don't\(\))")]
    private static partial Regex DontRegex();

    [GeneratedRegex(@"(mul\(\d{1,3},\d{1,3}\))|(do\(\))|(don't\(\))")]
    private static partial Regex InstructionsRegex();

    [GeneratedRegex(@"(mul\(\d{1,3},\d{1,3}\))")]
    private static partial Regex MultiplyRegex();
}