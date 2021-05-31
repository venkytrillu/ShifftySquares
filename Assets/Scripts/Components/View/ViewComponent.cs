using Entitas;
using Interfaces.View;

[Game]
public class ViewComponent : IComponent
{
    public IViewController Value;
}

[Game]
public class ViewServiceComponent : IComponent
{
    public UnityViewService Value;
}