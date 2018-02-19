using System.Collections.Generic;

namespace ECS.Combat.Damage
{
    public static class DamageHelpers
    {
        public static void DealDamage(GameEntity entity, GameEntity attacker, float damage)
        {
            if (entity.hasTakeDamage)
            {
                var takeDamage = entity.takeDamage;

                if (takeDamage.attacks.ContainsKey(attacker.id.value) == false)
                {
                    takeDamage.attacks.Add(attacker.id.value, damage);
                }
                else
                {
                    takeDamage.attacks[attacker.id.value] += damage;
                }
                
                entity.ReplaceTakeDamage(takeDamage.attacks);
            }
            else
            {
                var attacks = new Dictionary<int, float>();
                attacks.Add(attacker.id.value, damage);
                entity.AddTakeDamage(attacks);
            }
        }
    }
}