using EXONSYSTEM.Common;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXONSYSTEM.Layout
{
	public partial class frmWaiting : MetroForm
	{
		public frmWaiting()
		{
			InitializeComponent();
		}
		public void HandleWorking(string data)
		{
			fpnlLabel.Controls[data].ForeColor = Constant.FORECECOLOR_LABEL_OK;
		}
		public void HandleLoadingControl(List<Label> lstControl)
		{
			foreach (Label lb in lstControl)
			{
				lb.Width = fpnlLabel.Width;
				fpnlLabel.Controls.Add(lb);
			}
		}

		private void frmWaiting_Load(object sender, EventArgs e)
		{
			mpsWaiting.Location = new Point((this.Width - mpsWaiting.Width) / 2, 15);
		}
	}
}
