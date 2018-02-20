using System.Collections.Generic;
using Entitas;

using UnityEngine;
using UnityEngine.Assertions;


namespace Libraries.btcp.ECS.src.Core.transform.Display.Animation.Core.Logic
{
    public class RenderAnimatorControllerSystem : ReactiveSystem<GameEntity>
    {
        private Contexts m_contexts;

        public RenderAnimatorControllerSystem(Contexts contexts) : base(contexts.game)
        {
            m_contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AnimatorController.Added(), GameMatcher.View.Added());
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

                Animator animator = null;
                RuntimeAnimatorController controller = null;

                animator = go.GetComponent<Animator>();
                if (animator)
                {
                    controller = animator.runtimeAnimatorController;
                }


                if (e.hasAnimatorController == false)
                {
                    if (controller)
                    {
                        e.AddAnimatorController(controller.name);
                        animator.runtimeAnimatorController = controller;
                    }
                }
                else
                {
                    if (controller == null)
                    {
                        controller = Resources.Load<RuntimeAnimatorController>(e.animatorController.name);
                        Assert.IsNotNull(controller, "Runtime Controller was not found " + e.animatorController.name);
                    }


                    if (animator == null) animator = go.AddComponent<Animator>();
                    animator.runtimeAnimatorController = controller;
                }
            }
        }
    }
}