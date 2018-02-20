using Entitas;



namespace Libraries.btcp.ECS.src.AI.Goap.Logic
{
    public class UpdateAgentCurrentActionSystem : IExecuteSystem
    {
        private IGroup<GameEntity> m_agentGroup;
        public UpdateAgentCurrentActionSystem(Contexts contexts)
        {
            m_agentGroup = contexts.game.GetGroup(GameMatcher.GoapAgent);
        }
        public void Execute()
        {
            foreach (var e in m_agentGroup.GetEntities())
            {
                var agent = e.goapAgent.agent;
                agent.UpdateCurrentAction();
            }
        }
    }
}

