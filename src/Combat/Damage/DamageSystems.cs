
using Libraries.btcp.ECS.src.Combat.Damage.Logic;

namespace Libraries.btcp.ECS.src.Combat.Damage
{
    public sealed class DamageSystems : Feature
    {
        public DamageSystems(Contexts contexts) : base("Damage Systems")
        {
            Add(new ApplyDamageSystem(contexts));
        }
    }
}