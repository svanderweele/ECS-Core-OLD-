
using Libraries.btcp.ECS.src.AI.Sensors.Targeting.Logic;

namespace Libraries.btcp.ECS.src.AI.Sensors.Targeting
{
    public sealed class TargetingSystems : Feature
    {
        public TargetingSystems(Contexts contexts) : base("Targeting Systems")
        {
            Add(new RemoveTargetSystem(contexts));
        }
    }
}