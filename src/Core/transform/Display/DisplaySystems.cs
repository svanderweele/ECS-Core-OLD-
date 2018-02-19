using ECS.Core.transform.Display.Animation;
using ECS.Core.transform.Display.Sprite;
using ECS.Core.transform.Display.View;

namespace ECS.Core.transform.Display
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