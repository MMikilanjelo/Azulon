using System.Threading.Tasks;
using UI.UI_Root.View;
using UnityEngine;

namespace UI.UI_Root.Mediator.Interfaces
{
    public interface IUIRootMediator
    {
        UIRootView UIRoot { get; }
        Task Initialize();
    }
}