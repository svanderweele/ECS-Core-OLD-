
using Libraries.btcp.ECS.src.Core.transform.Rotation.Logic;

namespace Libraries.btcp.ECS.src.Core.transform.Rotation
{
    public sealed class RotationSystems : Feature
    {
        public RotationSystems(Contexts contexts) : base("Rotation Systems")
        {
            Add(new RotationSystem(contexts));
        }
    }
}