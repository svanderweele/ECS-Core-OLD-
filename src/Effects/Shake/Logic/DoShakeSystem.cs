using Entitas;

using UnityEngine;

namespace Libraries.btcp.ECS.src.Core.transform.Position.Shake.Logic
{
    public class DoShakeSystem : IExecuteSystem
    {
        private Contexts m_contexts;
        private IGroup<GameEntity> m_group;

        public DoShakeSystem (Contexts contexts)
        {
            m_contexts = contexts;
            m_group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Shake, GameMatcher.ShakeDuration));
        }

        public void Execute()
        {
            foreach (var e in m_group.GetEntities())
            {
                var offset = Vector2.zero;

                var force = e.shake.force;
                var forceApplied = new Vector2(Random.Range((float) -force.x, force.x), Random.Range((float) -force.y, force.y));
                offset += forceApplied;
                force *= .9f; //slowly deduct force
                e.ReplaceShakeOffset(offset);

                var duration = e.shakeDuration.value;
                duration -= Time.deltaTime;
                e.ReplaceShakeDuration(duration);

                if (duration <= 0)
                {
                    e.RemoveShake();
                    e.RemoveShakeDuration();
                    e.RemoveShakeOffset();
                }
            }
        }
    }
}
