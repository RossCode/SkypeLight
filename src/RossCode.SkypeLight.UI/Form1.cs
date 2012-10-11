using System.Drawing;
using System.Windows.Forms;
using RossCode.SkypeLight.Core;

namespace RossCode.SkypeLight.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            var skypeService = new SkypeService();
            skypeService.Process(() => BackColor = Color.Red, () => BackColor = Color.Green);
        }
    }
}
