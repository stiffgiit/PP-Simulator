namespace Simulator;
public static class DirectionParser
{
    public static Direction[] Parse(string directions)
    {
        var parsed = new List<Direction>();
        for (int i = 0; i < directions.Length; i++)
        {
            if (directions[i] == 'U' || directions[i] == 'u')
            {
                parsed.Add(Direction.Up);
            }
            else if (directions[i] == 'R' || directions[i] == 'r')
            {
                parsed.Add(Direction.Right);
            }
            else if (directions[i] == 'D' || directions[i] == 'd')
            {
                parsed.Add(Direction.Down);
            }
            else if (directions[i] == 'L' || directions[i] == 'l')
            {
                parsed.Add(Direction.Left);
            }
        }

        return parsed.ToArray();
    }
}