using System.Collections.Generic;
using Entitas;

public class RemoveCopyPositionSystem : ReactiveSystem<GameEntity>
{
    private Contexts m_contexts;
    private IGroup<GameEntity> m_group;

    public RemoveCopyPositionSystem (Contexts contexts) : base(contexts.game)
    {
        m_contexts = contexts;
        m_group = m_contexts.game.GetGroup(GameMatcher.CopyPosition);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroyed);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isDestroyed;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var destroyedEntity in entities)
        {
            foreach (var e in m_group.GetEntities())
            {
                var copyPositionEntity = e.copyPosition.entityId;
                if (copyPositionEntity == destroyedEntity.id.value)
                {
                    e.RemoveCopyPosition();
                }
            }
        }
    }
}
