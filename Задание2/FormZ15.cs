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
    public partial class FormZ15 : Form
    {
        public FormZ15()
        {
            InitializeComponent();
        }

        private void FormZ15_Load(object sender, EventArgs e)
        {
            //dataGridView1.AutoGenerateColumns = true;
            //FillGridByReader();
        }

        private void FillGridByReader()
        {
            int k = Convert.ToInt32(textBox5.Text);
            SqlConnection con = new SqlConnection(Properties.Settings.Default.Sem_1ConnectionString);
            // создаем объект связь с бд, строку соединения берём из
            // свойств проекта, можно задать самим строкой
            con.Open();
            // подключаемся к бд
            String str = "SELECT Materials.name, NalMat.id_sklad, NalMat.kolvo FROM Materials, NalMat WHERE Materials.id_material = NalMat.id_material and NalMat.kolvo < " + k.ToString();
            // задаем текст запроса, добавляем текст из txtKolvo
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            // создали команду и выполнили метод ExecuteReader

            DataTable dt = new DataTable();
            dt.Load(rdr);
            con.Close();
            // при помощи ридера заполнили таблицу и закрыли
            // соединение с бд

            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            
            // программно создали объект BindingSource и связали
            // его с таблицей, далее грид и навигатор укажем на
            // него для связи с таблицей

            dataGridView1.DataSource = bs;
            bindingNavigator1.BindingSource = bs;
            dataGridView1.Refresh();
        }

        

        private void btnCls_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            FillGridByReader();
        }
    }
}
