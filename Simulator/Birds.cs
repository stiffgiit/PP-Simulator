namespace Simulator;

public class Birds : Animals
{
    public bool CanFly = true;
    public override char Symbol => CanFly ? 'B' : 'b';

    public override string Info => $"{Description} (fly{(CanFly ? "+" : "-")}) <{Size}>";
    public override string Go(Direction direction)
    {
        if (CurrentMap != null)
        {
            if (CanFly)
            {
                var newPos = CurrentMap.Next(CreaturePos, direction);
                newPos = CurrentMap.Next(newPos, direction);
                CurrentMap.Move(this, CreaturePos, newPos);
                CreaturePos = newPos;
            }
            else
            {
                var newPos = CurrentMap.NextDiagonal(CreaturePos, direction);
                CurrentMap.Move(this, CreaturePos, newPos);
                CreaturePos = newPos;
            }
            return $"{direction.ToString().ToLower()}";
        }
        else
        {
            throw new InvalidOperationException("Blad! - Zwierze nie ma jeszcze przydzielonej mapy.");
        }
    }
}