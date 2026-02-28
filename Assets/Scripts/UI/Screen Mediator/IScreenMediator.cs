using System;
using System.Threading.Tasks;
using UI.Abstractions.Interfaces;
using UnityEngine;

namespace UI.Screen_Mediator
{
    public interface IScreenMediator
    {
        Transform ScreenRoot { get; }
        Task Initialize();
        Task<T> Push<T>(Func<Transform, Task<T>> factory) where T : IScreenViewModel;
        void Pop();
    }
}