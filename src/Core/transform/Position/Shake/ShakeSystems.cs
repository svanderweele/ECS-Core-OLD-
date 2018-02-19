public sealed class ShakeSystems : Feature
{
    public ShakeSystems(Contexts contexts) : base("Shake Systems")
    {
        Add(new DoShakeSystem(contexts));
        Add(new ApplyShakeOffsetSystem(contexts));
    }
}