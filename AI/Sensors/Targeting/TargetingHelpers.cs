using System.Collections.Generic;
using Entitas;

namespace ECS.AI.Sensors.Targeting
{
    public static class TargetingHelpers
    {
        public static List<int> GetMatchingTargetsInSight(Contexts contexts, GameEntity e, IMatcher<GameEntity> matcher)
        {
            var gameContext = contexts.game;
            var group = gameContext.GetGroup(matcher);
            var sightTargets = GetSightTargets(gameContext, e);

            var matchingTargets = new List<int>();

            foreach (var targetID in sightTargets)
            {
                var target = gameContext.GetEntityWithId(targetID);

                if (group.ContainsEntity(target))
                {
                    matchingTargets.Add(targetID);
                }
            }

            return matchingTargets;
        }

        public static List<int> GetSightTargets(GameContext context, GameEntity e)
        {
            var targets = new List<int>();

            if (e.hasSightTargets)
            {
                targets = e.sightTargets.targets;
            }

            return targets;
        }


        public static void SetTarget(GameEntity e, GameEntity target)
        {
            if (e.hasTarget)
            {
                e.ReplaceTarget(target.id.value);
            }
            else
            {
                e.AddTarget(target.id.value);
            }
        }

        public static GameEntity GetTarget(Contexts contexts, GameEntity e)
        {
            var targetID = e.hasTarget ? e.target.value : -1;

            if (targetID != -1)
            {
                return contexts.game.GetEntityWithId(targetID);
            }

            return null;
        }

        public static bool DoesCurrentTargetMatch(Contexts contexts, GameEntity entity, IMatcher<GameEntity> matcher)
        {
            var gameContext = contexts.game;
            var group = gameContext.GetGroup(matcher);
            var target = GetTarget(contexts, entity);

            if (group.ContainsEntity(target))
            {
                return true;
            }

            return false;
        }

        public static List<int> GetTargeters(Contexts contexts, GameEntity target)
        {
            var targetID = target.id.value;
            var gameContext = contexts.game;
            var targetersGroup = gameContext.GetGroup(GameMatcher.Target);
            var targeters = new List<int>();

            foreach (var targeter in targetersGroup.GetEntities())
            {
                if (targeter.target.value == targetID)
                {
                  targeters.Add(targeter.id.value);  
                }
            }

            return targeters;
        }
    }
}