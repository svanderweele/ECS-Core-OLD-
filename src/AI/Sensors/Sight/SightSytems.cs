
using Libraries.btcp.ECS.src.AI.Sensors.Sight.Logic;

namespace Libraries.btcp.ECS.src.AI.Sensors.Sight
{
    public sealed class SightSytems : Feature
    {
        public SightSytems(Contexts contexts) : base("Sight Systems")
        {
            Add(new UpdateTargetsInSightSystem(contexts));
            Add(new LookAtTargetSystem(contexts));
        }
    }
}