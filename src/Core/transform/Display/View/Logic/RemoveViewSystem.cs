using System.Collections.Generic;
using Entitas;
using Entitas.Unity;

using UnityEngine;


namespace Libraries.btcp.ECS.src.Core.transform.Display.View.Logic
{
    public class RemoveViewSystem : ReactiveSystem<GameEntity>
    {
        private Contexts m_contexts;

        public RemoveViewSystem (Contexts contexts) : base(contexts.game)
        {
            m_contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Destroyed.Added(), GameMatcher.Prefab.Removed());
        }

        protected override bool Filter(GameEntity entity)
        {
            return (entity.isDestroyed || (entity.hasPrefab == false && entity.hasSprite == false && entity.hasGameObject == false) && entity.hasView);
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(var e in entities)
            {
                var go = e.view.gameObject;
                EntityLinkExtension.Unlink((GameObject) go);
                GameObject.Destroy(go);
                e.RemoveView();
            }
        }
    }
}
