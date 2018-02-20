using Entitas;

using UnityEngine;

namespace Libraries.btcp.ECS.src.Core.Input.Components
{
    [Input]
    public class MouseDownComponent : IComponent
    {
        public Vector2 position;
    }
}