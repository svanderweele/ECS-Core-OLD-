using Assets.Sources.Transform.Movement.Logic;

public sealed class MovementSystems : Feature
{
    public MovementSystems(Contexts contexts) : base("Movement Systems")
    {
        Add(new MoveSystem(contexts));
    }
}