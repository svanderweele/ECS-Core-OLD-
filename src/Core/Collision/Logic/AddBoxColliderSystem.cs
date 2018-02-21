using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddBoxColliderSystem : ReactiveSystem<GameEntity>
{
    private Contexts m_contexts;

    public AddBoxColliderSystem (Contexts contexts) : base(contexts.game)
    {
        m_contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Collideable, GameMatcher.View));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isCollideable && entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            var go = e.view.gameObject;


            var collider = go.GetComponent<BoxCollider2D>();
            if (collider == null) collider = go.AddComponent<BoxCollider2D>();
        }
    }
}
