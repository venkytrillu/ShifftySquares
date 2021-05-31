using System;
using Entitas;

namespace Systems.DebugHandling.CleanUp
{
    public class HandleDebugLogMessageCleanUpSystem : ICleanupSystem
    {
        private readonly IGroup<DebugEntity> _cleanupEntities;

        public HandleDebugLogMessageCleanUpSystem(Contexts contexts)
        {
            _cleanupEntities = contexts.debug.GetGroup(DebugMatcher.Destroyed);
        }


        public void Cleanup()
        {
            foreach (var entity in _cleanupEntities)
            {
                entity.Destroy();
            }
        }
    }
}