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
    public partial class FormZ1 : Form
    {
        public FormZ1()
        {
            InitializeComponent();
        }

        private void FormZ1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.zadacha1". При необходимости она может быть перемещена или удалена.
            dataGridView1.AutoGenerateColumns = true;
            this.zadacha1TableAdapter.Fill(this.dataSet1.zadacha1, 0);
            this.Text = "Запрос на основании объекта TableAdapter";

        }

        private void btnZ1_Click(object sender, EventArgs e)
        {
            int kolvo = Convert.ToInt32(textBox1.Text);
            this.zadacha1TableAdapter.Fill(this.dataSet1.zadacha1, kolvo);
        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
