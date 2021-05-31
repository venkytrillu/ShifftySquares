using Entitas;
using UnityEngine;


public class UnityDebugLogService : MonoBehaviour, ILogService
{
    public DebugEntity _debugEntity;
    public Contexts _Contexts;
    public void Setup(IEntity entity,Contexts contexts)
    {
        _debugEntity = (DebugEntity)entity;
        _Contexts = contexts;
    }

    public string LogMessage(string message)
    {
        _debugEntity.ReplaceDebugLog(message);
        Debug.Log(message);
        return message;
    }
}