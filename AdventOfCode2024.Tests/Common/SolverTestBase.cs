using AdventOfCode2024.Common;
using FluentAssertions;
using Xunit.Abstractions;

namespace AdventOfCode2024.Tests.Common;

public abstract class SolverTestBase
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ISolver _solver;

    private readonly string _day;
    private readonly string _part;
    private readonly string[] _input;
    private readonly string[] _testInput;
    private readonly string _testAnswer;

    protected SolverTestBase(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;

        var namespaceParts = GetType().Namespace!.Split('.');

        _day = namespaceParts[^2].PadLeft(2, '0');
        _part = namespaceParts[^1];
        var baseInputPath = Path.Combine(_day, _part);

        var solverName = $"AdventOfCode2024.{_day}.{_part}.Solver";

        var solutionAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == "AdventOfCode2024") ??
                               throw new InvalidOperationException("Could not find AdventOfCode2024 assembly");

        var solverType = solutionAssembly.GetType(solverName) ??
                         throw new InvalidOperationException($"Missing solver: {solverName}");

        _solver = (ISolver)Activator.CreateInstance(solverType)!;

        // Load test files
        _input = File.ReadAllLines(Path.Combine(baseInputPath, "input.txt"));
        _testInput = File.ReadAllLines(Path.Combine(baseInputPath, "testInput.txt"));
        _testAnswer = File.ReadAllText(Path.Combine(baseInputPath, "testAnswer.txt")).Trim();
    }

    [Fact]
    public void Solve_01_Test()
    {
        // Arrange
        _testInput.Should().NotBeEmpty($"{_day}.{_part} requires test input");
        _testAnswer.Should().NotBeEmpty($"{_day}.{_part} requires test answer");

        // Act
        var result = _solver.Solve(_testInput);

        // Assert
        _testOutputHelper.WriteLine($"{_day} {_part} Test Output: {result}");
        result.Should().Be(_testAnswer, "test result should match test answer");
    }

    [Fact]
    public void Solve_02_Real()
    {
        // Arrange
        _input.Should().NotBeEmpty($"{_day}.{_part} requires real input");

        // Act
        var result = _solver.Solve(_input);

        // Assert
        _testOutputHelper.WriteLine($"{_day} {_part} Real Output: {result}");
        result.Should().NotBeEmpty("real should not be empty");
    }
}