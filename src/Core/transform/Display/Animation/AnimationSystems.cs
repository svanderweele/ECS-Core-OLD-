using ECS.Core.transform.Display.Animation.Core.Logic;
using ECS.Core.transform.Display.Animation.Events.Logic;

namespace ECS.Core.transform.Display.Animation
{
    public sealed class AnimationSystems : Feature
    {
        public AnimationSystems(Contexts contexts) : base("Animation Systems")
        {
            Add(new RenderAnimatorControllerSystem(contexts));
            Add(new CreateAnimationSystem(contexts));
            Add(new RenderAnimationSystem(contexts));
            Add(new AddAnimationEventBroadcasterSystem(contexts));
            Add(new RemoveAnimationEventBroadcasterSystem(contexts));
            Add(new RemoveAnimationEventSystem(contexts));
            
            
        }
    }
}