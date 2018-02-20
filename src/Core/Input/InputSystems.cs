
using Libraries.btcp.ECS.src.Core.Input.Logic;

namespace Libraries.btcp.ECS.src.Core.Input
{
    public class InputSystems : Feature
    {
        public InputSystems(Contexts contexts)
        {
            Add(new EmitInputSystem(contexts));
            Add(new EmitInteractionSystem(contexts));
//            Add(new DebugInputSystem(contexts));

        }
    }
}