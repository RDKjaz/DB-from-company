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
    public partial class FormZ12 : Form
    {
        public FormZ12()
        {
            InitializeComponent();
        }

        private void FormZ12_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.zadacha1". При необходимости она может быть перемещена или удалена.
            //this.zadacha1TableAdapter.Fill(this.dataSet1.zadacha1);
            //this.materialsTableAdapter1.Fill(this.dataSet1.Materials);
            //this.nalMatTableAdapter1.Fill(this.dataSet1.NalMat);
            //Заполним данными таблицы в датасете
            //QueryZapr1();

        }

        public void QueryZapr1()
        {
            dataSet1.zadacha1.Clear();
            //очистим таблицу от предыдущих значений
            foreach (DataSet1.NalMatRow rRow in dataSet1.NalMat.Rows)

            { 
                if (rRow.kolvo < Convert.ToInt32(textBox2.Text))
                { //проверка выполнения условия на количество
                    foreach (DataSet1.MaterialsRow tRow in dataSet1.Materials.Rows)
                    { //второй цикл по строкам таблицы «Товары»
                        if (rRow.id_material == tRow.id_material)
                        { //нашли нужный товар

                            DataSet1.zadacha1Row zRow = dataSet1.zadacha1.Newzadacha1Row();
                            //создали новую строку таблицы «Zadacha1»
                            zRow.name = tRow.name;
                            zRow.id_sklad = rRow.id_sklad;
                            zRow.kolvo = rRow.kolvo;
                            dataSet1.zadacha1.Addzadacha1Row(zRow);
                            //добавили строку в результирующую таблицу
                        }
                    }
                }
            }

            dataGridView1.Refresh();
            this.Text = "Запрос через двойной цикл";
            //редактирование заголовка формы
        }

        private void btnZ2_Click(object sender, EventArgs e)
        {
            this.materialsTableAdapter1.Fill(this.dataSet1.Materials);
            this.nalMatTableAdapter1.Fill(this.dataSet1.NalMat);
            //Заполним данными таблицы в датасете
            QueryZapr1();
        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

