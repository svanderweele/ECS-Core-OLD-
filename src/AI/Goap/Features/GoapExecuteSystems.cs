using Libraries.btcp.ECS.src.AI.Goap.Logic;

namespace Libraries.btcp.ECS.src.AI.Goap.Features
{
    public sealed class GoapExecuteSystems : Feature
    {
        public GoapExecuteSystems(Contexts contexts) : base("Init Systems")
        {
            Add(new EnableAgentSystem(contexts));
            Add(new DisableAgentSystem(contexts));
        }
    }
}