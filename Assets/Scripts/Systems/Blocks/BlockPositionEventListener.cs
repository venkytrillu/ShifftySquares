using System.Linq;
using UnityEngine;

public class BlockPositionEventListener : Singleton<BlockPositionEventListener>, IComponentsBlockUpdatePositionListener
{
    private float _timeBtwSpawns = 0;
    private readonly float _startTimeBtwSpawns = 0.09f;
    public GameContext _GameContext;
    private bool isInitialHit = false;

    public void OnComponentsBlockUpdatePosition(GameEntity entity, Vector3 value)
    {
        var right = new Vector3(DataConstants.Instance.BlockMaxX,
            value.y, 0);
        var left = new Vector3(DataConstants.Instance.BlockMinX,
            value.y, 0);
        if (entity.componentsBlockMoveState.Value == BlockPosState.Left)
        {
            if (Vector3.Distance(entity.componentsSpawnedObject.Value.transform.localPosition,
                right) > 0.00000001f)
            {
                var localPosition = entity.componentsSpawnedObject.Value
                    .transform.localPosition;
                localPosition = Vector3.MoveTowards(
                    localPosition,
                    right, DataConstants.Instance.Speed * Time.deltaTime);
                entity.componentsSpawnedObject.Value.transform
                    .localPosition = localPosition;
                entity.ReplaceComponentsBlockUpdatePosition(localPosition);
            }
            else
            {
                entity.ReplaceComponentsBlockMoveState(BlockPosState.Right);
                entity.isComponentsBlockMove = false;
                MoveRandomBlock();
            }
        }
        else
        {
            if (Vector3.Distance(entity.componentsSpawnedObject.Value.transform.localPosition,
                left) > 0.00000001f)
            {
                var localPosition = entity.componentsSpawnedObject.Value
                    .transform.localPosition;

                localPosition = Vector3.MoveTowards(
                    localPosition,
                    left, DataConstants.Instance.Speed * Time.deltaTime);
                entity.componentsSpawnedObject.Value.transform.localPosition = localPosition;
                entity.ReplaceComponentsBlockUpdatePosition(localPosition);
            }
            else
            {
                entity.ReplaceComponentsBlockMoveState(BlockPosState.Left);
                entity.isComponentsBlockMove = false;
                MoveRandomBlock();
            }
        }
    }

    private void MoveRandomBlock()
    {
        var blockEntities = _GameContext.GetEntities().Where(x => x.hasComponentsBlockMoveState).ToList();
        int index = Random.Range(0, blockEntities.Count());
        blockEntities[index].isComponentsBlockMove = true;
    }
}