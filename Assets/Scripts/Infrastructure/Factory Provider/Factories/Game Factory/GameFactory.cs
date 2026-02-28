using System.Collections.Generic;
using System.Threading.Tasks;
using Features.Grid_Item;
using Features.Grid_Item.Definitions;
using Infrastructure.Asset_Provider;
using UnityEngine;

namespace Infrastructure.Factory_Provider.Factories.Game_Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public async Task<GridItemView> CreateGridItem(Transform parent, Vector3 position)
        {
            var definition = await _assetProvider.LoadAsync<GridItemDefinition>(AssetAddress.SquareDefinition);

            var prefab = await _assetProvider.LoadAsync<GameObject>(AssetAddress.GridItemView);

            var view = Object.Instantiate(prefab, position, Quaternion.identity).GetComponent<GridItemView>();

            view.transform.SetParent(parent, false);

            var blockViews = new List<GridBlockView>();

            var centerOffset = new Vector3(0.5f, 0.5f, 0f);

            foreach (var shape in definition.Shape)
            {
                blockViews.Add(await CreateGridBlockView(
                    view.transform,
                    centerOffset,
                    shape,
                    definition.Color
                ));
            }

            view.Construct(blockViews, definition);

            return view;
        }

        private async Task<GridBlockView> CreateGridBlockView(
            Transform parent,
            Vector3 centerOffset,
            Vector2Int position,
            Color color
        )
        {
            var prefab = await _assetProvider.LoadAsync<GameObject>(AssetAddress.GridBlockView);

            var view = Object.Instantiate(prefab, parent).GetComponent<GridBlockView>();

            view.transform.localPosition = new Vector3(position.x, position.y, 0f) + centerOffset;

            view.SetColor(color);

            return view;
        }
    }
}