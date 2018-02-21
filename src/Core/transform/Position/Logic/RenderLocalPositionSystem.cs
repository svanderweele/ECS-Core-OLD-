using Entitas;

public class RenderLocalPositionSystem : IExecuteSystem
{
    private Contexts m_contexts;
    private IGroup<GameEntity> m_group;

    public RenderLocalPositionSystem (Contexts contexts)
    {
        m_contexts = contexts;
        m_group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Parent));
    }

    public void Execute()
    {
        foreach (var e in m_group.GetEntities())
        {
            var parent = m_contexts.game.GetEntityWithId(e.parent.value);

            var parentPosition = parent.position.value;
            var position = e.position.value;

        }
    }
}

