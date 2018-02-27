using Entitas;
using Libraries.btcp.src.Stats.ECS;
using Mine.Stats;
using UnityEngine;

namespace Libraries.btcp.ECS.src.Core.Movement.Logic
{
    public class MoveSystem : IExecuteSystem, ICleanupSystem
    {
        private readonly IGroup<GameEntity> m_mover;
        private readonly IGroup<GameEntity> m_movesComplete;

        public MoveSystem(Contexts contexts)
        {
            m_mover = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Move));
            m_movesComplete = contexts.game.GetGroup(GameMatcher.MoveComplete);
        }

        public void Cleanup()
        {
            foreach (var e in m_movesComplete.GetEntities()) e.isMoveComplete = false;
        }


        public void Execute()
        {
            foreach (var e in m_mover.GetEntities())
            {
                var position = e.position.value;
                var targetPosition = e.move.value;

                var diff = targetPosition - position;
                var dist = diff.magnitude;

                var arriveDistance = e.arriveDistance.value;

                var velocity = Vector2.zero;

                if (e.hasVelocity) velocity = e.velocity.value;

                var speed = StatHelpers.CalculateStat(e, StatId.Movement_Speed);
                var targetSpeed = Vector2.zero;
                var force = 1f;

                var isSlowingDown = dist < arriveDistance;
                var stopMoving = false;

                if (isSlowingDown)
                {
                    targetSpeed = diff * speed * (diff.magnitude / arriveDistance);

                    stopMoving = dist <= 0.25;

                    if (e.hasDeceleration)
                    {
                        force = e.deceleration.value;
                    }
                }
                else
                {
                    targetSpeed = diff.normalized * speed;
                    if (e.hasAcceleration)
                    {
                        force = e.acceleration.value;
                    }
                }


                var steering = targetSpeed - velocity;
//                steering *= force;

                if (e.hasSteering)
                {
                    steering += e.steering.value;
                }

                if (stopMoving)
                {
                    e.RemoveMove();
                    e.isMoveComplete = true;
                    steering = Vector2.zero - velocity;
                }

                e.ReplaceSteering(steering);
            }
        }
    }
}