using Entitas;
using Interfaces.View;
using UnityEngine;

public class UnityViewService : UIManager, IViewService
{

    public void LoadAsset(Contexts contexts, IEntity entity, string assetName)
    {
        _GameContext = contexts.game;
        var viewGo = Instantiate(Resources.Load<GameObject>("Prefabs/" + assetName));
        if (viewGo == null) _debugEntity.ReplaceDebugLog("-- viewGo is null --");
        var viewController = viewGo.GetComponent<IViewController>();
        viewController?.InitializeView(contexts, entity, viewGo);
    }

    public void LoadAsset(Contexts contexts, IEntity entity, string assetName, out IViewController view)
    {
        if( _GameContext ==null)
            _GameContext = contexts.game;
        var viewGo = Instantiate(Resources.Load<GameObject>("Prefabs/" + assetName));
        if (viewGo == null) _debugEntity.ReplaceDebugLog("-- viewGo is null --");
        var viewController = viewGo.GetComponent<IViewController>();
        viewController?.InitializeView(contexts, entity, viewGo);
        view = viewController;
    }

    public GameObject LoadAsset(string assetName)
    {
        var obj = Instantiate(Resources.Load<GameObject>("Prefabs/" + assetName));
        return obj;
    }
}