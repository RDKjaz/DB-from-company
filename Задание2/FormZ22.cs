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
    public partial class FormZ22 : Form
    {
        public FormZ22()
        {
            InitializeComponent();
        }

        public void QueryZ2()
        {
            dataSet1.zadacha2.Clear();
            int kod = -1, kol = 0;
            DataSet1.zadacha2Row zRow = null;
            //строка результирующей таблицы
            foreach (DataSet1.NalMatRow rRow in dataSet1.NalMat.Rows)
            {
                if (rRow.kolvo > Convert.ToInt32(textBox1.Text))
                {
                    if (zRow == null)//если первая запись
                    {
                        kod = rRow.id_material;
                        kol = 1;
                        zRow = dataSet1.zadacha2.Newzadacha2Row();
                    }
                    else if (kod == rRow.id_material) //если тот же товар
                    {
                        kol++;
                    }
                    else //если новый товар
                    {
                        zRow.NAME = dataSet1.Materials.FindByid_material(kod).name;
                        zRow.KOLVO = kol;
                        dataSet1.zadacha2.Rows.Add(zRow);

                        kod = rRow.id_material;//подготовливаем новую строку
                        kol = 1;
                        zRow = dataSet1.zadacha2.Newzadacha2Row();
                    }
                }
            }

            if (zRow != null)//проверяем последний товар
            {
                zRow.NAME = dataSet1.Materials.FindByid_material(kod).name;
                zRow.KOLVO = kol;
                dataSet1.zadacha2.Rows.Add(zRow);
            }
            dataGridView1.Refresh();
        }

        private void btnWork_Click(object sender, EventArgs e)
        {
            this.materialsTableAdapter1.Fill(this.dataSet1.Materials);
            this.nalMatTableAdapter1.Fill(this.dataSet1.NalMat);
            QueryZ2();
        }
    }
}
