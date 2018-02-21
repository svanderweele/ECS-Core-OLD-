using System.Collections.Generic;
using Entitas;

using UnityEngine;


namespace Libraries.btcp.ECS.src.Core.transform.Display.View.Logic
{
    public class ChangeCanvasElementParentSystem : ReactiveSystem<GameEntity>
    {
        private Contexts m_contexts;
        private Transform m_canvas;

        public ChangeCanvasElementParentSystem (Contexts contexts) : base(contexts.game)
        {
            m_contexts = contexts;
            m_canvas = GameObject.FindObjectOfType<Canvas>().transform.Find("Entities");
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {   
            return context.CreateCollector(GameMatcher.CanvasElement.Added(), GameMatcher.View.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasView && entity.isCanvasElement;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(var e in entities)
            {
                var go = e.view.gameObject;
                go.transform.SetParent(m_canvas, false);
            }
        }
    }
}
