using RossCode.SkypeLight.Core.Eventing;
using RossCode.SkypeLight.Core.Eventing.Events;
using SKYPE4COMLib;

namespace RossCode.SkypeLight.Core.Adapters
{
    public interface ISkypeAdapter
    {
        void BeginMonitoring();
    }

    public class Skype4ComAdapter : ISkypeAdapter
    {
        private readonly Skype skype;

        public Skype4ComAdapter()
        {
            skype = new Skype();
        }

        public void BeginMonitoring()
        {
            if (!skype.Client.IsRunning)
            {
                skype.Client.Start(false, true);
            }
            skype.Attach(6);

            SetCallStatus();
            skype.CallStatus += (call, status) => SetCallStatus();
        }

        private void SetCallStatus()
        {
            DomainEvents.Raise(new CallStatusChanged(skype.ActiveCalls.Count > 0 ? CallStatus.OnCall : CallStatus.NotOnCall));
        }

    }
}