public sealed class RotationSystems : Feature
{
    public RotationSystems(Contexts contexts) : base("Rotation Systems")
    {
        Add(new RotationSystem(contexts));
    }
}