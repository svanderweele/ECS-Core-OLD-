using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace ECS.Core.Management.Components
{
    [Game]
    public class IdComponent : IComponent
    {
        [PrimaryEntityIndex]public int value;
    }
}