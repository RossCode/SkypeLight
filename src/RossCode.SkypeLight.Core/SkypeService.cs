using RossCode.SkypeLight.Core.Adapters;

namespace RossCode.SkypeLight.Core
{
    public class SkypeService
    {
        private readonly ISkypeAdapter skype;

        public SkypeService(ISkypeAdapter skype)
        {
            this.skype = skype;
        }

        public void Process()
        {
            skype.BeginMonitoring();
        }
    }
}