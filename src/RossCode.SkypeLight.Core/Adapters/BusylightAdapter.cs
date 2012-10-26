using System;
using BusyLightHIDCommunications;
using System.Timers;

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
        private LinkLampConfiguration.Color currentColor;
        private Timer timer;

        private bool Connect()
        {
            busylight = new UsbDevice(1240, 63560);
            busylight.FindTargetDevice();
            isConnected = true;

            StartTimer(30);

            return busylight.IsDeviceAttached;
        }

        private void StartTimer(int intervalInSeconds)
        {
            timer = new Timer(intervalInSeconds * 1000);
            timer.Elapsed += (sender, args) => ChangeColor();
            timer.Start();
        }

        private void ChangeColor()
        {
            if (!isConnected) { if (!Connect()) return; }
            if (currentColor != null)
            {
                busylight.Light(currentColor);
            }
        }

        private void TurnOff()
        {
            if (!isConnected) { if (!Connect()) return; }
            currentColor = new LinkLampConfiguration.Color
                {
                    Red = 0, 
                    Blue = 0, 
                    Green = 0
                };
            ChangeColor();
        }

        public void TurnGreen()
        {
            if (!isConnected) { if (!Connect()) return; }
            currentColor = new LinkLampConfiguration.Color
                {
                    Red = 0, 
                    Blue = 0, 
                    Green = 255
                };
            ChangeColor();
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
            currentColor = new LinkLampConfiguration.Color
                {
                    Red = 0, 
                    Blue = 255, 
                    Green = 0
                };
            ChangeColor();
        }

        public void TurnRed()
        {
            if (!isConnected) { if (!Connect()) return; }
            currentColor = new LinkLampConfiguration.Color
                {
                    Red = 255, 
                    Blue = 0, 
                    Green = 0
                };
            ChangeColor();
        }

        public void Dispose()
        {
            timer.Stop();
            timer = null;

            if (isConnected)
            {
                TurnOff();
                busylight = null;
            }
            isConnected = false;
        }
    }
}