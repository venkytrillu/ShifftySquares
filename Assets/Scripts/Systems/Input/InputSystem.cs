using Systems.Input.Execute;
using Systems.Input.Reactive;
using Entitas;

namespace Systems.Input
{
    public class InputSystem : Feature
    {
        public InputSystem(Contexts contexts, Services services) : base("InputSystem ")
        {
            Add(new EmitInputSystem(contexts, services.Input));
            Add(new InputTapSystem(contexts));
        }

        
    }
}