using Assets.Sources.Management.Destruction.Logic;

public sealed class ItemSystems : Feature
{
    public ItemSystems(Contexts contexts) : base("Item Systems")
    {
        Add(new RemoveDestroyedBagItemSystem(contexts));
    }
}