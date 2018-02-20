
using Libraries.btcp.ECS.src.Combat.Damage;
using Libraries.btcp.ECS.src.Combat.Health;

namespace Libraries.btcp.ECS.src.Combat
{
    public sealed class CombatSystems : Feature
    {
        public CombatSystems(Contexts contexts) : base("Combat Systems")
        {
            Add(new DamageSystems(contexts));
            Add(new HealthSystems(contexts));
        }
    }
}