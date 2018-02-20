
using Libraries.btcp.ECS.src.Core.transform.Display.View.Logic;

namespace Libraries.btcp.ECS.src.Core.transform.Display.View
{
    public sealed class ViewSystems : Feature
    {
        public ViewSystems(Contexts contexts)
        {
            Add(new AddViewSystem(contexts));
            Add(new RemoveViewSystem(contexts));
            Add(new ChangeCanvasElementParentSystem(contexts));
        }
    }
}