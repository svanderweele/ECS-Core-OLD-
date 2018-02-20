using Entitas;

namespace Libraries.btcp.ECS.src.Combat.Cooldown.Components
{
    public sealed class CooldownComponent : IComponent
    {
        public float value;
        public float total;
    }
}