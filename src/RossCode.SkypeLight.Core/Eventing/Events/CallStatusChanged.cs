namespace RossCode.SkypeLight.Core.Eventing.Events
{
    public enum CallStatus
    {
        OnCall,
        NotOnCall
    }
    
    public class CallStatusChanged
    {
        public CallStatus CallStatus { get; private set; }

        public CallStatusChanged(CallStatus callStatus)
        {
            CallStatus = callStatus;
        }
    }
}