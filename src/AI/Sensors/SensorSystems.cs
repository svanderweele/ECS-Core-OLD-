
using Libraries.btcp.ECS.src.AI.Sensors.Sight;
using Libraries.btcp.ECS.src.AI.Sensors.Targeting;

namespace Libraries.btcp.ECS.src.AI.Sensors
{
    public sealed class SensorSystems : Feature
    {
        public SensorSystems(Contexts contexts) : base("AI Sensors")
        {
            Add(new SightSytems(contexts));
            Add(new TargetingSystems(contexts));
        }
    }
}