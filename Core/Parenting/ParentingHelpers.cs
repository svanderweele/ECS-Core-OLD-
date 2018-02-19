using UnityEngine;

namespace ECS.Core.Parenting
{
    public static class ParentingHelpers
    {
        public static void AddParent(GameEntity e, GameEntity parent, Vector2 offset)
        {
            e.AddParent(parent.id.value);
            e.AddPosition(parent.position.value + offset);
        }
    }
}