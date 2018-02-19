using Entitas;

public class ApplyFrictionSystem : IExecuteSystem
{
    private Contexts m_contexts;
    private IGroup<GameEntity> m_group;

    public ApplyFrictionSystem (Contexts contexts)
    {
        m_contexts = contexts;
        m_group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Friction, GameMatcher.Velocity, GameMatcher.OnGround));
    }

    public void Execute()
    {
        foreach (var e in m_group.GetEntities())
        {
            var velocity = e.velocity.value;
            var friction = e.friction.value;
            e.ReplaceVelocity(velocity * friction);
        }
    }
}
