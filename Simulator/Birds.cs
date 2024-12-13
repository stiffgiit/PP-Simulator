namespace Simulator
{
    public class Birds : Animals
    {
        public bool CanFly { get; set; } = true;

        public override string Info => $"{FormatName(Description)} (fly{(CanFly ? "+" : "-")}) <{Size}>";

        public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
    }
}
