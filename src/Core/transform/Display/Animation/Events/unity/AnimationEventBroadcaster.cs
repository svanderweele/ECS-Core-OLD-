
using UnityEngine;

namespace Libraries.btcp.ECS.src.Core.transform.Display.Animation.Events.unity
{
    public class AnimationEventBroadcaster : MonoBehaviour
    {
        public void OnAnimation(AnimationEvent evt)
        {
            BroadcastEvent(evt);
        }

        public void OnAnimComplete(AnimationEvent evt)
        {
            var e = BroadcastEvent(evt);
            e.isAnimationComplete = true;
        }

        private GameEntity BroadcastEvent(AnimationEvent evt)
        {
            var e = Contexts.sharedInstance.game.GetEntityWithView(gameObject);
            e.AddAnimationEvent(evt);
            return e;
        }
    }
}