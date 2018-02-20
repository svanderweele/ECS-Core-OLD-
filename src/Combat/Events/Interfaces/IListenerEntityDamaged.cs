namespace Libraries.btcp.ECS.src.Combat.Events.Interfaces
{
    public interface IListenerEntityDamaged
    {
        void OnEntityDamaged(int entityID, int attackerID, float damage);
    }
}