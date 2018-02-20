using System.Collections.Generic;
using Entitas;

using UnityEngine;


namespace Libraries.btcp.ECS.src.Combat.Damage.Logic
{
    public class ApplyDamageSystem : ReactiveSystem<GameEntity>
    {
        private Contexts m_contexts;
        private IGroup<GameEntity> m_damageListeners;

        public ApplyDamageSystem(Contexts contexts) : base(contexts.game)
        {
            m_contexts = contexts;
            m_damageListeners = m_contexts.game.GetGroup(GameMatcher.Listener_EntityDamaged);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TakeDamage.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasTakeDamage && entity.hasHealth;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                var attacks = e.takeDamage.attacks;
                var totalDamage = 0f;

                foreach (var atk in attacks)
                {
                    totalDamage += atk.Value;
                }

                var currentHp = e.health.value;
                currentHp -= totalDamage;
                e.ReplaceHealth(currentHp, e.health.total);
                e.RemoveTakeDamage();

                //TODO : ShakeHelpers?
                e.AddShake(new Vector2(.05f, .05f));
                e.AddShakeDuration(.25f);


                foreach (var atk in attacks)
                {
                    foreach (var listener in m_damageListeners.GetEntities())
                    {
                        listener.listener_EntityDamaged.listener.OnEntityDamaged(e.id.value, atk.Key, totalDamage);
                    }
                }
            }
        }
    }
}