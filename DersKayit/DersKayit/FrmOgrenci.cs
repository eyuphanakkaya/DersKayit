using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DersKayit
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-PHRFHT3;Initial Catalog=DersKayit;Integrated Security=True");
        DataSet1TableAdapters.DataTable1TableAdapter Dt=new DataSet1TableAdapters.DataTable1TableAdapter();
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Dt.GetData2();
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select * from Kulup",sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBoxKulup.DisplayMember="KulupAd";
            comboBoxKulup.ValueMember = "KulupId";
            comboBoxKulup.DataSource = dataTable;
            sqlConnection.Close();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Dt.GetData2();
            txtAd.Text = "";
            textBoxSoyad.Text = "";
            comboBoxKulup.Text = "";
            radioButtonErkek.Checked=false;
            radioButtonKadın.Checked = false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string Cinsiyet="";
            if (radioButtonErkek.Checked==true)
            {
                Cinsiyet = "Erkek";
            }
            if (radioButtonKadın.Checked==true)
            {
                Cinsiyet = "Kız";
            }
            Dt.InsertOgrenci(txtAd.Text,textBoxSoyad.Text,int.Parse(comboBoxKulup.SelectedValue.ToString()),Cinsiyet);
            MessageBox.Show("Öğrenci Eklendi.");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string Cinsiyet="";
            if (radioButtonKadın.Checked==true)
            {
                Cinsiyet = "Kız";
            }
            else if (radioButtonErkek.Checked==true)
            {
                Cinsiyet = "Erkek";
            }
            Dt.OgrGuncelle(txtAd.Text,textBoxSoyad.Text,Cinsiyet,int.Parse(comboBoxKulup.SelectedValue.ToString()),int.Parse(txtId.Text));
            MessageBox.Show("Öğrenci Bilgileri Güncellendi");

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Dt.DeleteOgrenci(int.Parse(txtId.Text));
            MessageBox.Show("Öğrenci Silindi.");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBoxKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource=Dt.OgrAra(textBoxAra.Text);
        }
    }
}
