using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание2
{
    public partial class FormZ21 : Form
    {
        public FormZ21()
        {
            InitializeComponent();
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) >= 0)

                this.zadacha2TableAdapter.Fill(this.dataSet1.zadacha2, Convert.ToInt32(textBox1.Text));
        }
    }
}
