using System.Collections.Generic;
using Entitas;



namespace Libraries.btcp.ECS.src.Core.Physics.Logic
{
    public class UpdateFallToGroundSystem : ReactiveSystem<GameEntity>
    {
        public UpdateFallToGroundSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.FallToGround.Added(), GameMatcher.Position.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasFallToGround && entity.hasPosition;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.isOnGround = entity.position.value.y <= entity.fallToGround.groundY;

                if (entity.isOnGround)
                {
                    if (entity.hasVelocity)
                    {
                        var velocity = entity.velocity.value;
                        if (velocity.y < 0)
                        {
                            velocity.y = 0; //Stop falling immediately
                            entity.RemoveFallToGround();
                        }

                        entity.ReplaceVelocity(velocity);
                    }
                }
            }
        }
    }
}