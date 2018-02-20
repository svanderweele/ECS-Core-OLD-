public sealed class EffectScaleSystems : Feature
{
    public EffectScaleSystems(Contexts contexts) : base("Effect Scale Systems")
    {
        Add(new ScaleBounceSystem(contexts));
    }
}