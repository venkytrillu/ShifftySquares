using System;
using Entitas;
using System.Collections.Generic;
using System.Linq;
using Interfaces.View;
using UnityEngine;

namespace Systems
{
    public class PhysicsPlayerTriggerSystem : ReactiveSystem<PhysicsEntity>
    {
        private readonly PhysicsContext _physicsContext;
        private readonly GameContext _gameContext;
        private UnityViewService _viewService;
        private Contexts _contexts;
        private IViewController _viewController;
        public PhysicsPlayerTriggerSystem(Contexts contexts,Services services) : base(contexts.physics)
        {
            _gameContext =contexts.game;
            _physicsContext = contexts.physics;
            _viewService = (UnityViewService)services.View;
        }

        protected override ICollector<PhysicsEntity> GetTrigger(IContext<PhysicsEntity> context)
        {
            return context.CreateCollector(PhysicsMatcher.PhysicsPlayerType);
        }

        protected override bool Filter(PhysicsEntity entity)
        {
            return entity.physicsPlayerType.Value == PlayerType.Player;
        }

        protected override void Execute(List<PhysicsEntity> entities)
        {
            Debug.Log("PhysicsPlayerTriggerSystem");
            var playerEntity=  _gameContext.GetEntities().FirstOrDefault(x => x.isComponentsPlayer);
            var gameStateEntity=  _gameContext.GetEntities().FirstOrDefault(x => x.hasComponentsGameState);
            var blastEntity = _gameContext.CreateEntity();
            _viewService.LoadAsset(_contexts,blastEntity,Helper.Blast, out _viewController);
            var unityViewController = (UnityViewController) _viewController;
            blastEntity.ReplaceComponentsSpawnedObject(unityViewController.ClonedGameObject);
            unityViewController.ClonedGameObject.transform.localPosition =
                playerEntity.componentsSpawnedObject.Value.transform.localPosition;
            gameStateEntity.ReplaceComponentsGameState(global::GameState.GameOver);
            _viewService.GameOverScreenState(true);
        }
    }
}