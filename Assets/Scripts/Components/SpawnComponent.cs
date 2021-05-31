using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Components
{
    [Game]
    public class SpawnedObjectComponent : IComponent
    {
        public GameObject Value;
    }
}