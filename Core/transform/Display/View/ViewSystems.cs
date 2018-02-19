using ECS.Core.transform.Display.View.Logic;

namespace ECS.Core.transform.Display.View
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