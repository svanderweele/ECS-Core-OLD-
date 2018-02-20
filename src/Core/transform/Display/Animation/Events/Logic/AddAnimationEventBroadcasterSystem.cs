using System.Collections.Generic;
using Entitas;

using Libraries.btcp.ECS.src.Core.transform.Display.Animation.Events.unity;


namespace Libraries.btcp.ECS.src.Core.transform.Display.Animation.Events.Logic
{
    public class AddAnimationEventBroadcasterSystem : ReactiveSystem<GameEntity>
    {
        private Contexts m_contexts;

        public AddAnimationEventBroadcasterSystem (Contexts contexts) : base(contexts.game)
        {
            m_contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AnimatorController.Added(), GameMatcher.Animation.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                var go = e.view.gameObject;

                var broadcaster = go.GetComponent<AnimationEventBroadcaster>();
                if (broadcaster == null) go.AddComponent<AnimationEventBroadcaster>();
            }
        }
    }
}
