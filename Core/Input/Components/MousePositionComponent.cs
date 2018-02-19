using Entitas;
using UnityEngine;

namespace Assets.Sources.Input.Components
{
    [Input]
    public class MousePositionComponent : IComponent
    {
        public Vector2 position;
    }
}