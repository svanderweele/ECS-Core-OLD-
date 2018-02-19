public sealed class SightSytems : Feature
{
    public SightSytems(Contexts contexts) : base("Sight Systems")
    {
        Add(new UpdateTargetsInSightSystem(contexts));
        Add(new LookAtTargetSystem(contexts));
    }
}