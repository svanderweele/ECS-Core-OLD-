public sealed class SensorSystems : Feature
{
    public SensorSystems(Contexts contexts) : base("AI Sensors")
    {
        Add(new SightSytems(contexts));
        Add(new TargetingSystems(contexts));
    }
}