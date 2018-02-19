using ECS.Core.transform.Display;
using ECS.Core.transform.Position;

namespace ECS.Core.transform
{
    public sealed class TransformSystems : Feature
    {
        public TransformSystems(Contexts contexts) : base("Transform Systems")
        {
            Add(new DisplaySystems(contexts));
            Add(new PositionSystems(contexts));
            Add(new RotationSystem(contexts));
        }
    }
}