using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.Assertions;

namespace ECS.Core.transform.Display.View.Logic
{
    public class AddViewSystem : ReactiveSystem<GameEntity>
    {
        /*
         * Creates a Gameobject for Entity
         */


        private Transform goContainer = new GameObject("Entity Views").transform;
        private Contexts m_contexts;

        public AddViewSystem(Contexts contexts) : base(contexts.game)
        {
            m_contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Sprite.Added(), GameMatcher.GameObject.Added(),
                GameMatcher.AnimatorController.Added(), GameMatcher.Prefab.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasView == false;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                string name = "";
                GameObject go = null;

                
                if (e.hasGameObject)
                {
                    go = e.gameObject.go;
                    CreateView(e, go);
                    e.RemoveGameObject();
                    continue;
                }

                if (e.hasPrefab)
                {
                    name = e.prefab.name;
                    var prefab = Resources.Load<GameObject>(name);
                    Assert.IsNotNull(prefab, "Prefab was not found " + name);

                    go = GameObject.Instantiate(prefab);
                    go.name = prefab.name;

                    CreateView(e, go);
                    continue;
                }

                if (e.hasSprite)
                {
                    name = e.sprite.name;
                    go = new GameObject(name);
                    CreateView(e, go);
                    continue;
                }

                if (e.hasAnimatorController)
                {
                    name = e.animatorController.name;
                    go = new GameObject(name);
                    CreateView(e, go);
                    continue;
                }
                
                
                CreateView(e, e.view.gameObject);
            }
        }

        private void CreateView(GameEntity entity, GameObject go)
        {
            go.Link(entity, m_contexts.game);
            go.transform.SetParent(goContainer, false);
            entity.AddView(go);
        }
    }
}