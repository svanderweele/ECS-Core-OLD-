
using Libraries.btcp.ECS.src.Core.transform.Display.Sprite.Logic;

namespace Libraries.btcp.ECS.src.Core.transform.Display.Sprite
{
    public sealed class SpriteSystems : Feature
    {
        public SpriteSystems(Contexts contexts) : base("Sprite Systems")
        {
            Add(new RenderSpriteSystem(contexts));
        }
    }
}