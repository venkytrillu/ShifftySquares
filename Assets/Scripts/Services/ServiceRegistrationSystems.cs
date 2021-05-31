using Systems;
using Systems.Input.Initilize;
using Entitas;

public class ServiceRegistrationSystems : Feature
{
    public ServiceRegistrationSystems(Contexts contexts, Services services)
    {
        Add(new RegisterInputServiceSystem(contexts, services.Input));
        Add(new RegisterDebugServiceSystem(contexts, services.Log));
        Add(new RegisterPhysicsServiceSystem(contexts, services.PhysicsServices));
        Add(new RegisterBlockInitilizeSystem(contexts, services.View));
        Add(new RegisterPlayerInitilizeSystem(contexts, services.View));
    }
}