using System.Linq;
using UnityEngine;

public class PositionEventListener : Singleton<PositionEventListener>, IComponentsPlayerUpdatePositionListener
{
    private float _timeBtwSpawns = 0;
    private readonly float _startTimeBtwSpawns = 0.09f;
    public GameContext _GameContext;
    private UnityViewService _viewService;
    private bool isInitialHit = false;

    public void Setup(IViewService iViewService)
    {
        _viewService = (UnityViewService)iViewService;
    }
    public void OnComponentsPlayerUpdatePosition(GameEntity entity, Vector3 value)
    {
        if (entity.isComponentsPlayerHitsTarget) return;

        var spawnObject = entity.componentsPlayerRefTarget.Value;
        if (GameManager.Instance.dir == 1)
        {
            if (Vector3.Distance(spawnObject.transform.localPosition,
                entity.componentsSpawnedObject.Value.transform.localPosition) > 0.00000001f)
            {
                var localPosition = entity.componentsSpawnedObject.Value
                    .transform.localPosition;
                localPosition = Vector3.MoveTowards(
                    localPosition,
                    spawnObject.transform.localPosition, DataConstants.Instance.Speed * Time.deltaTime);

                entity.componentsSpawnedObject.Value.transform
                    .localPosition = localPosition;
                entity.ReplaceComponentsPlayerUpdatePosition(localPosition);
                SpawnAnimation(localPosition);
            }
            else
            {
                GameManager.Instance.Pos = entity.componentsSpawnedObject.Value.transform.localPosition;
                entity.isComponentsPlayerHitsTarget = true;
                InitilizeTargetHit();
            } 
        }
        else
        {
            if (Vector3.Distance(entity.componentsSpawnedObject.Value.transform.localPosition,
                GameManager.Instance.Pos) > 0.00000001f)
            {
                var localPosition = entity.componentsSpawnedObject.Value.transform
                    .localPosition;
                localPosition = new Vector3(localPosition.x, localPosition.y,
                    localPosition.z);
                localPosition = Vector3.MoveTowards(
                    localPosition,
                    GameManager.Instance.Pos, DataConstants.Instance.Speed * Time.deltaTime);

                entity.componentsSpawnedObject.Value.transform
                    .localPosition = localPosition;
                entity.ReplaceComponentsPlayerUpdatePosition(localPosition);
                SpawnAnimation(localPosition);
            }
            else
            {
                GameManager.Instance.Pos = entity.componentsSpawnedObject.Value.transform.localPosition;
                GameManager.Instance.dir *= -1;
                entity.ReplaceComponentsPlayerUpdatePosition(new Vector3(GameManager.Instance.Pos.x,
                    GameManager.Instance.Pos.y + 0.00000001f, 0));
                InitilizeTargetHit();
            }
        }
    }

    private void SpawnAnimation(Vector3 pos)
    {
        if (_timeBtwSpawns <= 0)
        {
            var obj =  _viewService.LoadAsset(Helper.PlayerAnimation);
            // GameManager.Instance.InstantiateGameObjectObject(GameManager.Instance.PlayerAnimationPrefab);
            obj.transform.localRotation = Quaternion.identity;
            obj.transform.localPosition = pos;
            GameManager.Instance.DestroyInstantiateGameObject(obj, 1.1f);
            _timeBtwSpawns = _startTimeBtwSpawns;
        }
        else
        {
            _timeBtwSpawns -= Time.deltaTime;
        }
    }

    private void InitilizeTargetHit()
    {
        if (isInitialHit == false)
        {
            isInitialHit = true;
            var blockEntities =  _GameContext.GetEntities().Where(x => x.hasComponentsBlockMoveState).ToList();
            int index = Random.Range(0, blockEntities.Count());
            blockEntities[index].isComponentsBlockMove = true;
        }
        else
        {
          
        }
    }
}