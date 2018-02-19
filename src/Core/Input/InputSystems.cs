using Assets.Sources.Gameplay.Mining.Ore.Systems;
using Assets.Sources.Input.Logic;
using UnityEngine;

namespace Assets.Sources.Input
{
    public class InputSystems : Feature
    {
        public InputSystems(Contexts contexts)
        {
            Add(new EmitInputSystem(contexts));
            Add(new EmitInteractionSystem(contexts));
//            Add(new DebugInputSystem(contexts));

        }
    }
}