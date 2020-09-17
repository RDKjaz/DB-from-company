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
    public partial class FormZ14 : Form
    {
        public FormZ14()
        {
            InitializeComponent();
        }

        private void FormZ14_Load(object sender, EventArgs e)
        {
            //this.materialsTableAdapter1.Fill(this.dataSet1.Materials);
            //this.nalMatTableAdapter1.Fill(this.dataSet1.NalMat);
            //Заполним данными таблицы в датасете
            //QueryZapr3();
        }

        private void QueryZapr3()
        {
            dataSet1.zadacha1.Clear();
            //очистим таблицу от предыдущих значений
            foreach (DataSet1.NalMatRow rRow in dataSet1.NalMat.Rows)


            {
                if (rRow.kolvo < Convert.ToInt32(textBox4.Text))
                {
                    DataSet1.MaterialsRow tRow = rRow.GetParentRow("fk_nal_material") as DataSet1.MaterialsRow;
                    // Получили строку из родительской таблицы, связанной с таблицей
                    // RASXOD связью с именем TOV_RASH и привели к типу
                    DataSet1.zadacha1Row zRow = dataSet1.zadacha1.Newzadacha1Row();
                    //создали новую строку таблицы «Zadacha1»
                    zRow.name = tRow.name;
                    zRow.id_sklad = rRow.id_sklad;
                    zRow.kolvo = rRow.kolvo;
                    dataSet1.zadacha1.Addzadacha1Row(zRow);
                }
            }

            dataGridView1.Refresh();
            this.Text = "Запрос через DataRelation";
        }

        private void btnZ4_Click(object sender, EventArgs e)
        {
            this.materialsTableAdapter1.Fill(this.dataSet1.Materials);
            this.nalMatTableAdapter1.Fill(this.dataSet1.NalMat);
            //Заполним данными таблицы в датасете
            QueryZapr3();
        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
