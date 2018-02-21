using Entitas;
using UnityEngine;

public class ScaleBounceSystem : IExecuteSystem
{
    private Contexts m_contexts;
    private IGroup<GameEntity> m_group;

    public ScaleBounceSystem(Contexts contexts)
    {
        m_contexts = contexts;
        m_group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.ScaleBounce, GameMatcher.ScaleBounceDuration,GameMatcher.ScaleBouncStartSize, GameMatcher.ScaleBounceTime, GameMatcher.View));
    }

    public void Execute()
    {
        foreach (var e in m_group.GetEntities())
        {
            var view = e.view.gameObject;
            var startSize = e.scaleBouncStartSize.size;
            var bounce = e.scaleBounce.bounce;
            var currentTime = e.scaleBounceTime.time;
            var totalTime = e.scaleBounceDuration.duration;

            var perc = currentTime / totalTime;

            var scaleValue = startSize;
            //Scale Up
            if (perc < .5f)
            {
                scaleValue += (perc * 2f) * bounce;
            }
            //Scale Down
            else
            {
                scaleValue += ((totalTime - currentTime) / totalTime) * bounce;
            }
            
            //TODO - ScaleComponent?
            view.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);

            currentTime += Time.deltaTime;
            e.ReplaceScaleBounceTime(currentTime);

            if (perc >= 1)
            {
                e.RemoveScaleBounce();
                e.RemoveScaleBounceDuration();
                e.RemoveScaleBouncStartSize();
                e.RemoveScaleBounceTime();
            }
        }
    }
}