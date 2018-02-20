using Entitas;


namespace Libraries.btcp.ECS.src.Core.transform.Rotation.Logic
{
    public class RotationSystem : IExecuteSystem
    {
        private Contexts m_contexts;
        private IGroup<GameEntity> m_group;

        public RotationSystem (Contexts contexts)
        {
            m_contexts = contexts;
            m_group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Rotation, GameMatcher.View));
        }

        public void Execute()
        {
            foreach (var e in m_group.GetEntities())
            {
                var go = e.view.gameObject;
                go.transform.eulerAngles = e.rotation.value;
            }
        }
    }
}
