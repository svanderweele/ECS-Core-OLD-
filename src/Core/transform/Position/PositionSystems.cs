
using Libraries.btcp.ECS.src.Core.transform.Position.Logic;
using Libraries.btcp.ECS.src.Core.transform.Position.Shake;

namespace Libraries.btcp.ECS.src.Core.transform.Position
{
    public sealed class PositionSystems : Feature
    {
        public PositionSystems(Contexts contexts)
        {
            Add(new AddPositionSystem(contexts));
            Add(new RenderPositionSystem(contexts));
            Add(new EffectShakeSystems(contexts));
        }
    }
}   