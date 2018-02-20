public sealed class EffectFadeSystems : Feature
{
    public EffectFadeSystems(Contexts contexts) : base("Effect Fade Systems")
    {
        Add(new ApplyFadeSystem(contexts));
    }
}