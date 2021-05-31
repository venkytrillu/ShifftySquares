using System;
using System.Collections;
using System.Collections.Generic;
using Systems;
using Systems.Blocks;
using Systems.GameState;
using Systems.GameState.Reactive;
using Systems.Input;
using Systems.Physics;
using Systems.Player;
using UnityEngine;
using Entitas;
using Entitas.VisualDebugging.Unity;

using UnityEngine.Serialization;





public class GameManager : Singleton<GameManager>
{
    public TargetPlace CurrentTargetPlace = TargetPlace.Up;
    private Entitas.Systems _systems;
    private readonly Contexts _contexts = Contexts.sharedInstance;
    private Services _services;
    public int dir=1;
    public Vector3 Pos;
    protected override void Awake()
    {
        base.Awake();
        _services = new Services(
            GetComponentInChildren<UnityDebugLogService>(),
            GetComponentInChildren<UnityInputService>(),
            GetComponentInChildren<UnityViewService>(),
            new UnityPhysicsServices());
    }

    private void Start()
    {
        _systems = CreateSystem(_contexts);
        _systems.Initialize();
    }

    private Entitas.Systems CreateSystem(Contexts contexts)
    {
        this.SetupVisualDebugging();
        return new Feature("System")
                
                .Add(new ServiceRegistrationSystems(contexts, _services))
                .Add(new InputSystem(contexts, _services))
                .Add(new PhysicsSystem(contexts,_services))
                .Add(new GameStateSystem(contexts, _services))
                .Add(new PlayerSystem(contexts))
                .Add(new GameEventSystems(contexts))
                .Add(new TargetSystem(contexts,_services))
                .Add(new BlockSystems(contexts))
                .Add(new CleanUpSystem(contexts))
            ;
    }

    private void Update()
    {
        _systems.Execute();
    }

    private void LateUpdate()
    {
        _systems.Cleanup();
    }

    private void SetupVisualDebugging()
    {
        GameContext gameContext = Contexts.sharedInstance.game;
        ContextObserver gameContextObserver = new ContextObserver(gameContext);
        gameContextObserver.gameObject.transform.SetParent(this.gameObject.transform);

        InputContext inputContext = Contexts.sharedInstance.input;
        ContextObserver inputContextObserver = new ContextObserver(inputContext);
        inputContextObserver.gameObject.transform.SetParent(this.gameObject.transform);

        PhysicsContext physicsContext = Contexts.sharedInstance.physics;
        ContextObserver physicsContextObserver = new ContextObserver(physicsContext);
        physicsContextObserver.gameObject.transform.SetParent(this.gameObject.transform);
        
        DebugContext debugContext = Contexts.sharedInstance.debug;
        ContextObserver debugContextObserver = new ContextObserver(debugContext);
        debugContextObserver.gameObject.transform.SetParent(this.gameObject.transform);
    }


    public GameObject InstantiateGameObjectObject(GameObject obj)
    {
        return Instantiate(obj);
    }

    public void DestroyInstantiateGameObject(GameObject obj, float time = 0)
    {
        Destroy(obj, time);
    }

    public void StartCoroutineMethod(IEnumerator value)
    {
        StartCoroutine(value);
    }
}