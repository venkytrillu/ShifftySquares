using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Physics,Unique]
public class PhysicsComponent : IComponent
{
}
[Physics]
public class PhysicsPlayerTypeComponent : IComponent
{
    public PlayerType Value;
}