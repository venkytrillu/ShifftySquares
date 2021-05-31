using System;
using Entitas;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Systems
{
    public class BlockMoveReactiveSystem : ReactiveSystem<GameEntity>
    {
        private  GameContext _gameContext;
        private GameEntity _playerEntity;

        
        public BlockMoveReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _gameContext = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ComponentsBlockMove);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isComponentsBlockMove;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            Debug.Log("moved");
             var blockEntity = entities.FirstOrDefault();
             var blockPos = blockEntity.componentsSpawnedObject.Value.transform.localPosition;
             blockEntity.ReplaceComponentsBlockUpdatePosition(new Vector3(blockPos.x + 0.000000001f, blockPos.y, blockPos.z));
        }
        
        
    }
}