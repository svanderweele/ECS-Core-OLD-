using System.Collections.Generic;
using Entitas;

public class UpdateTargetsInSightSystem : IExecuteSystem
{
    private Contexts m_contexts;
    private IGroup<GameEntity> m_sightEntities;
    private IGroup<GameEntity> m_seeableEntities;


    public UpdateTargetsInSightSystem (Contexts contexts)
    {
        m_contexts = contexts;
        m_sightEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.SightDistance, GameMatcher.Seeing, GameMatcher.Position));
        m_seeableEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.View, GameMatcher.Position));
    }

    public void Execute()
    {
        foreach (var e in m_sightEntities.GetEntities())
        {
            var position = e.position.value;
            var seeDistance = e.sightDistance.distance;
            var targets = new List<int>();

            foreach (var target in m_seeableEntities.GetEntities())
            {
                if (e.id.value == target.id.value)
                {
                    continue;
                }
                
                var targetPosition = target.position.value;
                
                var diff = (targetPosition - position).magnitude;

                if (diff <= seeDistance)
                {
                    targets.Add(target.id.value);
                }
            }


            if (targets.Count == 0)
            {
                if (e.hasSightTargets)
                {
                    e.RemoveSightTargets();
                }
            }
            else
            {
                e.ReplaceSightTargets(targets);
            }
        }
    }
}
