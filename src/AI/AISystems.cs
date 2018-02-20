using Libraries.btcp.ECS.src.AI.Goap;
using Libraries.btcp.ECS.src.AI.Sensors;

namespace Libraries.btcp.ECS.src.AI
{
    // ReSharper disable once InconsistentNaming
    public sealed class AISystems : Feature
    {
        public AISystems(Contexts contexts) : base("AI Systems")
        {
            Add(new SensorSystems(contexts));
            Add(new GoapSystems(contexts));
        }
    }
}