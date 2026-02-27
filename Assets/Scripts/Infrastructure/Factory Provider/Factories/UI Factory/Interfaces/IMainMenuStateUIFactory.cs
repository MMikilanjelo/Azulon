using System.Threading.Tasks;
using Application.State_Machine.Application_State_Machine.States.Main_Menu_State.Interfaces;
using Infrastructure.Factory_Provider.Factories.Interfaces;
using UI.Main_Menu_State_UI.Main_Menu_Screen.View_Model;
using UI.Main_Menu_State_UI.Main_Menu_Screen.View;
using UnityEngine;

namespace Infrastructure.Factory_Provider.Factories.UI_Factory.Interfaces
{
    public interface IMainMenuStateUIFactory : IFactory
    {
        Task<IMainMenuScreenViewModel> CreateMainMenuScreen(Transform parent, IMainMenuScreenModel model);
    }
}