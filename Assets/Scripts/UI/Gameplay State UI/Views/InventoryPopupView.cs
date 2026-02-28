using System.Threading.Tasks;
using Core.Disposables;
using UI.Abstractions;
using UI.Components;
using UI.Gameplay_State_UI.Mediator.Interfaces;
using UnityEngine;

namespace UI.Gameplay_State_UI.Views
{
    public class InventoryPopupView : ScreenViewBase
    {
        [SerializeField] private SlideAnimationComponent _slideAnimationComponent;

        private IInventoryPopupMediator _mediator;

        private CompositeDisposable _subscriptions;

        public void Construct(IInventoryPopupMediator mediator)
        {
            _mediator = mediator;
        }

        protected override void OnShown()
        {
            _subscriptions = new CompositeDisposable();
        }

        protected override void OnDestroyed() =>
            _subscriptions.Dispose();

        protected override void OnHidden() =>
            _subscriptions.Dispose();

        protected override Task PlayShowAnimation()
        {
            return _slideAnimationComponent.PlayIn(
                new Vector2(-RectTransform.rect.width, 0),
                Vector2.zero
            );
        }

        protected override Task PlayHideAnimation()
        {
            return _slideAnimationComponent.PlayOut(
                new Vector2(-RectTransform.rect.width, 0)
            );
        }
    }
}