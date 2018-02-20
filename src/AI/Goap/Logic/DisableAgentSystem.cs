using System.Collections.Generic;
using Entitas;

namespace Libraries.btcp.ECS.src.AI.Goap.Logic
{
    public class DisableAgentSystem : ReactiveSystem<GameEntity>
    {
        private Contexts m_contexts;

        public DisableAgentSystem (Contexts contexts) : base(contexts.game)
        {
            m_contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Dead);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGoapAgent && entity.isDead;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(var e in entities)
            {
                e.goapAgent.agent.DisableAgent();
            }
        }
    }
}
