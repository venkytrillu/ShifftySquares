using Entitas;

namespace Systems.Blocks.CleanUp
{
    public class DebugContextCleanUpSystem : ICleanupSystem
    {
        private IGroup<DebugEntity> _debugGroup;
        private DebugContext _debugContext;
        public DebugContextCleanUpSystem(Contexts contexts)
        {
            _debugContext = contexts.debug;
            _debugGroup = _debugContext.GetGroup(DebugMatcher.ComponentsDestroy);
        }

        public void Cleanup()
        {
            foreach(DebugEntity ent in _debugGroup.GetEntities())
            {
                ent.Destroy();
            }
        }

    }
}