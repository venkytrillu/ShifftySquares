using Systems;
using Entitas;
using Interfaces.View;


public class RegisterTargetInitilizeSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
        private UnityViewService _viewService;
        private Contexts _contexts;
        private IViewController _viewController;
        
        public RegisterTargetInitilizeSystem(Contexts contexts,IViewService iViewService)
        {
            _contexts = contexts;
            _gameContext = contexts.game;
           _viewService =(UnityViewService)iViewService;
        }
        public void Initialize()
        {
            var entity = _gameContext.CreateEntity();
            entity.isComponentsTarget = true;
        }
        
    }
