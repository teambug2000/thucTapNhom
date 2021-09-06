using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using EXON.Common;

namespace EXON.GenerateTest.Core.Forms
{
    public partial class BaseForm : MetroForm
    {
        protected ActionFormResult ActionForm = ActionFormResult.Not;
        public bool IsShow { get; set; }

        public virtual ActionFormResult GetActionStatus()
        {
            return ActionForm;
        }
    }
}
