using Application.State_Machine.Global_State_Machine;
using Application.State_Machine.Global_State_Machine.States.BootState;
using UnityEngine;

namespace Application
{
    public class Bootstrapper : MonoBehaviour
    {
        public void Start()
        {
            var stateMachine = new GlobalStateMachine();
            
            stateMachine.Enter<BootState>();
        }
    }
}