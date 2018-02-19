using Entitas;using Entitas;
using UnityEngine;

namespace AI
{
    public class IterateAgentActionsSystem : IExecuteSystem
    {
        private IGroup<GameEntity> m_agentGroup;
        public IterateAgentActionsSystem(Contexts contexts)
        {
            m_agentGroup = contexts.game.GetGroup(GameMatcher.GoapAgent);
        }
        public void Execute()
        {
            foreach (var e in m_agentGroup.GetEntities())
            {
                var agent = e.goapAgent.agent;
                agent.IterateActions();
            }
        }
    }
}

