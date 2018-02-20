using System.Collections.Generic;
using Entitas;

using UnityEngine;


namespace Libraries.btcp.ECS.src.Core.Physics.Logic
{
    public class ApplyExplosiveForceSystem : ReactiveSystem<GameEntity>
    {
        private Contexts m_contexts;

        public ApplyExplosiveForceSystem (Contexts contexts) : base(contexts.game)
        {
            m_contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ExplosiveForce.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasExplosiveForce;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(var e in entities)
            {
                var steering = Vector2.zero;

                if (e.hasSteering)
                {
                    steering = e.steering.value;
                }
            
                var force = e.explosiveForce.value;

                steering += force;
                e.ReplaceSteering(steering);
                e.RemoveExplosiveForce();
            }
        }
    }
}
