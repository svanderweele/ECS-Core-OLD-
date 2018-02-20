using System.Collections.Generic;
using Entitas;

using UnityEngine;


namespace Libraries.btcp.ECS.src.Core.Input.Logic
{
    public class DebugInputSystem : ReactiveSystem<GameEntity>
    {
        private Contexts m_context;

        public DebugInputSystem(Contexts contexts) : base(contexts.game)
        {
            m_context = contexts;
        }


        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.MouseInteractDown.AddedOrRemoved(),
                GameMatcher.MouseInteractUp.AddedOrRemoved(),
                GameMatcher.MouseInteractHover.AddedOrRemoved());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                ColorSprite(e,Color.white);
                if (e.isMouseInteractHover) ColorSprite(e, Color.blue);
                if (e.isMouseInteractDownHover) ColorSprite(e, Color.cyan);
                if (e.isMouseInteractUp) ColorSprite(e, Color.red);
                if (e.isMouseInteractDown) ColorSprite(e, Color.green);
                
            }
        }

        private void ColorSprite(GameEntity e, Color color)
        {
            if (e.hasView)
            {
                var sr = e.view.gameObject.GetComponentInChildren<SpriteRenderer>();

                if (sr)
                {
                    sr.color = color;
                }
            }
        }
    }
}