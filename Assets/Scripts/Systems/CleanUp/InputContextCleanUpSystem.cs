using Entitas;

namespace Systems.Blocks.CleanUp
{
    public class InputContextCleanUpSystem : ICleanupSystem
    {
        private IGroup<InputEntity> _inputGroup;
        private InputContext _inputContext;
        public InputContextCleanUpSystem(Contexts contexts)
        {
            _inputContext = contexts.input;
            _inputGroup = _inputContext.GetGroup(InputMatcher.ComponentsDestroy);
        }

        public void Cleanup()
        {
            foreach(InputEntity ent in _inputGroup.GetEntities())
            {
                ent.Destroy();
            }
        }

    }
}