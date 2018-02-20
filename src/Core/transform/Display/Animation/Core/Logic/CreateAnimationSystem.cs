using System.Collections.Generic;
using Entitas;



namespace Libraries.btcp.ECS.src.Core.transform.Display.Animation.Core.Logic
{
    public class CreateAnimationSystem : ReactiveSystem<GameEntity>
    {
        private Contexts m_contexts;

        public CreateAnimationSystem(Contexts contexts) : base(contexts.game)
        {
            m_contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Animation.Added(), GameMatcher.View.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasView && entity.hasAnimation;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                var go = e.view.gameObject;

                UnityEngine.Animation animation = go.GetComponent<UnityEngine.Animation>();
                if (animation == null) animation = go.AddComponent<UnityEngine.Animation>();
            }
        }
    }
}