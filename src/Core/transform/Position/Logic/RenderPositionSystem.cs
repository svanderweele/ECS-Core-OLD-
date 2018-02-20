using Entitas;


namespace Libraries.btcp.ECS.src.Core.transform.Position.Logic
{
    public class RenderPositionSystem : IExecuteSystem
    {
        private Contexts m_contexts;
        private IGroup<GameEntity> m_group;

        public RenderPositionSystem (Contexts contexts)
        {
            m_contexts = contexts;
            m_group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.View));
        }

  
        public void Execute()
        {
            foreach (var e in m_group.GetEntities())
            {
                if (e.hasParent)
                {
                    ApplyPositionRelativeToParent(e);
                }
                else
                {
                    ApplyPosition(e);
                }

                if (e.hasPositionOffset)
                {
                    ApplyOffset(e);
                }
            }
        }

        private void ApplyOffset(GameEntity e)
        {
            var go = e.view.gameObject;
            var position = go.transform.position;
            var offset = e.positionOffset.value;
            go.transform.position = e.position.value;
        }

        private void ApplyPositionRelativeToParent(GameEntity e)
        {
            var go = e.view.gameObject;
            var parent = m_contexts.game.GetEntityWithId(e.parent.value);
            var parentPosition = parent.position.value;
            var position = e.position.value;
            var diff = position - parentPosition;
            go.transform.localPosition = diff;
        }

        private void ApplyPosition(GameEntity e)
        {
            var go = e.view.gameObject;
            go.transform.position = e.position.value;
        }
    }
}
