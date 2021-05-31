using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Components
{
    [Game,Physics,Input,Debug]
    public class DestroyComponent : IComponent
    {
    }
}