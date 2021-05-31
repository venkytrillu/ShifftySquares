using Entitas;
using Entitas.CodeGeneration.Attributes;


[Input, Unique]
public class InputManagerComponent : IComponent
{
}

[Input]
public class ScreenTapComponent : IComponent
{
    public bool Value;
}
