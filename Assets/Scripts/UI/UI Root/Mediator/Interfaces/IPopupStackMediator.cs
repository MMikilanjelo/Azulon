using System;
using System.Threading.Tasks;
using UI.Abstractions;
using UI.Abstractions.Interfaces;
using UnityEngine;

namespace UI.UI_Root.Mediator.Interfaces
{
    public interface IPopupStackMediator
    {
        Task Push<T>(Func<Transform, Task<T>> factory) where T : IPopupView;
        Task Pop();
        Task PopAll();
    }
}