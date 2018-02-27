

namespace Libraries.btcp.ECS.src.Combat
{
    public static class CombatHelpers
    {
        //TODO REPLACE THIS WITH STAT DIRECTOR - Cooldown = Attack Movement_Speed
        public static void AddCombatComponents(GameEntity e, float health, float damage, float cooldown)
        {
            e.AddCooldown(cooldown, cooldown);
        }
    }
}