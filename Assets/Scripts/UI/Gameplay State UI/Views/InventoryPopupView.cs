using System.Threading.Tasks;
using Core.Disposables;
using UI.Abstractions;
using UI.Components;
using UI.Gameplay_State_UI.Mediator.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Gameplay_State_UI.Views
{
    public class InventoryPopupView : PopupViewBase
    {
        [SerializeField] private LayoutGroup _itemsLayoutGroup;
        [SerializeField] private SlideAnimationComponent _slideAnimationComponent;
        [SerializeField] private CustomButtonComponent _closeButton;

        private IInventoryPopupMediator _mediator;

        private CompositeDisposable _subscriptions;

        public void Construct(IInventoryPopupMediator mediator)
        {
            _mediator = mediator;
        }

        protected override void OnShown()
        {
            _subscriptions = new CompositeDisposable();

            _closeButton.onClick.AddListener(_mediator.OnCloseInventoryButtonClicked);

            _mediator.OnInventoryOpened(_itemsLayoutGroup.transform);
        }

        protected override void OnDestroyed()
        {
            _closeButton.onClick.RemoveListener(_mediator.OnCloseInventoryButtonClicked);
            _subscriptions.Dispose();
        }

        protected override void OnHidden()
        {
            _closeButton.onClick.RemoveListener(_mediator.OnCloseInventoryButtonClicked);

            _subscriptions.Dispose();
        }

        protected override Task PlayInAnimation()
        {
            return _slideAnimationComponent.PlayIn(
                new Vector2(-RectTransform.rect.width, 0),
                Vector2.zero
            );
        }

        protected override Task PlayOutAnimation()
        {
            return _slideAnimationComponent.PlayOut(
                new Vector2(-RectTransform.rect.width, 0)
            );
        }
    }
}