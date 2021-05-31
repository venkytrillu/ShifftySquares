using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;
using UnityEngine.Analytics;
using Random = UnityEngine.Random;

namespace Systems
{
    public class TargetSpawnReactiveSystem : ReactiveSystem<GameEntity>
    {
        private GameContext _gameContext;
        private GameEntity _playerEntity;
        public static TargetSpawnReactiveSystem instance;
        private GameObject spawnObject;
        private Vector3 playerPos;
        private float _timeBtwSpawns = 0;
        private readonly float _startTimeBtwSpawns = 0.1f;
        private UnityViewService _unityViewService;
        public TargetSpawnReactiveSystem(Contexts contexts,IViewService iViewService) : base(contexts.game)
        {
            if (instance == null)
                instance = this;
            _gameContext = contexts.game;
            _unityViewService = (UnityViewService)iViewService;
        }


        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.ComponentsPlayerNeedsTarget,GameMatcher.ComponentsGameState));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isComponentsPlayerNeedsTarget &&
                   (_gameContext.GetEntities(GameMatcher.ComponentsGameState).FirstOrDefault().componentsGameState.Value == global::GameState.GamePlay) ;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            if (_playerEntity == null)
                _playerEntity = _gameContext.GetEntities(GameMatcher.ComponentsPlayer).FirstOrDefault();
            var targetEntity = _gameContext.GetEntities(GameMatcher.ComponentsTarget).FirstOrDefault();
            targetEntity?.Destroy();
            _playerEntity.isComponentsPlayerNeedsTarget = false;
            SpawnTarget();
            
        }

        private void SpawnTarget()
        {
            var entity = _gameContext.CreateEntity();
            entity.isComponentsTarget = true;
            spawnObject = _unityViewService.LoadAsset(Helper.Target);
            //GameManager.Instance.InstantiateGameObjectObject(GameManager.Instance.TargerPrefab);
            if (GameManager.Instance.CurrentTargetPlace == TargetPlace.Up)
            {
                spawnObject.transform.localPosition =
                    new Vector3(Random.Range(DataConstants.Instance.TargetMinX, DataConstants.Instance.TargetMaxX),
                        -DataConstants.Instance.TargetY, 0);
                GameManager.Instance.CurrentTargetPlace = TargetPlace.Down;
            }
            else
            {
                spawnObject.transform.localPosition =
                    new Vector3(Random.Range(DataConstants.Instance.TargetMinX, DataConstants.Instance.TargetMaxX),
                        DataConstants.Instance.TargetY, 0);
                GameManager.Instance.CurrentTargetPlace = TargetPlace.Up;
            }

            entity.ReplaceComponentsSpawnedObject(spawnObject);
            _playerEntity.ReplaceComponentsPlayerRefTarget(spawnObject);
            ChangePlayerMovement();
        }

        private void ChangePlayerMovement()
        {
            var pos = _playerEntity.componentsSpawnedObject.Value.transform.localPosition;
            _playerEntity.ReplaceComponentsPlayerUpdatePosition(new Vector3(pos.x, pos.y + 0.00000001f, 0));
        }
    }
}