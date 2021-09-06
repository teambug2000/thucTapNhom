using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace EXON.GenerateTest.Core.Extensions
{
    public static class ControlExtensions
    {
        public static IEnumerable<Control> All(this ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                foreach (Control grandChild in control.Controls.All())
                    yield return grandChild;

                yield return control;
            }
        }
    }
}