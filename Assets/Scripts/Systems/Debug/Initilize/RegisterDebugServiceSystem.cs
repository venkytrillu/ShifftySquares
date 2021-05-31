using System;
using Entitas;

namespace Systems.Input.Initilize
{
    public class RegisterDebugServiceSystem : IInitializeSystem
    {
        private DebugContext _debugContext;
        private ILogService _logService;
        private InputEntity _inputEntity;
        private Contexts _contexts;
        public RegisterDebugServiceSystem(Contexts contexts,ILogService logService)
        {
            _contexts = contexts;
            _debugContext = contexts.debug;
            _logService = logService;
        }

        public void Initialize()
        {
            var entity = _debugContext.CreateEntity();
            _logService.Setup(entity,_contexts);
            _logService.LogMessage("");
        }

        
    }
}