
using Libraries.btcp.ECS.src.Core.transform.Position.Shake.Logic;

namespace Libraries.btcp.ECS.src.Core.transform.Position.Shake
{
    public sealed class EffectShakeSystems : Feature
    {
        public EffectShakeSystems(Contexts contexts) : base("Shake Systems")
        {
            Add(new DoShakeSystem(contexts));
            Add(new ApplyShakeOffsetSystem(contexts));
        }
    }
}