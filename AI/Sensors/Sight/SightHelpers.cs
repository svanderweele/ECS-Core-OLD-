using System.Collections.Generic;

namespace ECS.AI.Sensors.Sight
{
    public static class SightHelpers
    {
        public static void AddSightComponents(GameEntity e, float seeDistance)
        {
            e.AddSightDistance(seeDistance);
            e.isSeeing = true;
        }


        public static List<int> GetEntitiesInSight(GameEntity e)
        {
            if (e.hasSightTargets == false)
            {
                return new List<int>();
            }

            return e.sightTargets.targets;
        }
    }
}