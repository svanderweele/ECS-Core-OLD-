using Libraries.btcp.ECS.src.AI.Goap.Logic;

namespace Libraries.btcp.ECS.src.AI.Goap
{
    public sealed class GoapSystems : Feature
    {
        public GoapSystems(Contexts contexts) : base("GOAP Systems")
        {
            Add(new EnableAgentSystem(contexts));
            Add(new DisableAgentSystem(contexts));
            Add(new UpdateAgentSystem(contexts));
            Add(new IterateAgentActionsSystem(contexts));
            Add(new UpdateAgentCurrentActionSystem(contexts));
        }
    }
}