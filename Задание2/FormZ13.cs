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
    public partial class FormZ13 : Form
    {
        public FormZ13()
        {
            InitializeComponent();
        }

        private void FormZ13_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.zadacha1". При необходимости она может быть перемещена или удалена.
            //this.materialsTableAdapter1.Fill(this.dataSet1.Materials);
            //this.nalMatTableAdapter1.Fill(this.dataSet1.NalMat);
            //Заполним данными таблицы в датасете
            //QueryZapr2();
        }

        private void QueryZapr2()
        {
            dataSet1.zadacha1.Clear();
            //очистим таблицу от предыдущих значений
            foreach (DataSet1.NalMatRow rRow in dataSet1.NalMat.Rows)
                {
                    if (rRow.kolvo < Convert.ToInt32(textBox3.Text))
                    {
                    //Object[] keys = { rRow.id_sklad, rRow.id_material };
                    DataSet1.MaterialsRow tRow = dataSet1.Materials.Rows.Find(rRow.id_material) as DataSet1.MaterialsRow;
                    //Ищем по первичному ключу, получив DataRow приводим к типу
                    // myBaseDataSet.TOVARYRow при помощи оператора as
                    DataSet1.zadacha1Row zRow = dataSet1.zadacha1.Newzadacha1Row();
                    //создали новую строку таблицы «Zadacha1»
                    zRow.name = tRow.name;
                    zRow.id_sklad = rRow.id_sklad;
                    zRow.kolvo = rRow.kolvo;
                    dataSet1.zadacha1.Addzadacha1Row(zRow);
                }
                }
            
            dataGridView1.Refresh();
            this.Text = "Запрос через поиск по ключу";
        }

        private void btnZ3_Click(object sender, EventArgs e)
        {
            this.materialsTableAdapter1.Fill(this.dataSet1.Materials);
            this.nalMatTableAdapter1.Fill(this.dataSet1.NalMat);
            //Заполним данными таблицы в датасете
            QueryZapr2();
        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
