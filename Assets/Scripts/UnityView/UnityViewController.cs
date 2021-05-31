using Entitas;
using Interfaces.View;
using UnityEngine;

public class UnityViewController : MonoBehaviour, IViewController
{
    public Vector3 Position
    {
        get { return transform.localPosition; }
        set { transform.localPosition = value; }
    }

    public Vector3 Scale
    {
        get { return transform.localScale; }
        set { transform.localScale = value; }
    }

    public bool isActive {
        get => ClonedGameObject.activeInHierarchy;
        set => ClonedGameObject.SetActive(value);
    }
    public Contexts Contexts;
    private GameEntity _gameEntity;
    private GameObject clonedGameObject;
    public GameObject ClonedGameObject => clonedGameObject;


    public void InitializeView(Contexts contexts, IEntity entity, GameObject obj)
    {
        Contexts = contexts;
        _gameEntity = (GameEntity) entity;
        clonedGameObject = obj;
    }

    public void DestroyView()
    {
        Destroy(this);
    }
}