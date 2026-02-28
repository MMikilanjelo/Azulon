using System.Threading.Tasks;
using Infrastructure.Asset_Provider;
using UI;
using UI.UI_Root.View;
using UnityEngine;

namespace Infrastructure.Factory_Provider.Factories.UI_Root_Factory
{
    public class UIRootFactory : IUIRootFactory
    {
        private readonly IAssetProvider _assetProvider;

        public UIRootFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public async Task<UIRootView> CreateUIRoot()
        {
            var prefab = await _assetProvider.LoadAsync<GameObject>(AssetAddress.UIRootViewPath);

            var view = Object.Instantiate(prefab).GetComponent<UIRootView>();

            return view;
        }
    }
}