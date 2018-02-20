
using Libraries.btcp.ECS.src.Combat.Health.Logic;

namespace Libraries.btcp.ECS.src.Combat.Health
{
    public sealed class HealthSystems : Feature
    {
        public HealthSystems(Contexts contexts) : base("Health Systems")
        {
            Add(new RemoveDeadEntitiesSystem(contexts));
            Add(new KillEntitiesSystem(contexts));
        }
    }
}