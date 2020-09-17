using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void materialsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.materialsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Sklads". При необходимости она может быть перемещена или удалена.
            this.skladsTableAdapter.Fill(this.dataSet1.Sklads);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Sklads". При необходимости она может быть перемещена или удалена.
            this.skladsTableAdapter.Fill(this.dataSet1.Sklads);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Sklads". При необходимости она может быть перемещена или удалена.
            this.skladsTableAdapter.Fill(this.dataSet1.Sklads);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Sklads". При необходимости она может быть перемещена или удалена.
            this.skladsTableAdapter.Fill(this.dataSet1.Sklads);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Sklads". При необходимости она может быть перемещена или удалена.
            this.skladsTableAdapter.Fill(this.dataSet1.Sklads);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Sklads". При необходимости она может быть перемещена или удалена.
            this.skladsTableAdapter.Fill(this.dataSet1.Sklads);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Materials". При необходимости она может быть перемещена или удалена.
            this.materialsTableAdapter.Fill(this.dataSet1.Materials);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.NalMat". При необходимости она может быть перемещена или удалена.
            this.nalMatTableAdapter.Fill(this.dataSet1.NalMat);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Sklads". При необходимости она может быть перемещена или удалена.
            this.skladsTableAdapter.Fill(this.dataSet1.Sklads);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Sklads". При необходимости она может быть перемещена или удалена.
            this.skladsTableAdapter.Fill(this.dataSet1.Sklads);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.NalMat". При необходимости она может быть перемещена или удалена.
            this.nalMatTableAdapter.Fill(this.dataSet1.NalMat);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Materials". При необходимости она может быть перемещена или удалена.
            this.materialsTableAdapter.Fill(this.dataSet1.Materials);

        }

        private void materialsDataGridView_Click(object sender, EventArgs e)
        {
            bindingNavigator.BindingSource = materialsBindingSource;
            lblTable.Text = "Материалы";
            this.materialsDataGridView.DataSource = materialsBindingSource;
        }

        private void skladsDataGridView_Click(object sender, EventArgs e)
        {
            bindingNavigator.BindingSource = skladsBindingSource;
            lblTable.Text = "Склады";
            this.skladsDataGridView.DataSource = skladsBindingSource;
        }

        private void nalMatDataGridView_Click(object sender, EventArgs e)
        {
            nalMatDataGridView.DataSource = nalMatBindingSource;
            this.skladsDataGridView.DataSource = NalMat_SkladsbindingSource;
            this.materialsDataGridView.DataSource = NalMat_MaterialsbindingSource;
            lblTable.Text = "Наличие материалов на складе";
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            int nRow = nalMatDataGridView.CurrentCell.RowIndex;
            int nCol = nalMatDataGridView.CurrentCell.ColumnIndex;
            if (nRow > 0)
                nalMatDataGridView.CurrentCell = nalMatDataGridView[nCol,
                --nRow];
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int nRow = nalMatDataGridView.CurrentCell.RowIndex;
            int nCol = nalMatDataGridView.CurrentCell.ColumnIndex;
            
            if (nRow < nalMatDataGridView.RowCount - 2)
                nalMatDataGridView.CurrentCell = nalMatDataGridView[nCol,
                ++nRow];
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            int nCol = nalMatDataGridView.CurrentCell.ColumnIndex;
            nalMatDataGridView.CurrentCell = nalMatDataGridView[nCol, 0];
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int nCol = nalMatDataGridView.CurrentCell.ColumnIndex;
            nalMatDataGridView.CurrentCell = nalMatDataGridView[nCol, nalMatDataGridView.RowCount - 2];
        }

        private void nalMatDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (nalMatDataGridView.CurrentCell != null)
            { //если существует выбранная ячейка


                int nRow = nalMatDataGridView.CurrentCell.RowIndex;
                //первая строка
                if (nRow == 0)
                {
                    btnPrev.Enabled = false;
                    btnFirst.Enabled = false;
                }
                else
                {
                    btnPrev.Enabled = true;
                    btnFirst.Enabled = true;
                }
                //последняя строка
                if (nRow == nalMatDataGridView.RowCount - 1)
                {
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
                else
                {
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //сохранение данных
            this.nalMatTableAdapter.Update(this.dataSet1.NalMat);
            //обновление данных из источника
            this.nalMatTableAdapter.Fill(this.dataSet1.NalMat);
            //обновление состояния навигатора
            this.nalMatDataGridView_CurrentCellChanged(nalMatDataGridView, e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //обновление данных из источника
            this.nalMatTableAdapter.Fill(dataSet1.NalMat);
            //обновление состояния навигатора
            this.nalMatDataGridView_CurrentCellChanged(nalMatDataGridView, e);
        }

        private void альтернативнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void btnSProc_Click(object sender, EventArgs e)
        {
            try
            {
                String material = materialsDataGridView.CurrentRow.Cells["dataGridViewTextBoxColumn2"].Value.ToString();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Properties.Settings.Default.Sem_1ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EndPrice";
                SqlParameter param = new SqlParameter("@End_Price", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.Parameters.Add(new SqlParameter("@name", material));
                con.Open();
                cmd.ExecuteScalar();
                string kolvo = cmd.Parameters["@End_Price"].Value.ToString();
                con.Close();
                lblKolvo.Text = " Цена " + material + ": " + kolvo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void вариант1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormZ1 f2 = new FormZ1();
            f2.Show();
        }

        private void вариант2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormZ12 f2 = new FormZ12();
            f2.Show();
        }

        private void вариант3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormZ13 f2 = new FormZ13();
            f2.Show();
        }

        private void вариант4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormZ14 f2 = new FormZ14();
            f2.Show();
        }

        private void вариант5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormZ15 f2 = new FormZ15();
            f2.Show();
        }

        private void новаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void recToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormZ22 f22 = new FormZ22();
            f22.Show();
        }

        private void sQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormZ21 f21 = new FormZ21();
            f21.Show();
        }
    }
}
