using System;
using System.Collections.Generic;
using Core.State_Machine.States;

namespace Core.State_Machine
{
    public class StackStateMachineBase<T> : IStackStateMachine<T> where T : class, IState
    {
        private readonly Dictionary<Type, T> _states = new();

        private readonly Stack<StateFrame<T>> _history = new();

        private T CurrentState => _history.Count > 0 ? _history.Peek().State : null;

        public void RegisterState(T state)
        {
            if (state == null)
            {
                return;
            }

            _states.TryAdd(state.GetType(), state);
        }

        public void Enter<TState>(StateTransitionBehaviour behaviour) where TState : class, T, IEnterState
        {
            if (CurrentState != null && CurrentState.GetType() == typeof(TState))
            {
                return;
            }

            if (!_states.TryGetValue(typeof(TState), out var nextState))
            {
                return;
            }

            Push(nextState, behaviour);

            if (nextState is IEnterState enterState)
            {
                enterState.Enter();
            }
        }

        public void Enter<TState, TPayload>(TPayload payload, StateTransitionBehaviour behaviour) where TState : class, T, IPayloadState<TPayload>
        {
            if (CurrentState != null && CurrentState.GetType() == typeof(TState))
            {
                return;
            }

            if (!_states.TryGetValue(typeof(TState), out var nextState))
            {
                return;
            }

            Push(nextState, behaviour);

            if (nextState is IPayloadState<TPayload> payloadState)
            {
                payloadState.Enter(payload);
            }
        }

        public void Pop()
        {
            if (_history.Count == 0)
            {
                return;
            }

            var poppedFrame = _history.Pop();

            if (poppedFrame.State is IExitState exitState)
            {
                exitState.Exit();
            }

            if (poppedFrame.Behaviour == StateTransitionBehaviour.Suspend)
            {
                if (CurrentState is ISuspendState resumeState)
                {
                    resumeState.Resume();
                }
            }
        }

        public void ExitStateMachine()
        {
            while (_history.Count > 0)
            {
                var frame = _history.Pop();

                if (frame.State is IExitState exitState)
                {
                    exitState.Exit();
                }
            }
        }

        private void Push(T nextState, StateTransitionBehaviour behaviour)
        {
            if (behaviour == StateTransitionBehaviour.Replace)
            {
                if (_history.Count > 0)
                {
                    var previousFrame = _history.Pop();

                    if (previousFrame.State is IExitState exitState)
                    {
                        exitState.Exit();
                    }
                }
            }
            else if (behaviour == StateTransitionBehaviour.Suspend)
            {
                if (CurrentState is ISuspendState suspendable)
                {
                    suspendable.Suspend();
                }
            }

            _history.Push(new StateFrame<T>(nextState, behaviour));
        }

        private readonly struct StateFrame<TState> where TState : class, IState
        {
            public StateFrame(TState state, StateTransitionBehaviour behaviour)
            {
                State = state;
                Behaviour = behaviour;
            }

            public TState State { get; }
            public StateTransitionBehaviour Behaviour { get; }
        }
    }
}