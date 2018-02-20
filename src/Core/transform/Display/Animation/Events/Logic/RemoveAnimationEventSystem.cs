using Entitas;



namespace Libraries.btcp.ECS.src.Core.transform.Display.Animation.Events.Logic
{
    public class RemoveAnimationEventSystem : ICleanupSystem
    {
        private Contexts m_contexts;
        private IGroup<GameEntity> m_group;

        public RemoveAnimationEventSystem (Contexts contexts)
        {
            m_contexts = contexts;
            m_group = contexts.game.GetGroup(GameMatcher.AnimationEvent);
        }

        public void Cleanup()
        {
            foreach (var e in m_group.GetEntities())
            {
                e.RemoveAnimationEvent();
                e.isAnimationComplete = false;
            }
        }
    }
}
