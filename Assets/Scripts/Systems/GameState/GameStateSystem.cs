using Systems.GameState.Reactive;
using Entitas;

namespace Systems.GameState
{
    public class GameStateSystem : Feature
    {

        public GameStateSystem(Contexts contexts, Services services) : base("GameStateSystem ")
        {
            Add(new GameStateInitializeSystem(contexts, services));
            Add(new GameStateGamePlaySystem(contexts, services));
        }

        
    }
}