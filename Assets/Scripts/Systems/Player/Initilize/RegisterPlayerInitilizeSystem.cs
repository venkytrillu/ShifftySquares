using Systems;
using Entitas;
using Interfaces.View;


public class RegisterPlayerInitilizeSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
        private UnityViewService _viewService;
        private Contexts _contexts;
        private IViewController _viewController;
        
        public RegisterPlayerInitilizeSystem(Contexts contexts,IViewService iViewService)
        {
            _contexts = contexts;
            _gameContext = contexts.game;
           _viewService =(UnityViewService)iViewService;
        }
        public void Initialize()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            var entity = _gameContext.CreateEntity();
            entity.isComponentsPlayer = true;
            _viewService.LoadAsset(_contexts,entity,Helper.Player, out _viewController);
            var unityViewController = (UnityViewController) _viewController;
            entity.ReplaceComponentsSpawnedObject(unityViewController.ClonedGameObject);
            PositionEventListener.Instance.Setup(_viewService);
            PositionEventListener.Instance._GameContext = _gameContext;
            entity.AddComponentsPlayerUpdatePositionListener(PositionEventListener.Instance);
            unityViewController.Position = DataConstants.Instance.PlayerInitilizePosition();
            GameManager.Instance.Pos = DataConstants.Instance.PlayerInitilizePosition();
        }
    }
