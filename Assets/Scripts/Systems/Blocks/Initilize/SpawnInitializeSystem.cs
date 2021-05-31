using System;
using Entitas;
using UnityEngine;

namespace Systems
{
    public class SpawnInitializeSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
        private readonly GameEntity _targetEntity;
        public SpawnInitializeSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
        }

        public void Initialize()
        {
           
        }

        

    }
}