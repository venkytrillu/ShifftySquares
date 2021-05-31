using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Components
{
    [Game,Unique]
    public class GameStateComponent : IComponent
    {
        public GameState Value;
    }
    
}