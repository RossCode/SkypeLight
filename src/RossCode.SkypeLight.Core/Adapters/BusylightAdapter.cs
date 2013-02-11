using System;
using System.Timers;
using Plenom.Components.Busylight.Sdk;

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
        private BusylightController busylight;
        private bool isConnected;
        private BusylightColor currentColor;
        private Timer timer;

        private bool Connect()
        {
            busylight = new BusylightController(1240, 63560);
            isConnected = true;

            StartTimer(25);

            return true;
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
            currentColor = new BusylightColor
                {
                    RedRgbValue = 0, 
                    BlueRgbValue = 0, 
                    GreenRgbValue = 0
                };
            ChangeColor();
        }

        public void TurnGreen()
        {
            currentColor = BusylightColor.Green;
            ChangeColor();
        }

        public void TurnYellow()
        {
            currentColor = BusylightColor.Yellow;
            ChangeColor();
        }

        public void TurnBlue()
        {
            currentColor = BusylightColor.Blue;
            ChangeColor();
        }

        public void TurnRed()
        {
            currentColor = BusylightColor.Red;
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