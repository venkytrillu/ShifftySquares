using System;
using Entitas;
using System.Collections.Generic;
using System.Linq;
using Interfaces.View;
using UnityEngine;

namespace Systems.GameState.Reactive
{
    public class GameStateGamePlaySystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _gameContext;
        private UnityViewService _viewService;
        private Contexts _contexts;
        private IViewController _viewController;
        
        public GameStateGamePlaySystem(Contexts contexts, Services services) : base(contexts.game)
        {
            _contexts = contexts;
            _gameContext = contexts.game;
            _viewService =(UnityViewService)services.View;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ComponentsGameState);
        }

        protected override bool Filter(GameEntity entity)
        {
              return  entity.hasComponentsGameState && entity.componentsGameState.Value == global::GameState.GameIdle;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            _gameContext.GetEntities(GameMatcher.ComponentsPlayer).FirstOrDefault(x => x.isComponentsPlayer).isComponentsPlayerNeedsTarget = true;
            entities.FirstOrDefault().ReplaceComponentsGameState(global::GameState.GamePlay);
          // Debug.Log("isComponentsPlayerNeedsTarget");
        }


        
    }
}