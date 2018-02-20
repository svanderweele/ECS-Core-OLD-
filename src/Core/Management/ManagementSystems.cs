
using Libraries.btcp.ECS.src.Core.Management.Logic;

namespace Libraries.btcp.ECS.src.Core.Management
{
    public sealed class ManagementSystems : Feature
    {
        public ManagementSystems(Contexts contexts) : base("Management Systems")
        {
            Add(new RemoveDestroyedEntitiesSystem(contexts));
        }
    }
}