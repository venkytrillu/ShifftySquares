﻿using System;
using Entitas;
using System.Collections.Generic;

namespace Systems
{
    public class BlockReactiveSystem : ReactiveSystem<GameEntity>
    {

        public BlockReactiveSystem(Contexts contexts) : base(contexts.game)
        {

        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            throw new NotImplementedException();
        }

        protected override bool Filter(GameEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(List<GameEntity> entities)
        {
            throw new NotImplementedException();
        }

        
    }
}