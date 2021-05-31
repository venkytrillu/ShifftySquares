using Entitas;

namespace Systems.DebugHandling
{
    public class DebugLogSystem : Feature
    {
        public DebugLogSystem(Contexts contexts) : base("DebugLogSystem ")
        {
           // Add(new HandleDebugLogMessageSystem(contexts,));
        }
    }
}