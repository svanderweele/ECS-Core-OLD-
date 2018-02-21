
using Libraries.btcp.ECS.src.Core.transform.Position.Logic;
using Libraries.btcp.ECS.src.Core.transform.Position.Shake;

namespace Libraries.btcp.ECS.src.Core.transform.Position
{
    public sealed class PositionSystems : Feature
    {
        public PositionSystems(Contexts contexts)
        {
            Add(new RemoveCopyPositionSystem(contexts));
            Add(new AddPositionSystem(contexts));
            Add(new CopyPositionSystem(contexts));
            Add(new RenderPositionSystem(contexts));
        }
    }
}   