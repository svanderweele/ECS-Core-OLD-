public sealed class CollisionSystems : Feature
{
    //TODO : Better approach to collision
    public CollisionSystems(Contexts contexts) : base("Collision Systems")
    {
        Add(new AddBoxColliderSystem(contexts));
    }
}