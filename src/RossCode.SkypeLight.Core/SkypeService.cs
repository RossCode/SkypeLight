using System;
using System.Collections.Generic;
using SKYPE4COMLib;

namespace RossCode.SkypeLight.Core
{
    public class SkypeService
    {
        public void Process(Action onCall, Action notOnCall)
        {
            var skype = new Skype();
            if (!skype.Client.IsRunning)
            {
                skype.Client.Start(false, true);
            }
            skype.Attach(6);

            SetCallStatus(onCall, notOnCall, skype);
            skype.CallStatus += (call, status) => SetCallStatus(onCall, notOnCall, skype);
        }

        private static void SetCallStatus(Action onCall, Action notOnCall, Skype skype)
        {
            if (skype.ActiveCalls.Count > 0)
            {
                onCall();
            }
            else
            {
                notOnCall();
            }
        }
    }
}