using System.Threading.Tasks;
using Application.State_Machine.Application_State_Machine.States.Main_Menu_State;

namespace UI.Main_Menu_State_UI.Mediator.Interfaces
{
    public interface IMainMenuStateUIMediator
    {
        void Initialize(MainMenuState state);
        void Dispose();
        Task CreateMainMenuScreen();
    }
}