using Entitas;

namespace Systems.Physics
{
    public class PhysicsSystem : Feature
    {

        public PhysicsSystem(Contexts contexts, Services services) : base("PhysicsSystem ")
        {
            Add(new PhysicsPlayerTriggerSystem(contexts, services));
        }
    }
}