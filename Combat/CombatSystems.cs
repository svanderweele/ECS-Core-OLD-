public sealed class CombatSystems : Feature
{
    public CombatSystems(Contexts contexts) : base("Combat Systems")
    {
        Add(new DamageSystems(contexts));
        Add(new HealthSystems(contexts));
    }
}