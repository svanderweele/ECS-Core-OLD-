public sealed class ManagementSystems : Feature
{
    public ManagementSystems(Contexts contexts) : base("Management Systems")
    {
        Add(new RemoveDestroyedEntitiesSystem(contexts));
    }
}