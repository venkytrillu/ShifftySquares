using Entitas;
using Interfaces.View;
using UnityEngine;

public interface IViewService
{
    void LoadAsset(
        Contexts contexts,
        IEntity entity,
        string assetName);

    void LoadAsset(
        Contexts contexts,
        IEntity entity,
        string assetName, out IViewController viewController);
    
    GameObject LoadAsset(
        string assetName);
}