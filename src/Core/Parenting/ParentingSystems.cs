
using Libraries.btcp.ECS.src.Core.Parenting.Logic;

namespace Libraries.btcp.ECS.src.Core.Parenting
{
    public sealed class ParentingSystems : Feature
    {
        public ParentingSystems(Contexts contexts) : base("Parenting Systems")
        {
            Add(new DestroyIfParentDestroyedSystem(contexts));
            Add(new SetChildParentSystem(contexts));

        }
    }
}