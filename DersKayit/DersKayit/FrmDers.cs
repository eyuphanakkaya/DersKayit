using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DersKayit
{
    public partial class FrmDers : Form
    {
        public FrmDers()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.DerslerTableAdapter Dt = new DataSet1TableAdapters.DerslerTableAdapter();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Dt.GetData();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Dt.GetData();
            txtAd.Text = "";
            txtId.Text = "";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Dt.InsertDers(txtAd.Text);
            MessageBox.Show("Ders Eklendi.");
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Dt.DeleteDers(int.Parse(txtAd.Text));
            MessageBox.Show("Ders Silindi.");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Dt.UpdateDers(txtAd.Text,int.Parse(txtId.Text));
            MessageBox.Show("Ders Güncellendi.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmOgrenci frmOgrenci = new FrmOgrenci();
            frmOgrenci.Show();
            this.Hide();
        }
    }
}
