using System;
using Entitas;
using System.Collections.Generic;
using System.Linq;
using Interfaces.View;
using UnityEngine;

namespace Systems.GameState.Reactive
{
    public class GameStateInitializeSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _gameContext;
        private UnityViewService _viewService;
        private Contexts _contexts;
        private IViewController _viewController;
        
        public GameStateInitializeSystem(Contexts contexts, Services services) : base(contexts.game)
        {
            _contexts = contexts;
            _gameContext = contexts.game;
            _viewService =(UnityViewService)services.View;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameStateChange);
        }

        protected override bool Filter(GameEntity entity)
        {
              return  entity.isGameStateChange;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            entities.FirstOrDefault().isComponentsDestroy = true;
            _viewService.StartScreenState(false);
            SpawnBoard();
            SpawnGameState();
        }
        private void SpawnGameState()
        {
            var entity = _gameContext.CreateEntity();
            entity.ReplaceComponentsGameState(global::GameState.GameIdle);
        }
        
        private void SpawnBoard()
        {
            var entity = _gameContext.CreateEntity();
            entity.isComponentsBoard = true;
            _viewService.LoadAsset(_contexts,entity,Helper.Board, out _viewController);
            var unityViewController = (UnityViewController) _viewController;
            entity.ReplaceComponentsSpawnedObject(unityViewController.ClonedGameObject);
        }

        
    }
}