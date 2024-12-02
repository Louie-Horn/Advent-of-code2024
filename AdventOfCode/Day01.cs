namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string _input;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
        string[] pairs = _input.Split("\n");

        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();
        
        for (int i = 0; i < (pairs.Length - 1); i++)
        {
            string[] split_pair = pairs[i].Trim().Split("   ");
            
            leftList.Add(int.Parse(split_pair[0]));
            rightList.Add(int.Parse(split_pair[1]));
        }
        
        leftList.Sort();
        rightList.Sort();
        int distance = 0;
        
        for (int i = 0; i < leftList.Count; i++)
        {
            if (leftList[i] != rightList[i])
            {
                if (leftList[i] < rightList[i])
                {
                    distance += rightList[i] - leftList[i];
                }
                else if (leftList[i] > rightList[i])
                {
                    distance += leftList[i] - rightList[i];
                }
            }
        }
        Console.WriteLine(distance);
    }

    public override ValueTask<string> Solve_1() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1");

    public override ValueTask<string> Solve_2() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 2");
}
