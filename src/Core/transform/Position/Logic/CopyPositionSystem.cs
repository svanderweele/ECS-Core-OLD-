using Entitas;

public class CopyPositionSystem : IExecuteSystem
{
    private Contexts m_contexts;
    private IGroup<GameEntity> m_group;

    public CopyPositionSystem (Contexts contexts)
    {
        m_contexts = contexts;
        m_group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.CopyPosition));
    }

    public void Execute()
    {
        foreach (var e in m_group.GetEntities())
        {
            //TODO - remove copy position if target removed
            var target = m_contexts.game.GetEntityWithId(e.copyPosition.entityId);
            
            var pos = target.view.gameObject.transform.position;
            e.ReplacePosition(pos);
        }
    }
}
