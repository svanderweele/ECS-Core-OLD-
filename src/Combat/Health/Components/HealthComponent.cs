using Entitas;

namespace Libraries.btcp.ECS.src.Combat.Health.Components
{
    public sealed class HealthComponent : IComponent
    {
        public float value;
        public float total;
    }
}