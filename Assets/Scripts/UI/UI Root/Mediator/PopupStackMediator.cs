using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UI.Abstractions;
using UI.Abstractions.Interfaces;
using UI.UI_Root.Mediator.Interfaces;
using UnityEngine;

namespace UI.UI_Root.Mediator
{
    public class PopupStackMediator : IPopupStackMediator
    {
        private readonly IUIRootMediator _uiRootMediator;
        private readonly Stack<IPopupView> _popups = new();

        public PopupStackMediator(IUIRootMediator uiRootMediator)
        {
            _uiRootMediator = uiRootMediator;
        }

        public async Task Push<T>(Func<Transform, Task<T>> factory) where T : IPopupView
        {
            var popup = await factory.Invoke(_uiRootMediator.UIRoot.OverlayContainer);

            _popups.Push(popup);

            await popup.Show();
        }

        public async Task Pop()
        {
            if (_popups.Count == 0)
            {
                return;
            }

            var top = _popups.Pop();

            await top.Hide();

            top.Destroy();

            if (_popups.TryPeek(out var previous))
            {
                if (!previous.IsShown)
                {
                    await previous.Show();
                }
            }
        }

        public async Task PopAll()
        {
            while (_popups.Count > 0)
            {
                var top = _popups.Pop();
                await top.Hide();
                top.Destroy();
            }
        }
    }
}