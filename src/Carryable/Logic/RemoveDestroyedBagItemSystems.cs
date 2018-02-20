using System.Collections.Generic;
using Entitas;



namespace Libraries.btcp.ECS.src.Items.Logic
{
    public class RemoveDestroyedBagItemSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> m_bags;
        private readonly GameContext m_context;

        public RemoveDestroyedBagItemSystem(Contexts contexts) : base(contexts.game)
        {
            m_context = contexts.game;
            m_bags = m_context.GetGroup(GameMatcher.Bag);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Destroyed.Added());
        }


        protected override bool Filter(GameEntity entity)
        {
            return entity.isDestroyed;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var destroyedEntity in entities)
            foreach (var e in m_bags.GetEntities())
                if (e.bag.items.IndexOf(destroyedEntity.id.value) > -1)
                {
                    e.bag.items.Remove(destroyedEntity.id.value);
                    e.ReplaceBag(e.bag.items);
                }
        }
    }
}