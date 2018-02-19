public sealed class DamageSystems : Feature
{
    public DamageSystems(Contexts contexts) : base("Damage Systems")
    {
        Add(new ApplyDamageSystem(contexts));
    }
}