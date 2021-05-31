using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
namespace Components
{
    [Game]
    public class TransformComponent : IComponent
    {
    }
    
    [Game,Event(EventTarget.Self)]
    public class UpdateScaleComponent : IComponent
    {
        public UnityEngine.Vector3 Value;
    }
    
    [Game,Event(EventTarget.Self)]
    public class UpdateRotationComponent : IComponent
    {
        public UnityEngine.Vector3 Value;
    }
    
    [Game,Event(EventTarget.Self)]
    public class UpdatePositionComponent : IComponent
    {
        public UnityEngine.Vector3 Value;
    }
    

}