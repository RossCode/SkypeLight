using System;
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

        private void Connect()
        {
            if (isConnected) return;
            busylight = new BusylightController(1240, 63560);
            isConnected = true;
        }

        private void ChangeColor()
        {
            Connect();
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
            if (isConnected)
            {
                TurnOff();
                busylight = null;
            }
            isConnected = false;
        }
    }
}