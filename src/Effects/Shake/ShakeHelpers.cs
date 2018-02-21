using UnityEngine;

namespace Libraries.btcp.ECS.src.Core.transform.Position.Shake
{
    public static class ShakeHelpers
    {
        public static void AddShake(GameEntity e, Vector2 force, float duration)
        {
            if (e.hasShake)
            {
                e.ReplaceShake(force);
                e.ReplaceShakeDuration(duration);
            }
            else
            {
                e.AddShake(force);
                e.AddShakeDuration(duration);
            }
        }
    }
}