using Libraries.btcp.ECS.src.Core.transform.Position.Shake;

public sealed class EffectSystems : Feature
{
    public EffectSystems(Contexts contexts) : base("Effect Systems")
    {
        Add(new EffectScaleSystems(contexts));
        Add(new EffectShakeSystems(contexts));
        Add(new EffectFadeSystems(contexts));
    }
}