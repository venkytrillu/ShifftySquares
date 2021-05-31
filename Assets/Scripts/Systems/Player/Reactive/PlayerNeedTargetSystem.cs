using System;
using Entitas;
using System.Collections.Generic;
using System.Linq;

namespace Systems
{
    public class PlayerNeedTargetSystem : ReactiveSystem<GameEntity>
    {

        private readonly GameContext _gameContext;

        public PlayerNeedTargetSystem(Contexts contexts) : base(contexts.game)
        {
            _gameContext = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ComponentsPlayerHitsTarget);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isComponentsPlayerHitsTarget;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var targetEntity =  _gameContext.GetEntities(GameMatcher.ComponentsTarget).FirstOrDefault();
            if (targetEntity == null) return;
            GameManager.Instance.DestroyInstantiateGameObject(targetEntity.componentsSpawnedObject.Value);
            targetEntity.Destroy();
            var playerEntity =  entities.FirstOrDefault();
            playerEntity.isComponentsPlayerHitsTarget = false;
            playerEntity.isComponentsPlayerNeedsTarget = true;
        }

        
    }
}