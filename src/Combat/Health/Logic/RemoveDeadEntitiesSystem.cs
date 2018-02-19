using Entitas;
using UnityEngine;

public class RemoveDeadEntitiesSystem : IExecuteSystem
{
    private Contexts m_contexts;
    private IGroup<GameEntity> m_group;

    public RemoveDeadEntitiesSystem (Contexts contexts)
    {
        m_contexts = contexts;
        m_group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Dead, GameMatcher.RemovedWhenDead));
    }

    public void Execute()
    {
        foreach (var e in m_group.GetEntities())
        {
            e.isDestroyed = true;
        }
    }
}
