using System;
using BusyLightHIDCommunications;

namespace RossCode.SkypeLight.Core.Adapters
{
    public interface IBusylightAdapter : IDisposable
    {
        void TurnGreen();
        void TurnBlue();
        void TurnRed();
        void TurnYellow();
    }

    public class BusylightAdapter : IBusylightAdapter
    {
        private UsbDevice busylight;
        private bool isConnected;

        private bool Connect()
        {
            busylight = new UsbDevice(1240, 63560);
            busylight.FindTargetDevice();
            isConnected = true;
            return busylight.IsDeviceAttached;
        }

        private void TurnOff()
        {
            if (!isConnected) { if (!Connect()) return;
            }
            var color = new LinkLampConfiguration.Color
                {
                    Red = 0, 
                    Blue = 0, 
                    Green = 0
                };
            busylight.Light(color);
        }

        public void TurnGreen()
        {
            if (!isConnected) { if (!Connect()) return; }
            var color = new LinkLampConfiguration.Color
                {
                    Red = 0, 
                    Blue = 0, 
                    Green = 255
                };
            busylight.Light(color);
        }

        public void TurnYellow()
        {
            if (!isConnected) { if (!Connect()) return; }
            var color = new LinkLampConfiguration.Color
                {
                    Red = 255, 
                    Blue = 0, 
                    Green = 255
                };
            busylight.Light(color);
        }

        public void TurnBlue()
        {
            if (!isConnected) { if (!Connect()) return; }
            var color = new LinkLampConfiguration.Color
                {
                    Red = 0, 
                    Blue = 255, 
                    Green = 0
                };
            busylight.Light(color);
        }

        public void TurnRed()
        {
            if (!isConnected) { if (!Connect()) return; }
            var color = new LinkLampConfiguration.Color
                {
                    Red = 255, 
                    Blue = 0, 
                    Green = 0
                };
            busylight.Light(color);
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