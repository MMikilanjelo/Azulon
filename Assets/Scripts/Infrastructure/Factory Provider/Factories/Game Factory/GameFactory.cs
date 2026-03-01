using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Definitions;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Definitions.Foods;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Food_Model;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Food_Model.Strategy;
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

        public async Task<FoodModel> CreateFood(FoodId id, Vector2Int gridPosition)
        {
            var definition = await _assetProvider.LoadAsync<FoodDefinition>(GetDefinitionPath(id));

            IFoodResolutionStrategy strategy = definition.Strategy switch
            {
                FoodStrategyType.AdjacencyMultiplier => new AdjacencyMultiplierStrategy(definition.BaseValue, definition.Rules),
                FoodStrategyType.LoneWolf => new LoneWolfStrategy(definition.BaseValue),
                _ => new AdjacencyMultiplierStrategy(definition.BaseValue, definition.Rules),
            };

            return new FoodModel(definition, strategy, gridPosition);
        }

        private string GetDefinitionPath(FoodId id) =>
            $"Definitions/Foods/{id.ToString()}Definition";
    }
}