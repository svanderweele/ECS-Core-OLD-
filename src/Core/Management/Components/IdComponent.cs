using Entitas;
using Entitas.CodeGeneration.Attributes;


namespace Libraries.btcp.ECS.src.Core.Management.Components
{
    [Game]
    public class IdComponent : IComponent
    {
        [PrimaryEntityIndex]public int value;
    }
}