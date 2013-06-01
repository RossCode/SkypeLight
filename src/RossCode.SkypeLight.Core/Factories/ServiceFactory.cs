using RossCode.SkypeLight.Core.Adapters;

namespace RossCode.SkypeLight.Core.Factories
{
    public static class ServiceFactory
    {
        public static SkypeService GetSkypeService()
        {
            return new SkypeService(new Skype4ComAdapter()); 
        } 
    }
}