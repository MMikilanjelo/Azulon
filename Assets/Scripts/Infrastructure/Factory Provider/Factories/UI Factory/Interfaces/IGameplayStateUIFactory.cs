using System.Threading.Tasks;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Interfaces;
using Infrastructure.Factory_Provider.Factories.Interfaces;
using UI.Gameplay_State_UI.Gameplay_Screen.View_Model;
using UnityEngine;

namespace Infrastructure.Factory_Provider.Factories.UI_Factory.Interfaces
{
    public interface IGameplayStateUIFactory : IFactory
    {
        Task<IGameplayScreenViewModel> CreateGameplayScreen(Transform parent, IGameplayScreenUIModel model);
    }
}