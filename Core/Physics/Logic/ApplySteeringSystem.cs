using Entitas;
using UnityEngine;

public class ApplySteeringSystem : IExecuteSystem
{
    private Contexts m_contexts;
    private IGroup<GameEntity> m_group;

    public ApplySteeringSystem (Contexts contexts)
    {
        m_contexts = contexts;
        m_group = contexts.game.GetGroup(GameMatcher.Steering);
    }

    public void Execute()
    {
        foreach (var e in m_group.GetEntities())
        {
            var steering = e.steering.value;

            var velocity = Vector2.zero;

            if (e.hasVelocity)
            {
                velocity = e.velocity.value;
            }

            velocity += steering;
            e.RemoveSteering();
            e.ReplaceVelocity(velocity);
        }
    }
}
