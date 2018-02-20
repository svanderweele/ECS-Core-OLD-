using System.Collections.Generic;
using Entitas;

namespace Libraries.btcp.ECS.src.Combat.Damage.Components
{
    public sealed class TakeDamageComponent : IComponent
    {
        public Dictionary<int, float> attacks;
    }
}