using Entitas;
using Libraries.btcp.ECS.src.Combat.Events.Interfaces;

namespace Libraries.btcp.ECS.src.Combat.Events.Listeners
{
    public sealed class Listener_EntityKilled : IComponent
    {
        public IListenerEntityKilled listener;
    }
}