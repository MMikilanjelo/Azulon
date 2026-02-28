using System;
using System.Threading.Tasks;
using UI.Abstractions;
using UnityEngine;

namespace UI.UI_Root.Mediator.Interfaces
{
    public interface IScreenStackMediator
    {
        Task Push<T>(Func<Transform, Task<T>> factory) where T : IScreenView;
        Task Pop();
        void PopAll();
    }
}