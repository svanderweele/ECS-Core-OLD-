using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class ApplyFadeSystem : IExecuteSystem
{
    private Contexts m_contexts;
    private IGroup<GameEntity> m_group;

    public ApplyFadeSystem(Contexts contexts)
    {
        m_contexts = contexts;
        m_group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.View, GameMatcher.FadeStart,
            GameMatcher.FadeTarget, GameMatcher.FadeDuration, GameMatcher.FadeTime));
    }

    public void Execute()
    {
        foreach (var e in m_group.GetEntities())
        {
            var go = e.view.gameObject;
            
            
            //TODO : RendererHelpers - GetAllRenderers, Include all elements that have color property
            var renderers = go.GetComponentsInChildren<Text>();

            var time = e.fadeTime.time;
            var duration = e.fadeDuration.duration;

            var start = e.fadeStart.value;
            var target = e.fadeTarget.value;
            var perc = time / duration;

            foreach (var renderer in renderers)
            {
                var color = renderer.color;
                color.a = (target - start) * perc;
                renderer.color = color;
            }

            time += Time.deltaTime;
            e.ReplaceFadeTime(time);

            if (perc >= 1)
            {
                e.RemoveFadeDuration();
                e.RemoveFadeTarget();
                e.RemoveFadeStart();
                e.RemoveFadeTime();
            }
        }
    }
}