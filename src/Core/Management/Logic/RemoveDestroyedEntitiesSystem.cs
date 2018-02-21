using Entitas;


namespace Libraries.btcp.ECS.src.Core.Management.Logic
{
    public class RemoveDestroyedEntitiesSystem : IExecuteSystem
    {
        private Contexts m_contexts;
        private IGroup<GameEntity> m_group;
        private IGroup<GameEntity> m_listeners;

        public RemoveDestroyedEntitiesSystem(Contexts contexts)
        {
            m_contexts = contexts;
            m_group = contexts.game.GetGroup(GameMatcher.Destroyed);
            m_listeners = contexts.game.GetGroup(GameMatcher.Listener_EntityDestroyed);
        }

        public void Execute()
        {
            foreach (var e in m_group.GetEntities())
            {
                foreach (var listener in m_listeners.GetEntities())
                {
                        listener.listener_EntityDestroyed.listener.OnEntityDestroyed(e.id.value);
                }

                e.Destroy();
            }
        }
    }
}