using Entitas;
using UnityEngine;

namespace Sources.Input.Components
{
    [Input]
    public class MouseDownComponent : IComponent
    {
        public Vector2 position;
    }
}