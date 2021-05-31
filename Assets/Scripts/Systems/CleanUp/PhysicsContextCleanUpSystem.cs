using Entitas;

namespace Systems.Blocks.CleanUp
{
    public class PhysicsContextCleanUpSystem : ICleanupSystem
    {
        private IGroup<PhysicsEntity> _physicsGroup;
        private PhysicsContext _physicsContext;
        public PhysicsContextCleanUpSystem(Contexts contexts)
        {
            _physicsContext = contexts.physics;
            _physicsGroup = _physicsContext.GetGroup(PhysicsMatcher.ComponentsDestroy);
        }

        public void Cleanup()
        {
            foreach(PhysicsEntity ent in _physicsGroup.GetEntities())
            {
                ent.Destroy();
            }
        }

    }
}