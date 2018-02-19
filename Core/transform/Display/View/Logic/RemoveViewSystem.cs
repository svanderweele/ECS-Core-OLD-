using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class RemoveViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts m_contexts;

    public RemoveViewSystem (Contexts contexts) : base(contexts.game)
    {
        m_contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroyed);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isDestroyed && entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            var go = e.view.gameObject;
            go.Unlink();
            GameObject.Destroy(go);
            e.RemoveView();
        }
    }
}
