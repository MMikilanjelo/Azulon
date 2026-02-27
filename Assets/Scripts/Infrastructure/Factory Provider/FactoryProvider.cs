using System.Collections.Generic;
using Infrastructure.Asset_Provider;
using Infrastructure.Factory_Provider.Factories;
using Infrastructure.Factory_Provider.Factories.Interfaces;
using Infrastructure.Factory_Provider.Factories.UI_Factory;
using Infrastructure.Factory_Provider.Factories.UI_Root_Factory;

namespace Infrastructure.Factory_Provider
{
    public class FactoryProvider : IFactoryProvider
    {
        private readonly Dictionary<FactoryId, IFactory> _factories = new();

        private readonly IAssetProvider _assetProvider;

        public FactoryProvider(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void Initialize()
        {
            _factories.Add(FactoryId.UI, new UIFactory(_assetProvider));
            _factories.Add(FactoryId.UIRoot, new UIRootFactory(_assetProvider));
        }

        public T GetFactoryById<T>(FactoryId id) where T : IFactory =>
            (T)_factories[id];
    }
}