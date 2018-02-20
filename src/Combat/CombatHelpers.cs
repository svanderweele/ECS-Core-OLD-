

namespace Libraries.btcp.ECS.src.Combat
{
    public static class CombatHelpers
    {
        public static void AddCombatComponents(GameEntity e, float health, float damage, float cooldown)
        {
            e.AddHealth(health, health);
            e.AddDamage(damage);
            e.AddCooldown(cooldown, cooldown);
        }
    }
}