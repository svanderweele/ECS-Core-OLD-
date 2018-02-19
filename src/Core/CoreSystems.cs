using Assets.Sources.Gameplay.Mining;
using Assets.Sources.Input;
using ECS.Core.Physics;
using ECS.Core.transform;

public sealed class CoreSystems : Feature
{
    public CoreSystems(Contexts contexts) : base("Core Systems")
    {
        //TODO : Organise systems better
        Add(new ParentingSystems(contexts));
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
        
        Add(new ShakeSystems(contexts));
    }
}