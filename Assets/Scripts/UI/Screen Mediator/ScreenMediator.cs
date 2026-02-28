using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Factory_Provider;
using Infrastructure.Factory_Provider.Factories;
using Infrastructure.Factory_Provider.Factories.UI_Root_Factory;
using UI.Abstractions.Interfaces;
using UnityEngine;

namespace UI.Screen_Mediator
{
    public class ScreenMediator : IScreenMediator
    {
        public Transform ScreenRoot => _uiRootView.transform;

        private readonly IFactoryProvider _factoryProvider;

        private UIRootView _uiRootView;

        private readonly Stack<IScreenViewModel> _screens = new();

        public ScreenMediator(IFactoryProvider factoryProvider)
        {
            _factoryProvider = factoryProvider;
        }

        public async Task Initialize()
        {
            var factory = _factoryProvider.GetFactoryById<IUIRootFactory>(FactoryId.UIRoot);

            _uiRootView = await factory.CreateUIRoot();
        }

        public async Task<T> Push<T>(Func<Transform, Task<T>> factory) where T : IScreenViewModel
        {
            if (_screens.TryPeek(out var current))
            {
                current.Hide();
            }

            var screen = await factory.Invoke(ScreenRoot);

            _screens.Push(screen);

            screen.Show();

            return screen;
        }

        public void Pop()
        {
            if (_screens.Count == 0)
            {
                return;
            }

            var top = _screens.Pop();

            top.Hide();

            if (_screens.TryPeek(out var previous))
            {
                previous.Show();
            }
        }
    }
}