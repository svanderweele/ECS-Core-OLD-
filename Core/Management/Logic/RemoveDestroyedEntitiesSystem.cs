using Entitas;
using UnityEngine;

public class RemoveDestroyedEntitiesSystem : IExecuteSystem
{
    private Contexts m_contexts;
    private IGroup<GameEntity> m_group;

    public RemoveDestroyedEntitiesSystem (Contexts contexts)
    {
        m_contexts = contexts;
        m_group = contexts.game.GetGroup(GameMatcher.Destroyed);
    }

    public void Execute()
    {
        foreach (var e in m_group.GetEntities())
        {
           e.Destroy();
        }
    }
}
