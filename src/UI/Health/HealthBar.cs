using Libraries.btcp.ECS.src.Combat.Events.Interfaces;
using Libraries.btcp.ECS.src.Core.Management.Events;
using Libraries.btcp.src.Stats.ECS;
using Mine.ECS.Gameplay.UI.Components;
using Mine.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace Libraries.btcp.src.UI.Health
{
    public class HealthBar : MonoBehaviour, IListenerEntityDamaged, IListenerEntityDestroyed, IHealthBar
    {
        [SerializeField] private Image m_contentImage;
        private GameEntity m_actor;
        private GameEntity m_entity;
        
        public void SetEntity(GameEntity entity, GameEntity actor)
        {
            m_entity = entity;
            m_actor = actor;
            UpdateHealth();
        }

        public void OnEntityDamaged(int entityID, int attackerID, float damage)
        {
            if (entityID != m_actor.id.value) return;
            UpdateHealth();
        }

        private void UpdateHealth()
        {
            var health = StatHelpers.CalculateStat(m_actor, StatId.Current_Health);
            var totalHealth = StatHelpers.CalculateStat(m_actor, StatId.Total_Health);
            var perc =  (health / totalHealth);
            m_contentImage.fillAmount = perc;
        }

        public void OnEntityDestroyed(int entityID)
        {
            if (entityID != m_actor.id.value) return;
            m_entity.isDestroyed = true;
            m_entity.RemoveListener_EntityDamaged();
            m_entity.RemoveListener_EntityDestroyed();
        }

        public bool DoesHealthBarBelongTo(GameEntity entity)
        {
            return (m_actor.id.value == entity.id.value);
        }
    }
}