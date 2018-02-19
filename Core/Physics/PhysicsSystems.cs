using ECS.Core.Physics.Logic;

namespace ECS.Core.Physics
{
    public sealed class PhysicsSystems : Feature
    {
        public PhysicsSystems(Contexts contexts) : base("Physics Systems")
        {
            Add(new ApplyFrictionSystem(contexts));
            Add(new ApplyExplosiveForceSystem(contexts));
            Add(new ApplyVelocitySystem(contexts));
            Add(new ApplyGravitySystem(contexts));
            Add(new ApplySteeringSystem(contexts));
            Add(new UpdateFallToGroundSystem(contexts));
            Add(new RemoveVelocitySystem(contexts));
        }
    }
}