using System.Threading;
using Core.Extensions;
using Core.Reactive.Events;
using UI.Abstractions.Interfaces;
using UI.Components;
using UI.Gameplay_State_UI.Shop_Popup_View.View_Model;
using UnityEngine;

namespace UI.Gameplay_State_UI.Shop_Popup_View.View
{
    public class ShopPopupView : MonoBehaviour, IPopupView<IShopPopupViewModel>
    {
        [SerializeField] private SlideFromBottomAnimationComponent _slideFromBottomAnimationComponent;

        [SerializeField] private DimmerComponent _dimmerComponent;

        private IShopPopupViewModel _viewModel;

        public void Bind(IShopPopupViewModel viewModel)
        {
            _viewModel = viewModel;

            _viewModel.IsVisible.Subscribe(OnVisibilityChanged);

            _dimmerComponent.Clicked.Subscribe(OnDimmerClicked);
        }

        private void OnVisibilityChanged(bool isVisible)
        {
            if (isVisible)
            {
                _dimmerComponent.Show(0.3f);
                _slideFromBottomAnimationComponent.PlayIn();
            }
            else
            {
                _dimmerComponent.Hide(0.3f);
                _slideFromBottomAnimationComponent.PlayOut().Forget();
            }
        }

        private void OnDimmerClicked(EmptyEvent _) =>
            _viewModel.OnDimmerClicked();
    }
}