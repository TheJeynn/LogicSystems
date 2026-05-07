using LogicSystems.Business;
using LogicSystems.Business.States;
using Xunit;

namespace LogicSystems.Tests
{
    public class StateTests
    {
        [Fact]
        public void Order_ShouldStartWithPendingState()
        {
            var order = new OrderContext(new PendingState());

            Assert.IsType<PendingState>(order.State);
        }

        [Fact]
        public void Order_ShouldTransitionToApprovedState()
        {
            var order = new OrderContext(new PendingState());

            order.Next();

            Assert.IsType<ApprovedState>(order.State);
        }

        [Fact]
        public void Order_ShouldTransitionToShippedState()
        {
            var order = new OrderContext(new PendingState());

            order.Next();
            order.Next();

            Assert.IsType<ShippedState>(order.State);
        }

        [Fact]
        public void Order_ShouldTransitionToDeliveredState()
        {
            var order = new OrderContext(new PendingState());

            order.Next();
            order.Next();
            order.Next();

            Assert.IsType<DeliveredState>(order.State);
        }
    }
}