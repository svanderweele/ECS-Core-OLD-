using Entitas;

using UnityEngine;


namespace Libraries.btcp.ECS.src.Core.Parenting.Logic
{
    public class SetChildParentSystem : IExecuteSystem
    {
        private Contexts m_contexts;
        private IGroup<GameEntity> m_group;

        public SetChildParentSystem(Contexts contexts)
        {
            m_contexts = contexts;
            m_group = contexts.game.GetGroup(GameMatcher.Parent);
        }

        public void Execute()
        {
            foreach (var e in m_group.GetEntities())
            {
                var parentID = e.parent.value;
                var parent = m_contexts.game.GetEntityWithId(parentID);

                GameObject go = null;

                if (e.hasView)
                {
                    go = e.view.gameObject;

                    if (parent.hasView)
                    {
                        var parentGO = parent.view.gameObject;
                        go.transform.SetParent(parentGO.transform, false);
                    }
                }
            }
        }
    }
}