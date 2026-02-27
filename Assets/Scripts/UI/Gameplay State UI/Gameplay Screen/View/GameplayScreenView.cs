using UI.Abstractions.Interfaces;
using UI.Gameplay_State_UI.Gameplay_Screen.View_Model;
using UnityEngine;

namespace UI.Gameplay_State_UI.Gameplay_Screen.View
{
    public class GameplayScreenView : MonoBehaviour, IScreenView<IGameplayScreenViewModel>
    {
        public void Bind(IGameplayScreenViewModel viewModel)
        {
        }
    }
}