using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.Assertions;

namespace ECS.Core.transform.Display.Sprite.Logic
{
    public class RenderSpriteSystem : ReactiveSystem<GameEntity>
    {
        private Contexts m_contexts;

        public RenderSpriteSystem (Contexts contexts) : base(contexts.game)
        {
            m_contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Sprite.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasSprite && entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                var go = e.view.gameObject;
                var sprite = Resources.Load<UnityEngine.Sprite>(e.sprite.name);
            
                Assert.IsNotNull(sprite, "Sprite not found " + e.sprite.name);

                var sr = go.GetComponent<SpriteRenderer>();
                if (sr == null) sr = go.AddComponent<SpriteRenderer>();
                sr.sprite = sprite;
            }
        }
    }
}
