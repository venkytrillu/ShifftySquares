using Entitas;
using Interfaces.Physics;
using UnityEngine;

public class UnityPhysicsServices : UnityDebugLogService, IPhysicsServices
{
    public PlayerType playerType;
    public GameObject HitGameObject { get; set; }

    private PhysicsEntity _physicsEntity;

    public void SetUp(IEntity entity)
    {
        _physicsEntity = (PhysicsEntity) entity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag(Helper.Player))
        {
            HitGameObject = other.gameObject;
            _physicsEntity.ReplacePhysicsPlayerType(PlayerType.Player);
        }
    }
}