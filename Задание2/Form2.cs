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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.NalMat". При необходимости она может быть перемещена или удалена.
            this.nalMatTableAdapter.Fill(this.dataSet1.NalMat);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Sklads". При необходимости она может быть перемещена или удалена.
            this.skladsTableAdapter.Fill(this.dataSet1.Sklads);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Materials". При необходимости она может быть перемещена или удалена.
            this.materialsTableAdapter.Fill(this.dataSet1.Materials);

            dataGridView1.AutoGenerateColumns = true;
        }

        private void btnSklads_Click(object sender, EventArgs e)
        {
            if (lblTableName.Text != "Склады")
            {
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = skladsBindingSource;
                bindingNavigator1.BindingSource = skladsBindingSource;
                lblTableName.Text = "Склады";
            }
        }

        private void btnMaterials_Click(object sender, EventArgs e)
        {
            if (lblTableName.Text != "Материалы")
            {
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = materialsBindingSource;
                bindingNavigator1.BindingSource = materialsBindingSource;
                lblTableName.Text = "Материалы";
            }
        }

        private void btnNalMat_Click(object sender, EventArgs e)
        {
            if (lblTableName.Text != "Нал-е мат-ов на складе")
            {
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = nalMatBindingSource;
                bindingNavigator1.BindingSource = nalMatBindingSource;
                lblTableName.Text = "Нал-е мат-ов на складе";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            tableAdapterManager1.UpdateAll(dataSet1);
            MessageBox.Show("Изменения сохранены");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
