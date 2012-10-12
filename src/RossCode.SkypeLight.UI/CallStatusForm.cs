using System.Drawing;
using System.Windows.Forms;
using RossCode.SkypeLight.Core.Eventing;
using RossCode.SkypeLight.Core.Eventing.Events;

namespace RossCode.SkypeLight.UI
{
    public partial class CallStatusForm : Form
    {
        public CallStatusForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            DomainEvents.Register<CallStatusChanged>(changed => BackColor = changed.CallStatus == CallStatus.OnCall ? Color.Red : Color.Green);
        }
    }
}
