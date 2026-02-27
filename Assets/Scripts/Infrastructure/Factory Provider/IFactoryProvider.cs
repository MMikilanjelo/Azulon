using Infrastructure.Asset_Provider;
using Infrastructure.Factory_Provider.Factories;
using Infrastructure.Factory_Provider.Factories.Interfaces;

namespace Infrastructure.Factory_Provider
{
    public interface IFactoryProvider
    {
        void Initialize();

        T GetFactoryById<T>(FactoryId id) where T : IFactory;
    }
}