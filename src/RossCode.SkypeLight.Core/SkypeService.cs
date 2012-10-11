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

            if (skype.ActiveCalls.Count > 0)
            {
                onCall();
            }
            else
            {
                notOnCall();
            }
            skype.CallStatus += (call, status) =>
                {
                    if (skype.ActiveCalls.Count > 0)
                    {
                        onCall();
                    }
                    else
                    {
                        notOnCall();
                    }
                };
        }
    }
}