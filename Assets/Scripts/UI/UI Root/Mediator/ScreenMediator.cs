using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Factory_Provider;
using Infrastructure.Factory_Provider.Factories;
using Infrastructure.Factory_Provider.Factories.UI_Root_Factory;
using UI.Abstractions;
using UI.UI_Root.Mediator.Interfaces;
using UI.UI_Root.View;
using UnityEngine;

namespace UI.UI_Root.Mediator
{
    public class ScreenMediator : IScreenStackMediator, IUIRootMediator
    {
        public Transform UIRoot => _uiRootView.transform;

        private readonly IFactoryProvider _factoryProvider;

        private UIRootView _uiRootView;

        private readonly Stack<IScreenView> _screens = new();

        public ScreenMediator(IFactoryProvider factoryProvider)
        {
            _factoryProvider = factoryProvider;
        }

        public async Task Initialize()
        {
            var factory = _factoryProvider.GetFactoryById<IUIRootFactory>(FactoryId.UIRoot);

            _uiRootView = await factory.CreateUIRoot();
        }

        public async Task Push<T>(Func<Transform, Task<T>> factory) where T : IScreenView
        {
            if (_screens.TryPeek(out var current))
            {
                await current.Hide();
            }

            var screen = await factory.Invoke(_uiRootView.transform);

            _screens.Push(screen);

            await screen.Show();
        }

        public async Task Pop()
        {
            if (_screens.Count == 0)
            {
                return;
            }

            var top = _screens.Pop();

            await top.Hide();

            top.Destroy();

            if (_screens.TryPeek(out var previous))
            {
                await previous.Show();
            }
        }

        public void PopAll()
        {
            while (_screens.Count > 0)
            {
                _screens.Pop().Destroy();
            }
        }
    }
}