using Entitas;
using Libraries.btcp.ECS.src.Combat.Events.Interfaces;

namespace Libraries.btcp.ECS.src.Combat.Events.Listeners
{
    public sealed class Listener_EntityDamaged : IComponent
    {
        public IListenerEntityDamaged listener;
    }
}