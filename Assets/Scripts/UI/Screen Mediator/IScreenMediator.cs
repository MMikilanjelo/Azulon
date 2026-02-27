using System.Threading.Tasks;
using UnityEngine;

namespace UI.Screen_Mediator
{
    public interface IScreenMediator
    {
        Transform ScreenRoot { get; }
        Task Initialize();
    }
}