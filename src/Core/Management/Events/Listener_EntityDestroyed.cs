using Entitas;
using Libraries.btcp.ECS.src.Combat.Events.Interfaces;
using Libraries.btcp.ECS.src.Core.Management.Events;

namespace Libraries.btcp.ECS.src.Combat.Events.Listeners
{
    public sealed class Listener_EntityDestroyed : IComponent
    {
        public IListenerEntityDestroyed listener;
    }
}