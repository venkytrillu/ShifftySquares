using System;
using Entitas;
using Interfaces.Physics;


public class RegisterPhysicsServiceSystem : IInitializeSystem
{
    private PhysicsContext _physicsContext;
    private UnityPhysicsServices _physicsServices;
    private PhysicsEntity _physicsEntity;

    public RegisterPhysicsServiceSystem(Contexts contexts, IPhysicsServices physicsServices)
    {
        _physicsContext = contexts.physics;
        _physicsServices = (UnityPhysicsServices) physicsServices;
    }

    public void Initialize()
    {
        _physicsEntity = _physicsContext.CreateEntity();
        _physicsEntity.isPhysics = true;
       // _physicsEntity.AddPhysicsPlayerType(PlayerType.Block);
    }
}