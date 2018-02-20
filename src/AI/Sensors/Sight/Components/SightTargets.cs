using System.Collections.Generic;
using Entitas;

namespace Libraries.btcp.ECS.src.AI.Sensors.Sight.Components
{
    public sealed class SightTargets : IComponent
    {
        public List<int> targets;
    }
}