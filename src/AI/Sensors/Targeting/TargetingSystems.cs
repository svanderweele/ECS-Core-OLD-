public sealed class TargetingSystems : Feature
{
    public TargetingSystems(Contexts contexts) : base("Targeting Systems")
    {
        Add(new RemoveTargetSystem(contexts));
    }
}