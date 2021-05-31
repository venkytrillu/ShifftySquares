using System;
using Entitas;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Systems
{
    public class PlayerDirectionChangeSystem : ReactiveSystem<InputEntity>
    {
        private readonly InputContext _inputContext;

        public PlayerDirectionChangeSystem(Contexts contexts) : base(contexts.input)
        {
            _inputContext = contexts.input;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.ScreenTap);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasScreenTap && entity.screenTap.Value;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            GameManager.Instance.dir *= -1;
        }
    }
}