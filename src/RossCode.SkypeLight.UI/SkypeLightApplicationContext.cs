using System.Windows.Forms;
using RossCode.SkypeLight.Core.Factories;

namespace RossCode.SkypeLight.UI
{
    public class SkypeLightApplicationContext : ApplicationContext
    {
        public SkypeLightApplicationContext()
        {
            InitializeCallIndicators();
            InitializeCallMonitors();
        }

        private void InitializeCallMonitors()
        {
            var skypeService = ServiceFactory.GetSkypeService();
            skypeService.Process();
        }

        private void InitializeCallIndicators()
        {
            var form = new CallStatusForm();
            form.Show();
        }
    }
}