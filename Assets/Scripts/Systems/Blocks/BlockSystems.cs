using Entitas;

namespace Systems.Blocks
{
    public class BlockSystems : Feature
    {
        public BlockSystems(Contexts contexts) : base("BlockSystems ")
        {
            Add(new BlockMoveReactiveSystem(contexts));
        }
    }
}