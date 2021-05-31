using Systems.Blocks.CleanUp;
using Systems.DebugHandling.CleanUp;
using Entitas;

public class CleanUpSystem : Feature
{

    public CleanUpSystem(Contexts contexts) : base("CleanUpSystem ")
    {
        Add(new GameContextCleanUpSystem(contexts));
        Add(new InputContextCleanUpSystem(contexts));
        Add(new DebugContextCleanUpSystem(contexts));
        Add(new PhysicsContextCleanUpSystem(contexts));
    }

        
}