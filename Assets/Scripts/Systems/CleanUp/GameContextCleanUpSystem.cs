using Entitas;

namespace Systems.Blocks.CleanUp
{
    public class GameContextCleanUpSystem : ICleanupSystem
    {
        private IGroup<GameEntity> _gameGroup;
        private GameContext _gameContext;
        public GameContextCleanUpSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
            _gameGroup = _gameContext.GetGroup(GameMatcher.ComponentsDestroy);
        }

        public void Cleanup()
        {
            foreach(GameEntity ent in _gameGroup.GetEntities())
            {
                ent.Destroy();
            }
        }

    }
}