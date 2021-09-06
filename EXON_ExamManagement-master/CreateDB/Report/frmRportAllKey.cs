using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateDB.Report
{
    public partial class frmRportAllKey : Form
    {
        private int id;

        public frmRportAllKey(int idlocation)
        {
            InitializeComponent();
            id = idlocation;
        }

        private void frmRportAllKey_Load(object sender, EventArgs e)
        {
            this.DataTable1TableAdapter.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["EXON_DbContext"].ConnectionString;
            // TODO: This line of code loads data into the 'DataSetDVKey.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.datasetDivisionShiftKey.DataTable1, id);

            this.reportViewer1.RefreshReport();
        }
    }
}