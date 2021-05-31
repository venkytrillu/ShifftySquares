using Systems;
using Entitas;

public class TargetSystem : Feature
{
    public TargetSystem(Contexts contexts, Services services) : base("TargetSystem")
    {
        Add(new TargetSpawnReactiveSystem(contexts, services.View));
    }
}