using System;
using Entitas;
using System.Collections.Generic;
using System.Linq;

namespace Systems.Input.Execute
{
    public class EmitInputSystem : IExecuteSystem
    {
        private InputContext _inputContext;
        private GameContext _gameContext;
        private UnityInputService _inputService;
        private InputEntity _inputEntity;
        private GameEntity _gameStateEntity;

        public EmitInputSystem(Contexts contexts, IInputService inputService)
        {
            _gameContext = contexts.game;
            _inputContext = contexts.input;
            _inputService = (UnityInputService) inputService;
        }

        public void Execute()
        {
            _gameStateEntity = _gameContext.GetEntities(GameMatcher.ComponentsGameState).FirstOrDefault();

            if (_gameStateEntity != null &&
                _gameStateEntity.componentsGameState.Value != global::GameState.GamePlay) return;

            var _inputEntity = _inputContext.GetEntities(InputMatcher.ScreenTap).FirstOrDefault();

            _inputEntity?.ReplaceScreenTap(_inputService.Action1IsPressed);
        }
    }
}