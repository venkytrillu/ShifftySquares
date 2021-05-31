using System;
using System.Linq;
using Entitas;
using Interfaces.View;
using UnityEngine;

namespace Systems
{
    public class RegisterBlockInitilizeSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
        private UnityViewService _viewService;
        private Contexts _contexts;
        private IViewController _viewController;
        private PhysicsContext _physicsContext;
        private PhysicsEntity _physicsEntity;
        public RegisterBlockInitilizeSystem(Contexts contexts,IViewService iViewService)
        {
            _contexts = contexts;
            _physicsContext = contexts.physics;
            _gameContext = contexts.game;
            _viewService =(UnityViewService)iViewService;
        }

        public void Initialize()
        {
            _physicsEntity = _physicsContext.GetEntities().FirstOrDefault(x=>x.isPhysics);
            SpawnBlocks();
        }

        private void SpawnBlocks()
        {
            for (int i = 0; i < DataConstants.Instance.BlockY.Length; i++)
            {
                var entity = _gameContext.CreateEntity();
                entity.isComponentsBlock = true;
                _viewService.LoadAsset(_contexts,entity,Helper.Block, out _viewController);
                var unityViewController = (UnityViewController) _viewController;
                var spawnObject = unityViewController.ClonedGameObject;
                spawnObject.transform.localPosition = i < DataConstants.Instance.BlockY.Length/2
                    ? new Vector3(DataConstants.Instance.BlockMinX, DataConstants.Instance.BlockY[i], 0)
                    : new Vector3(DataConstants.Instance.BlockMaxX, DataConstants.Instance.BlockY[i], 0);
                entity.ReplaceComponentsBlockMoveState(i >= DataConstants.Instance.BlockY.Length/2 ? BlockPosState.Right : BlockPosState.Left);
                entity.ReplaceComponentsBlockMoveInitialTime(2);
                var pos = spawnObject.transform.localPosition;
                entity.ReplaceComponentsUpdatePosition(pos);
                BlockPositionEventListener.Instance._GameContext = _gameContext;
                var unityPhysicsServices = spawnObject.GetComponent<UnityPhysicsServices>();
                unityPhysicsServices.SetUp(_physicsEntity);
                entity.AddComponentsBlockUpdatePositionListener(BlockPositionEventListener.Instance);
                entity.ReplaceComponentsSpawnedObject(spawnObject);
            }
        }
    }
}