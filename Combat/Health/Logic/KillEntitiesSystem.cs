﻿using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class KillEntitiesSystem : ReactiveSystem<GameEntity>
{
    private Contexts m_contexts;

    public KillEntitiesSystem(Contexts contexts) : base(contexts.game)
    {
        m_contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Health);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasHealth && entity.isDead == false;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var currentHp = e.health.value;

            if (currentHp <= 0)
            {
                if (e.hasAnimationDirector)
                {
                    var clip = e.animationDirector.director.CreateAnimationClip("miner_grunt_death_regular",
                        new List<AnimationEvent>());
                    e.animationDirector.director.AddAnimation("miner_grunt_death_regular", clip);
                    e.animationDirector.director.PlayAnim("miner_grunt_death_regular", true, false);
                }

                e.isDead = true;
            }
        }
    }
}