using System;
using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.Input.Reactive
{
    public class InputTapSystem : ReactiveSystem<InputEntity>
    {
        private InputContext _inputContext;
        private InputEntity _inputEntity;

        public InputTapSystem(Contexts contexts) : base(contexts.input)
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
           Debug.Log("taped");
        }

        
    }
}