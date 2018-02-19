using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.Assertions;

namespace ECS.Core.transform.Display.Animation.Core.Logic
{
    public class RenderAnimationSystem : ReactiveSystem<GameEntity>
    {
        private Contexts m_contexts;
        private IGroup<GameEntity> m_completedAnimations;

        public RenderAnimationSystem(Contexts contexts) : base(contexts.game)
        {
            m_contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Animation.Added());
            /*
             * TODO:
             * Animation Complete causing Death anim to not play but we need it for patient animations
             */
            return context.CreateCollector(GameMatcher.Animation.Added(), GameMatcher.AnimationComplete.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasAnimation && entity.hasView && entity.hasAnimationDirector;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                var go = e.view.gameObject;
                var animationClip = e.animation.clip;
                var animationDirector = e.animationDirector.director;

                var animation = go.GetComponent<UnityEngine.Animation>();
                Assert.IsNotNull(animation, "Entity does not have an animator, and you're trying to animate");

                bool playAnimation = true;

                if (e.isAnimationComplete == false && e.isNextAnimationPatient)
                {
                    playAnimation = false;
                }

                if (e.isAnimationComplete)
                {
                    if (playAnimation)
                    {
                        playAnimation = (e.isAnimationComplete && e.isAnimationLoop);
                    }
                }

                if (playAnimation)
                {
                    if (animation.GetClip(animationClip.name) == false)
                    {
                        animation.AddClip(animationClip, animationClip.name);
                    }

                    if (animation.GetClip(animationClip.name))
                    {
                        foreach (AnimationState state in animation)
                        {
                            state.time = 0;
                        }
                        animation.Play(animationClip.name);
                    }
                }
                else
                {
                    animation.Stop();
                }
            }
        }
    }
}