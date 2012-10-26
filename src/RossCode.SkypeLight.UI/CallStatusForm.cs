using System.Windows.Forms;
using RossCode.SkypeLight.Core.Eventing;
using RossCode.SkypeLight.Core.Eventing.Events;
using RossCode.SkypeLight.UI.Properties;

namespace RossCode.SkypeLight.UI
{
    public partial class CallStatusForm : Form
    {
        public CallStatusForm(CallStatus status)
        {
            InitializeComponent();
            SetImagesFor(status);
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            DomainEvents.Register<CallStatusChanged>(changed => SetImagesFor(changed.CallStatus));
        }

        protected override void OnSizeChanged(System.EventArgs e)
        {
            base.OnSizeChanged(e);
            Height = Width;
        }

        private void SetImagesFor(CallStatus status)
        {
            if (status == CallStatus.OnAudioCall)
            {
                Icon = Resources.OnCallStatusIcon;
                pbCallStatus.Image = Resources.OnCallStatusImage;
            }
            else
            {
                Icon = Resources.NoCallStatusIcon;
                pbCallStatus.Image = Resources.NoCallStatusImage;
            }
        }
    }
}
