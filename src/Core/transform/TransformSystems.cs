
using Libraries.btcp.ECS.src.Core.transform.Display;
using Libraries.btcp.ECS.src.Core.transform.Position;
using Libraries.btcp.ECS.src.Core.transform.Rotation.Logic;

namespace Libraries.btcp.ECS.src.Core.transform
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