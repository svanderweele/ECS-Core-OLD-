using Entitas;

using UnityEngine;

namespace Libraries.btcp.ECS.src.Core.Physics.Logic
{
    public class ApplyVelocitySystem : IExecuteSystem
    {
        private Contexts m_contexts;
        private IGroup<GameEntity> m_group;

        public ApplyVelocitySystem(Contexts contexts)
        {
            m_contexts = contexts;
            m_group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Velocity));
        }

        public void Execute()
        {
            foreach (var e in m_group.GetEntities())
            {
                var vel = e.velocity.value;
                var pos = e.position.value;
            
                pos += vel * Time.deltaTime;
                e.ReplacePosition(pos);
            
            }
        }
    }
}