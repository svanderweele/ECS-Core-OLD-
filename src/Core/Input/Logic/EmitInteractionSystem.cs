using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

namespace Libraries.btcp.ECS.src.Core.Input.Logic
{
    public class EmitInteractionSystem : ReactiveSystem<InputEntity>, ICleanupSystem
    {
        private const float MAX_RAY_DISTANCE = 500f;
        private const float MAX_DISTANCE = 0.1f; //used if target has no renderer
        private readonly IGroup<GameEntity> m_entities;

        private Contexts m_context;
        private GameContext c_context;

        public EmitInteractionSystem(Contexts contexts) : base(contexts.input)
        {
            m_context = contexts;
            c_context = contexts.game;
            m_entities =
                contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.MouseListener));
        }


        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.MouseDown.AddedOrRemoved(),
                InputMatcher.MousePosition.AddedOrRemoved(), InputMatcher.MouseUp.AddedOrRemoved());
        }

        protected override bool Filter(InputEntity entity)
        {
            return true;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var e in entities)
            {
                var mouseEntity = e;

                var isMouseDown = mouseEntity.hasMouseDown;
                var isMouseUp = mouseEntity.hasMouseUp;
                var isMouseMove = mouseEntity.hasMousePosition;

                var ray = Camera.main.ScreenPointToRay(
                    Camera.main.WorldToScreenPoint(mouseEntity.mousePosition.position));
                var hit = Physics2D.Raycast(ray.origin, ray.direction, MAX_RAY_DISTANCE);
                if (hit.collider != null)
                {
                    var entity = m_entities.SingleOrDefault(newEntity =>
                        newEntity.isMouseListener && newEntity.hasView &&
                        newEntity.view.gameObject.GetComponent<Collider2D>() == hit.collider);

                    //TODO : Also log close ray hits? 
                    if (entity != null)
                    {
                        if (e.isLeftMouse)
                        {
                            entity.isMouseInteractDown = isMouseDown;
                            entity.isMouseInteractUp = isMouseUp;
                            entity.isMouseInteractHover = isMouseMove;
                        }
                    }
                }
            }
        }

        public void Cleanup()
        {
            foreach (var e in m_entities)
            {
                e.isMouseInteractDown = false;
                e.isMouseInteractUp = false;
                e.isMouseInteractHover = false;
            }
        }
    }
}