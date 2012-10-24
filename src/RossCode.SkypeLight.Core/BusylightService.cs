using System;
using RossCode.SkypeLight.Core.Adapters;
using RossCode.SkypeLight.Core.Eventing;
using RossCode.SkypeLight.Core.Eventing.Events;

namespace RossCode.SkypeLight.Core
{
    public class BusylightService : IDisposable
    {
        private readonly IBusylightAdapter busylightAdapter;

        public BusylightService(IBusylightAdapter busylightAdapter)
        {
            this.busylightAdapter = busylightAdapter;
        }

        public void Initialize()
        {
            DomainEvents.Register<CallStatusChanged>(CallStatusChanged);
            busylightAdapter.TurnBlue();
        }

        private void CallStatusChanged(CallStatusChanged args)
        {
            if (args.CallStatus == CallStatus.OnCall)
            {
                busylightAdapter.TurnRed();
            }
            else
            {
                busylightAdapter.TurnGreen();
            }
        }

        public void Dispose()
        {
            busylightAdapter.Dispose();
        }
    }
}