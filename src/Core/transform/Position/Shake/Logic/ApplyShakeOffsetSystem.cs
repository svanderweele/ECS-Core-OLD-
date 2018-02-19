using Entitas;
using UnityEngine;

public class ApplyShakeOffsetSystem : IExecuteSystem
{
    private Contexts m_contexts;
    private IGroup<GameEntity> m_group;

    public ApplyShakeOffsetSystem (Contexts contexts)
    {
        m_contexts = contexts;
        m_group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.ShakeOffset, GameMatcher.View));
    }

    public void Execute()
    {
        foreach (var e in m_group.GetEntities())
        {
            var offset = e.shakeOffset.value;
            var go = e.view.gameObject;

            var position = (Vector2) go.transform.position;
            position += offset;
            go.transform.position = position;
        }
    }
}
