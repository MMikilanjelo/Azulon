using System.Threading.Tasks;
using UI.Abstractions;
using UI.Components;
using UI.Main_Menu_State_UI.Mediator.Interfaces;
using UnityEngine;

namespace UI.Main_Menu_State_UI.Views
{
    public class MainMenuScreenView : ScreenViewBase
    {
        [SerializeField] private CustomButtonComponent _startGameButton;

        private IMainMenuScreenMediator _mediator;

        public void Construct(IMainMenuScreenMediator mediator) =>
            _mediator = mediator;

        protected override void OnShown() =>
            _startGameButton.onClick.AddListener(_mediator.OnStartGameButtonClicked);

        protected override void OnDestroyed() =>
            _startGameButton.onClick.RemoveListener(_mediator.OnStartGameButtonClicked);

        protected override void OnHidden() =>
            _startGameButton.onClick.RemoveListener(_mediator.OnStartGameButtonClicked);
    }
}