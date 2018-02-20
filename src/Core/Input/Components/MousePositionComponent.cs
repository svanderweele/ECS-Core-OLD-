using Entitas;

using UnityEngine;

namespace Libraries.btcp.ECS.src.Core.Input.Components
{
    [Input]
    public class MousePositionComponent : IComponent
    {
        public Vector2 position;
    }
}