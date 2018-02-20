using Entitas;



namespace Libraries.btcp.ECS.src.Core.Physics.Logic
{
    public class RemoveVelocitySystem : ICleanupSystem
    {
        private Contexts m_contexts;
        private IGroup<GameEntity> m_group;

        public RemoveVelocitySystem(Contexts contexts)
        {
            m_contexts = contexts;
            m_group = contexts.game.GetGroup(GameMatcher.Velocity);
        }
    
        public void Cleanup()
        {
            foreach (var e in m_group.GetEntities())
            {
                var velocity = e.velocity.value;

                if (velocity.magnitude <= 0.1f)
                {
                    e.RemoveVelocity();
                }
            }
        }
    }
}