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
            var callStatus = CallStatus.NotOnCall;
            foreach (var item in skype.ActiveCalls)
            {

                if (item is Call)
                {
                    var call = item as Call;

                    if (call.Status == TCallStatus.clsInProgress && (callStatus != CallStatus.OnVideoCall && callStatus != CallStatus.Ringing ))
                    {
                        callStatus = CallStatus.OnAudioCall;
                        if (call.VideoStatus == TCallVideoStatus.cvsBothEnabled || call.VideoStatus == TCallVideoStatus.cvsReceiveEnabled || call.VideoStatus == TCallVideoStatus.cvsSendEnabled)
                        {
                            callStatus = CallStatus.OnVideoCall;
                        }
                    }
                    if (call.Status == TCallStatus.clsRinging || call.Status == TCallStatus.clsRouting)
                    {
                        callStatus = CallStatus.Ringing;
                        break;
                    }
                }
            }

            DomainEvents.Raise(new CallStatusChanged(callStatus));
        }

    }
}