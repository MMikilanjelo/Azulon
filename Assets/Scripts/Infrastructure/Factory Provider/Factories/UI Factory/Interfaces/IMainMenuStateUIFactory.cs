using System.Threading.Tasks;
using Infrastructure.Factory_Provider.Factories.Interfaces;
using UI.Abstractions;
using UI.Abstractions.Interfaces;
using UI.Main_Menu_State_UI.Mediator.Interfaces;
using UnityEngine;

namespace Infrastructure.Factory_Provider.Factories.UI_Factory.Interfaces
{
    public interface IMainMenuStateUIFactory : IFactory
    {
        Task<IScreenView> CreateMainMenuScreen(Transform parent, IMainMenuScreenMediator mediator);
    }
}