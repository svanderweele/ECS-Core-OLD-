using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace ECS.Core.transform.Display.View.Components{
    public class ViewComponent : IComponent{
       [PrimaryEntityIndex] public GameObject gameObject;
    }
}