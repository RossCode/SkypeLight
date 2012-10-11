using System;
using System.Collections.Generic;
using SKYPE4COMLib;

namespace RossCode.SkypeLight.Core
{
    public class SkypeService
    {
        private Action setOnCall;
        private Action setNotOnCall;
        public void Process(Action onCall, Action notOnCall)
        {
            setOnCall = onCall;
            setNotOnCall = notOnCall;

            var skype = new Skype();
            if (!skype.Client.IsRunning)
            {
                skype.Client.Start(false, true);
            }
            skype.Attach(6);
            skype.CallStatus += SkypeOnCallStatus;
        }

        private readonly IList<TCallStatus> onCallStatuses = new List<TCallStatus>
            {
                TCallStatus.clsRinging,
                TCallStatus.clsInProgress
            };

        private void SkypeOnCallStatus(Call call, TCallStatus status)
        {
            if (onCallStatuses.Contains(status))
            {
                setOnCall();
            } 
            else
            {
                setNotOnCall();
            }
        }
    }
}