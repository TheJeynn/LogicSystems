using System;

namespace LogicSystems.Business.States
{
    public class OrderContext
    {
        private IOrderState currentState;

        public OrderContext(IOrderState initialState)
        {
            currentState = initialState ?? throw new ArgumentNullException(nameof(initialState));
        }

        public IOrderState State
        {
            get => currentState;
            set => SetState(value);
        }

        public void SetState(IOrderState state)
        {
            currentState = state ?? throw new ArgumentNullException(nameof(state));
        }

        public void Next()
        {
            currentState.Next(this);
        }

        public void Cancel()
        {
            currentState.Cancel(this);
        }

        public string GetStateName()
        {
            return currentState?.GetType().Name ?? string.Empty;
        }
    }
}