using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Controls;
using static System.Windows.Forms.Control;
using System.Windows.Forms;

namespace EXON.GenerateTest.Core.Common
{
    class ValidateField
    {
        public static bool ValidateTextBox(ControlCollection controls)
        {
            List<Control> listControl = new List<Control>();
            foreach (Control c in controls)
                listControl.Add(c);
            List<Control> listLabes = listControl
                .Where(x => x.GetType() == typeof(Label) || x.GetType() == typeof(MetroLabel))
                .OrderBy(x => x.Location.Y)
                .ToList();

            List<Control> listTextboxs = listControl
                .Where(x => x.GetType() == typeof(TextBox) || x.GetType() == typeof(MetroTextBox))
                .OrderBy(x => x.Location.Y)
                .ToList();

            if (listTextboxs.Count() > listLabes.Count())
                throw new NotSupportedException();

            string message = "";
            for (int i = 0; i < listTextboxs.Count(); i++)
            {
                if (listTextboxs[i].Tag != null && listTextboxs[i].Tag.ToString() == "*")
                {
                    if (listTextboxs[i].Location.Y - listLabes[i].Location.Y < 10 &&
                        listTextboxs[i].Location.X - listLabes[i].Location.X < 150)
                    {
                        if (string.IsNullOrEmpty(listTextboxs[i].Text))
                        {
                            message += "Vui Lòng Nhập " + listLabes[i].Text + "\n";
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, Properties.Resources.WarningDialog,
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Warning);
                return false;
            }
            else return true;
        }

    }
}
