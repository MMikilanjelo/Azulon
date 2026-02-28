using System.Threading.Tasks;
using Core.Disposables;
using Core.Extensions;
using Core.Reactive.Events;
using UI.Abstractions;
using UI.Components;
using UI.Gameplay_State_UI.Mediator.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI.Gameplay_State_UI.Views
{
    public class ShopPopupView : ScreenViewBase
    {
        [SerializeField] private SlideAnimationComponent _slideAnimationComponent;

        [SerializeField] private DimmerComponent _dimmerComponent;

        private IShopPopupMediator _mediator;

        private CompositeDisposable _subscriptions;

        public void Construct(IShopPopupMediator mediator)
        {
            _mediator = mediator;
        }

        protected override void OnShown()
        {
            _subscriptions = new CompositeDisposable();

            _dimmerComponent.Clicked
                .Subscribe(OnDimmerClicked)
                .AddTo(_subscriptions);
        }

        protected override void OnDestroyed() =>
            _subscriptions.Dispose();

        protected override void OnHidden() =>
            _subscriptions.Dispose();

        private void OnDimmerClicked(EmptyEvent _) =>
            _mediator.OnShopPopUpDimmerClicked();

        protected override Task PlayShowAnimation()
        {
            _dimmerComponent.Show(0.3f);

            return _slideAnimationComponent.PlayIn(new Vector2(0, -Screen.height), Vector2.zero);
        }

        protected override Task PlayHideAnimation()
        {
            _dimmerComponent.Hide(0.3f);

            return _slideAnimationComponent.PlayOut(new Vector2(0, -Screen.height));
        }
    }
}