using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Components
{
    
    [Game]
    public class BlockComponent : IComponent
    {
    }
    
    [Game]
    public class BlockMoveComponent : IComponent
    {
    }
    
    [Game]
    public class BlockMoveInitialTimeComponent : IComponent
    {
        public float Value;
    }
    
    [Game]
    public class BlockMoveStateComponent : IComponent
    {
        public BlockPosState Value;
    }
    
    [Game,Event(EventTarget.Self)]
    public class BlockUpdateRotationComponent : IComponent
    {
        public Vector3 Value;
    }
    
    [Game,Event(EventTarget.Self)]
    public class BlockUpdatePositionComponent : IComponent
    {
        public Vector3 Value;
    }
}