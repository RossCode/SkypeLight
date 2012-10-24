using System;
using BusyLightHIDCommunications;

namespace RossCode.SkypeLight.Core.Adapters
{
    public interface IBusylightAdapter : IDisposable
    {
        bool TurnOff();
        bool TurnGreen();
        bool TurnBlue();
        bool TurnRed();
    }

    public class BusylightAdapter : IBusylightAdapter
    {
        private UsbDevice busylight;
        private bool isConnected = false;

        private bool Connect()
        {
            busylight = new UsbDevice(1240, 63560);
            busylight.FindTargetDevice();
            isConnected = true;
            return busylight.IsDeviceAttached;
        }

        public bool TurnOff()
        {
            if (!isConnected) Connect();
            var color = new LinkLampConfiguration.Color
                {
                    Red = 0, 
                    Blue = 0, 
                    Green = 0
                };
            return busylight.Light(color);
        }

        public bool TurnGreen()
        {
            if (!isConnected) Connect();
            var color = new LinkLampConfiguration.Color
                {
                    Red = 0, 
                    Blue = 0, 
                    Green = 255
                };
            return busylight.Light(color);
        }

        public bool TurnBlue()
        {
            if (!isConnected) Connect();
            var color = new LinkLampConfiguration.Color
                {
                    Red = 0, 
                    Blue = 255, 
                    Green = 0
                };
            return busylight.Light(color);
        }

        public bool TurnRed()
        {
            if (!isConnected) Connect();
            var color = new LinkLampConfiguration.Color
                {
                    Red = 255, 
                    Blue = 0, 
                    Green = 0
                };
            return busylight.Light(color);
        }

        public void Dispose()
        {
            if (isConnected)
            {
                TurnOff();
                busylight = null;
            }
            isConnected = false;
        }
    }
}