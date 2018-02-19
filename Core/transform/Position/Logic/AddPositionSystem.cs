using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddPositionSystem : ReactiveSystem<GameEntity>
{
    private Contexts m_contexts;

    public AddPositionSystem (Contexts contexts) : base(contexts.game)
    {
        m_contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.View.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && entity.hasPosition == false;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            e.AddPosition(Vector2.zero);
        }
    }
}
