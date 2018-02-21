using Entitas;
using UnityEngine;


namespace Libraries.btcp.ECS.src.AI.Sensors.Targeting.Logic
{
    public class RemoveTargetSystem : IExecuteSystem
    {
        private Contexts m_contexts;
        private IGroup<GameEntity> m_group;

        public RemoveTargetSystem (Contexts contexts)
        {
            m_contexts = contexts;
            m_group = contexts.game.GetGroup(GameMatcher.Target);
        }

        public void Execute()
        {
            foreach (var e in m_group.GetEntities())
            {
                var targetID = e.target.value;
                var target = m_contexts.game.GetEntityWithId(targetID);
                if (target == null || target.isDestroyed)
                {
                    e.RemoveTarget();
                }
            }
        }
    }
}
