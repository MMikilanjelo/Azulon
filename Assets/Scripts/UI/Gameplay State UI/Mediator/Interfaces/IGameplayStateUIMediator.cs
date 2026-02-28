using System.Threading.Tasks;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State;

namespace UI.Gameplay_State_UI.Mediator.Interfaces
{
    public interface IGameplayStateUIMediator
    {
        void Initialize(GameplayState gameplayState);
        Task CreateGameplayScreen();
        void Dispose();
    }
}