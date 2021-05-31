
namespace Systems.Player
{
    public class PlayerSystem : Feature
    {

        public PlayerSystem(Contexts contexts) : base("PlayerSystem ")
        {
           Add(new PlayerNeedTargetSystem(contexts));
           Add(new PlayerDirectionChangeSystem(contexts));
        }
    }
}