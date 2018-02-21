
using Libraries.btcp.ECS.src.AI;
using Libraries.btcp.ECS.src.Combat;
using Libraries.btcp.ECS.src.Core.Input;
using Libraries.btcp.ECS.src.Core.Management;
using Libraries.btcp.ECS.src.Core.Movement;
using Libraries.btcp.ECS.src.Core.Parenting;
using Libraries.btcp.ECS.src.Core.Physics;
using Libraries.btcp.ECS.src.Core.transform;
using Libraries.btcp.ECS.src.Core.transform.Position.Shake;
using Libraries.btcp.ECS.src.Items;
using Libraries.btcp.RPG_Core.src.Directors.Combat.ECS;

namespace Libraries.btcp.ECS.src.Core
{
    public sealed class CoreSystems : Feature
    {
        public CoreSystems(Contexts contexts) : base("Core Systems")
        {
            //TODO : Organise systems better
            Add(new ParentingSystems(contexts));
            Add(new CollisionSystems(contexts));
            Add(new InputSystems(contexts));
            Add(new TransformSystems(contexts));
            Add(new ManagementSystems(contexts));
            Add(new MovementSystems(contexts));
            Add(new PhysicsSystems(contexts));

            //TODO: Should be better named
            Add(new CombatDirectorSystems(contexts));
            Add(new CombatSystems(contexts));
            Add(new ItemSystems(contexts));
            Add(new AISystems(contexts));
            Add(new EffectSystems(contexts));
        }
    }
}