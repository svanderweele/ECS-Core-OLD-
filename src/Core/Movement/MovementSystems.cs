
using Libraries.btcp.ECS.src.Core.Movement.Logic;

namespace Libraries.btcp.ECS.src.Core.Movement
{
    public sealed class MovementSystems : Feature
    {
        public MovementSystems(Contexts contexts) : base("Movement Systems")
        {
            Add(new MoveSystem(contexts));
        }
    }
}