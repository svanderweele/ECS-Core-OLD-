
using Libraries.btcp.ECS.src.Core.transform.Display.Animation;
using Libraries.btcp.ECS.src.Core.transform.Display.Sprite;
using Libraries.btcp.ECS.src.Core.transform.Display.View;

namespace Libraries.btcp.ECS.src.Core.transform.Display
{
    public sealed class DisplaySystems : Feature
    {
        public DisplaySystems(Contexts contexts) : base("Display Systems")
        {
            Add(new ViewSystems(contexts));
            Add(new SpriteSystems(contexts));
            Add(new AnimationSystems(contexts));
        }
    }
}