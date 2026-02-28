using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Interfaces;
using UI.Abstractions;

namespace UI.Gameplay_State_UI.Shop_Popup_View.View_Model
{
    public class ShopPopupViewModel : PopupViewModelBase, IShopPopupViewModel
    {
        private readonly IShopPopupModel _model;

        public ShopPopupViewModel(IShopPopupModel model)
        {
            _model = model;
        }

        public void OnDimmerClicked() =>
            Hide();
    }
}