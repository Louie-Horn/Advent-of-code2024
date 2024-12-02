namespace AdventOfCode;

public class Day02 : BaseDay
{
    private readonly string _input;

    public Day02()
    {
        _input = File.ReadAllText(InputFilePath);
        List<string> lines = _input.Split("\n").ToList();
        int safeCount = 0;

        for (int i = 0; i < lines.Count; i++)
        {
            bool safe = true;
            string currentLineString = lines[i];
            List<int> numbers = currentLineString.Split(' ').Select(int.Parse).ToList();
            bool ascending = true;

            for (int j = 1; j < numbers.Count; j++)
            {
                int difference = numbers[j] - numbers[j - 1];
                if (j == 1)
                {
                    ascending = difference > 0;
                }
                if (difference == 0)
                {
                    safe = false;
                }

                if (ascending)
                {
                    if (difference < 0 || difference > 3)
                    {
                        safe = false;
                    }
                }
                if (!ascending)
                {
                    if (difference > 0 || difference < -3)
                    {
                        safe = false;
                    }
                }
            }

            if (safe)
            {
                safeCount++;
            }
        }
        Console.WriteLine($"{safeCount} safe lines");
    }

    public override ValueTask<string> Solve_1() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1");

    public override ValueTask<string> Solve_2() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 2");
}
