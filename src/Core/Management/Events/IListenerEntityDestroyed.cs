using Entitas;

namespace Libraries.btcp.ECS.src.Core.Management.Events
{
    public interface IListenerEntityDestroyed
    {
        void OnEntityDestroyed(int entityID);
    }
}