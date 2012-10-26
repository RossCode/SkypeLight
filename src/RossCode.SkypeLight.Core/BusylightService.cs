using System;
using System.Collections.Generic;
using RossCode.SkypeLight.Core.Adapters;
using RossCode.SkypeLight.Core.Eventing;
using RossCode.SkypeLight.Core.Eventing.Events;

namespace RossCode.SkypeLight.Core
{
    public class BusylightService : IDisposable
    {
        private readonly IBusylightAdapter busylightAdapter;
        private IDictionary<CallStatus, Action<IBusylightAdapter>> setBusylightStatus = new Dictionary<CallStatus, Action<IBusylightAdapter>>
            {
                { CallStatus.NotOnCall, adapter => adapter.TurnGreen() },
                { CallStatus.Ringing, adapter => adapter.TurnYellow() },
                { CallStatus.OnAudioCall, adapter => adapter.TurnRed() },
                { CallStatus.OnVideoCall, adapter => adapter.TurnRed() }
            };

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
            setBusylightStatus[args.CallStatus](busylightAdapter);
        }

        public void Dispose()
        {
            busylightAdapter.Dispose();
        }
    }
}