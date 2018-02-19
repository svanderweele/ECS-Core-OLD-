public sealed class AISystems : Feature
{
    public AISystems(Contexts contexts) : base("AI Systems")
    {
        Add(new SensorSystems(contexts));
        Add(new GoapSystems(contexts));
    }
}