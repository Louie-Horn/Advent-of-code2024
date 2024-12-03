namespace AdventOfCode;

public class Day02 : BaseDay
{
    private readonly string _input;

    public Day02()
    {
        _input = File.ReadAllText(InputFilePath);
        List<string> lines = _input.Split("\n").ToList();
        int safeCount = 0;

        for (int l = 0; l < lines.Count; l++)
        {
            List<int> row = lines[l].Split(" ").Select(int.Parse).ToList();
            bool? is_increasing = null;
            int badlevels = 0;

            for (int i = 0; i < row.Count-1; i++)
            {
                int a = row[i];
                int b = row[i + 1];
                int difference = a - b;
                bool bad = false;
                
                if (a == b) 
                {
                    bad = true;
                }
                else if (is_increasing == null)
                {
                    is_increasing = a < b;
                }

                if (is_increasing == true)
                {
                    if (a > b)
                    {
                        bad = true;
                    }
                }
                else
                {
                    if (b > a)
                    {
                        bad = true;
                    }
                }

                if (Math.Abs(difference) > 3)
                {
                    bad = true;
                }

                if (bad)
                {
                    badlevels++;
                }
            }

            if (badlevels < 2)
            {
                safeCount++;
            }
        }
        Console.WriteLine($"{safeCount} safe reports");
    }

    public override ValueTask<string> Solve_1() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1");

    public override ValueTask<string> Solve_2() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 2");
}
