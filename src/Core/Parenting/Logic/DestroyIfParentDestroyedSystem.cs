using Entitas;



namespace Libraries.btcp.ECS.src.Core.Parenting.Logic
{
    public class DestroyIfParentDestroyedSystem : IExecuteSystem
    {
        private Contexts m_contexts;
        private IGroup<GameEntity> m_group;

        public DestroyIfParentDestroyedSystem (Contexts contexts)
        {
            m_contexts = contexts;
            m_group = contexts.game.GetGroup(GameMatcher.Parent);
        }

        public void Execute()
        {
            foreach (var e in m_group.GetEntities())
            {
                var parentID = e.parent.value;

                if (m_contexts.game.GetEntityWithId(parentID) == null)
                {
                    e.isDestroyed = true;
                }
            }
        }
    }
}
