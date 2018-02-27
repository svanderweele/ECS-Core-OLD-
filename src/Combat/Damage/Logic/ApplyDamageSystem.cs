using System.Collections.Generic;
using Entitas;
using Libraries.btcp.ECS.src.Core.transform.Position.Shake;
using Libraries.btcp.src.Stats.Core.Attributes;
using Libraries.btcp.src.Stats.ECS;
using Mine.Stats;
using UnityEngine;


namespace Libraries.btcp.ECS.src.Combat.Damage.Logic
{
    public class ApplyDamageSystem : ReactiveSystem<GameEntity>
    {
        private Contexts m_contexts;
        private IGroup<GameEntity> m_damageListeners;
        private IGroup<GameEntity> m_takeDamageComplete;

        public ApplyDamageSystem(Contexts contexts) : base(contexts.game)
        {
            m_contexts = contexts;
            m_damageListeners = m_contexts.game.GetGroup(GameMatcher.Listener_EntityDamaged);
            m_takeDamageComplete = m_contexts.game.GetGroup(GameMatcher.TakeDamageComplete);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TakeDamage.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasTakeDamage;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            //Organised systems better to avoid having to do this
            foreach (var e in m_takeDamageComplete.GetEntities())
            {
                e.isTakeDamageComplete = false;
            }
            
            
            foreach (var e in entities)
            {
                var attacks = e.takeDamage.attacks;
                var totalDamage = 0f;

                foreach (var atk in attacks)
                {
                    totalDamage += atk.Value;
                }


                if (e.hasStatDirector == false)
                {
                    Debug.LogWarning("Can't take damage without Stat Director!");
                }

                StatHelpers.DecreaseStatValue(e, StatId.Current_Health, totalDamage);
                e.RemoveTakeDamage();
                e.isTakeDamageComplete = true;

                ShakeHelpers.AddShake(e, new Vector2(.05f, .05f), .25f);


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