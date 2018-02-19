using Entitas;
using UnityEngine;

public class ApplyGravitySystem : IExecuteSystem
{
    private Contexts m_contexts;
    private IGroup<GameEntity> m_group;

    public ApplyGravitySystem (Contexts contexts)
    {
        m_contexts = contexts;
        m_group = contexts.game.GetGroup(GameMatcher.AffectedByGravity);
    }

    public void Execute()
    {
        foreach (var e in m_group.GetEntities())
        {

            if (e.isOnGround) continue;

            var gravity = -.98f;
            var steering = Vector2.zero;

            if (e.hasSteering)
            {
                steering = e.steering.value;
            }

            steering.y += gravity;
            e.ReplaceSteering(steering);
        }
    }
}
