using Entitas;

using UnityEngine;

namespace Libraries.btcp.ECS.src.AI.Sensors.Sight.Logic
{
    public class LookAtTargetSystem : IExecuteSystem
    {
        private Contexts m_contexts;
        private IGroup<GameEntity> m_group;

        public LookAtTargetSystem (Contexts contexts)
        {
            m_contexts = contexts;
            m_group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.LookingAtTarget, GameMatcher.Target));
        }

        public void Execute()
        {
            foreach (var e in m_group.GetEntities())
            {
                var target = m_contexts.game.GetEntityWithId(e.target.value);

                var position = e.position.value;
                   
                if (e.hasParent)
                {
                    var parent = m_contexts.game.GetEntityWithId(e.parent.value);
                    position += (Vector2) parent.view.gameObject.transform.position;
                }


                var targetPosition = target.position.value;
                
                if (target.hasParent)
                {
                    var parent = m_contexts.game.GetEntityWithId(target.parent.value);
                    targetPosition += (Vector2) parent.view.gameObject.transform.position;
                }


                var diff = targetPosition - position;
                var rotation = Vector3.zero;

                if (e.hasRotation)
                {
                    rotation = e.rotation.value;
                }
                 
                rotation.z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                e.ReplaceRotation(rotation);
            }
        }
    }
}
