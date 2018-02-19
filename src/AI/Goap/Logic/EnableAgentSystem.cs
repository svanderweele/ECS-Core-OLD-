using System.Collections.Generic;
using Entitas;

public class EnableAgentSystem : ReactiveSystem<GameEntity>
{
    private Contexts m_contexts;

    public EnableAgentSystem (Contexts contexts) : base(contexts.game)
    {
        m_contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GoapAgent);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasGoapAgent && entity.isDead == false;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            e.goapAgent.agent.EnableAgent();
        }
    }
}
