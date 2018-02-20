using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Libraries.btcp.ECS.src.Core.transform.Display.View.Components{
    public class ViewComponent : IComponent{
       [PrimaryEntityIndex] public GameObject gameObject;
    }
}