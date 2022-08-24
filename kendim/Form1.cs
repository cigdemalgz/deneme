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

namespace kendim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection bağlantı = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Stok3;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            String t1 = textBox1.Text;//Malzemekodu
            String t2 = textBox2.Text;//malzemeadı
            String t3 = textBox3.Text;//yıllıksatış
            String t4 = textBox4.Text;//birimfiyat
            String t5 = textBox5.Text;//minstok
            String t6 = textBox6.Text;//tsüresi

            bağlantı.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Malzemeler(MalzemeKodu,MalzemeAdı,YıllıkSatış,BirimFiyat,MinStok,TSüresi) VALUES('"+t1+"','"+t2+"','"+t3+"','"+t4+"','"+t5+"','"+t6+"')", bağlantı);
            komut.ExecuteNonQuery();
            bağlantı.Close();
            listele();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }
        private void listele()
        {
            bağlantı.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select*from Malzemeler",bağlantı);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            bağlantı.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            string t1 = textBox1.Text;//seçilen satırın malzeme kodunu al
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM MALZEMELER WHERE MalzemeKodu=('"+t1+"')", bağlantı);
            komut.ExecuteNonQuery();
            bağlantı.Close();
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String t1 = textBox1.Text;//Malzemekodu
            String t2 = textBox2.Text;//malzemeadı
            String t3 = textBox3.Text;//yıllıksatış
            String t4 = textBox4.Text;//birimfiyat
            String t5 = textBox5.Text;//minstok
            String t6 = textBox6.Text;//tsüresi
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("UPDATE Malzemeler SET MalzemeKodu='"+t1+"',MalzemeAdı='"+t2+"',YıllıkSatış='"+t3+"',BirimFiyat='"+t4+"',MinStok='"+t5+"',TSüresi='"+t6+"'WHERE Malzemekodu='"+t1+"'", bağlantı);
            komut.ExecuteNonQuery();
            bağlantı.Close();
            listele();

        }
    }
}
