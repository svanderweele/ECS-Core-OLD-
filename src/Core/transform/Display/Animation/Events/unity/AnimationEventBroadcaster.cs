using UnityEngine;

namespace unity.Helpers.Animations
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