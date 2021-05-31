using Entitas;


public interface ILogService
{
    void Setup(IEntity entity,Contexts contexts);
    string LogMessage(string message);
}