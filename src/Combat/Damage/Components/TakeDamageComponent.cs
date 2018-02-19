using System.Collections.Generic;
using Entitas.CodeGeneration.Attributes;

public sealed class TakeDamageComponent : Entitas.IComponent
{
    public Dictionary<int, float> attacks;
}