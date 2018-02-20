using Entitas;

using UnityEngine;


namespace Libraries.btcp.ECS.src.AI.Goap.Logic
{
    public class UpdateAgentSystem : IExecuteSystem
    {
        private IGroup<GameEntity> m_agentGroup;
        public UpdateAgentSystem(Contexts contexts)
        {
            m_agentGroup = contexts.game.GetGroup(GameMatcher.GoapAgent);
        }
        public void Execute()
        {
            foreach (var e in m_agentGroup.GetEntities())
            {
                var agent = e.goapAgent.agent;
                agent.UpdateAgent(Time.deltaTime);
            }
        }
    }
}