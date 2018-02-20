
using Libraries.btcp.ECS.src.Items.Logic;

namespace Libraries.btcp.ECS.src.Items
{
    public sealed class ItemSystems : Feature
    {
        public ItemSystems(Contexts contexts) : base("Item Systems")
        {
            Add(new RemoveDestroyedBagItemSystem(contexts));
        }
    }
}