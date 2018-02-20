

namespace Libraries.btcp.ECS.src.Core.Movement
{
    public class MovementHelpers
    {
        public static void AddMovementComponents(GameEntity e, float speed, float acceleration, float deceleration, float friction,
            float arriveDistance)
        {
            e.AddSpeed(speed);
            e.AddAcceleration(acceleration);
            e.AddDeceleration(deceleration);
            e.AddFriction(friction);
            e.AddArriveDistance(arriveDistance);
            e.isMover = true;
            e.isOnGround = true;
        }
    }
}