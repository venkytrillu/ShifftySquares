using System;
using Entitas;


public class RegisterInputServiceSystem : IInitializeSystem
{
    private InputContext _inputContext;
    private UnityInputService _inputService;
    private InputEntity _inputEntity;

    public RegisterInputServiceSystem(Contexts contexts, IInputService inputService)
    {
        _inputContext = contexts.input;
        _inputService = (UnityInputService) inputService;
    }

    public void Initialize()
    {
        _inputContext.isInputManager = true;
        _inputEntity = _inputContext.CreateEntity();
        _inputEntity.ReplaceScreenTap(_inputService.Action1IsPressed);
    }
}