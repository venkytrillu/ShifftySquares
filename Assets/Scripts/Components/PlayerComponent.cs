using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Components
{
    [Game]
    public class PlayerComponent : IComponent
    {
    }
    
    [Game]
    public class PlayerNeedsTargetComponent : IComponent
    {
    }
    
    [Game]
    public class PlayerDieComponent : IComponent
    {
    }
    
    [Game]
    public class PlayerRefTargetComponent : IComponent
    {
        public GameObject Value;
    }
    
    [Game]
    public class PlayerHitsTargetComponent : IComponent
    {
    }
    
    [Game,Event(EventTarget.Self)]
    public class PlayerUpdateRotationComponent : IComponent
    {
        public Vector3 Value;
    }
    
    [Game,Event(EventTarget.Self)]
    public class PlayerUpdatePositionComponent : IComponent
    {
        public Vector3 Value;
    }
}