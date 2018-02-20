using System.Collections.Generic;
using Entitas;

namespace Libraries.btcp.ECS.src.Items.Components
{
    public sealed class BagComponent : IComponent
    {
        public List<int> items;
    }
}