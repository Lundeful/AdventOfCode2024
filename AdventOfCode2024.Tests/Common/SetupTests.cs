namespace AdventOfCode2024.Tests.Common;

public class SetupTests
{
    [Fact]
    public void EnsureAllDaysAndPartsAreSetup()
    {
        const int totalDays = 25;
        const int partsPerDay = 2;

        var testProjectDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", ".."));
        var mainProjectDirectory = Path.GetFullPath(Path.Combine(testProjectDirectory, "..", "AdventOfCode2024"));

        for (var day = 1; day <= totalDays; day++)
        {
            for (var part = 1; part <= partsPerDay; part++)
            {
                var dayName = $"Day{day.ToString().PadLeft(2, '0')}";
                var partName = $"Part{part}";

                // Create solver
                var solverDir = Path.Combine(mainProjectDirectory, dayName, partName);
                Directory.CreateDirectory(solverDir);
                CreateSolverClass(solverDir, dayName, partName);

                // Create test
                var testDir = Path.Combine(testProjectDirectory, dayName, partName);
                Directory.CreateDirectory(testDir);
                CreateTestClass(testDir, dayName, partName);
                CreateTestFiles(testDir);
            }
        }
    }

    private static void CreateSolverClass(string directory, string day, string part)
    {
        var solverPath = Path.Combine(directory, "Solver.cs");
        if (!File.Exists(solverPath))
        {
            File.WriteAllText(solverPath, $$"""
                                            using AdventOfCode2024.Common;

                                            namespace AdventOfCode2024.{{day}}.{{part}};

                                            public sealed class Solver : ISolver
                                            {
                                                public string Solve(string[] input)
                                                {
                                                    return string.Empty;
                                                }
                                            }
                                            """);
        }
    }

    private static void CreateTestClass(string directory, string day, string part)
    {
        var testPath = Path.Combine(directory, "Tests.cs");
        if (!File.Exists(testPath))
        {
            File.WriteAllText(testPath, $"""
                                         using AdventOfCode2024.Tests.Common;
                                         using Xunit.Abstractions;

                                         namespace AdventOfCode2024.Tests.{day}.{part};

                                         public sealed class Tests(ITestOutputHelper testOutputHelper) : SolverTestBase(testOutputHelper);
                                         """);
        }
    }

    private static void CreateTestFiles(string directory)
    {
        var files = new[]
        {
            "testInput.txt",
            "testAnswer.txt",
            "testOutput.txt",
            "input.txt",
            "output.txt"
        };

        foreach (var file in files)
        {
            var filePath = Path.Combine(directory, file);
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "");
            }
        }
    }
}