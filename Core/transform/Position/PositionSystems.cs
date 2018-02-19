namespace ECS.Core.transform.Position
{
    public sealed class PositionSystems : Feature
    {
        public PositionSystems(Contexts contexts)
        {
            Add(new AddPositionSystem(contexts));
            Add(new RenderPositionSystem(contexts));
            Add(new ShakeSystems(contexts));
        }
    }
}   