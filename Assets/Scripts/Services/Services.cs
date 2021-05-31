


using Interfaces.Physics;

public class Services
{
    public readonly IInputService Input;
    public readonly ILogService Log;
    public readonly IViewService View;
    public readonly IPhysicsServices PhysicsServices;

    public Services(ILogService log,IInputService input, IViewService view,IPhysicsServices physicsServices )
    {
        Input = input;
        Log = log;
        View = view;
        PhysicsServices = physicsServices;
    }
}