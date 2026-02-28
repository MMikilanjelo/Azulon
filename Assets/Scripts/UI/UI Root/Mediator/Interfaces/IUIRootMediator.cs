using System.Threading.Tasks;
using UnityEngine;

namespace UI.UI_Root.Mediator.Interfaces
{
    public interface IUIRootMediator
    {
        Transform UIRoot { get; }
        Task Initialize();
    }
}