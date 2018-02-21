using Entitas;
using UnityEngine;


namespace Libraries.btcp.ECS.src.Core.transform.Position.Logic
{
    public class RenderPositionSystem : IExecuteSystem
    {
        private Contexts m_contexts;
        private IGroup<GameEntity> m_group;

        public RenderPositionSystem(Contexts contexts)
        {
            m_contexts = contexts;
            m_group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.View));
        }


        public void Execute()
        {
            foreach (var e in m_group.GetEntities())
            {
                ApplyPosition(e);

                if (e.hasPositionOffset)
                {
                    var go = e.view.gameObject;
                    go.transform.localPosition = go.transform.localPosition + (Vector3) e.positionOffset.value;
                }
            }
        }

        private void ApplyPositionRelativeToParent(GameEntity e)
        {
            var go = e.view.gameObject;
            var position = e.position.value;
            go.transform.localPosition = position;
        }

        private void ApplyPosition(GameEntity e)
        {
            //TODO - If Entity has parent, should I add a LocalPositionComponent? At the moment using PositionComponent does not give actual position
            var go = e.view.gameObject;
            var pos = e.position.value;

            if (e.hasParent)
            {
                var parent = m_contexts.game.GetEntityWithId(e.parent.value);
                pos += (Vector2) parent.view.gameObject.transform.position;
            }

            go.transform.position = pos;
        }
    }
}