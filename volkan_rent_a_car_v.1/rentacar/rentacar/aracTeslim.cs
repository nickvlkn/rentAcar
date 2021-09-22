using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//kütüphane ekliyorum
using System.Data.OleDb;
//klasörleme işlemleri için
using System.IO;
using System.Reflection;

namespace rentacar
{
    public partial class aracTeslim : Form
    {
        public aracTeslim()
        {
            InitializeComponent();
        }

        //Veri tabanı yolu ve provier 
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.16.0;Data Source=rentacarverit.accdb");


        private void aracGoster()
        {
            try
            {
                baglantim.Open();
                OleDbDataAdapter kullanicilariListele = new OleDbDataAdapter(
                    "select ka_plaka AS[PALKA], ka_tcno AS[TCNO], ka_ad AS[AD],ka_soyad AS[SOYAD],ka_telefon AS[TELEFON],ka_ehliyet_no AS[EHLİYET NO],ka_marka AS[MARKA],ka_model AS[MODEL],ka_durum AS[DURUM] from kiralanmis_araclar Order By ka_ad ASC", baglantim);
                DataSet dsHafiza = new DataSet();
                //fill dolduruyor
                kullanicilariListele.Fill(dsHafiza);
                dataGridView1.DataSource = dsHafiza.Tables[0];
                baglantim.Close();

            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message, "VOLKAN RANT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglantim.Close();
            }
        }


        //void listele()
        //{
        //    OleDbDataAdapter aracListele = new OleDbDataAdapter(
        //           "select Plaka AS[PALKA],Marka AS[MARKA],Tip AS[TİP],Model AS[MODEL],Renk AS[RENK] from kiralanmis_araclar Order By Plaka ASC", baglantim);
        //    DataSet dsHafiza2 = new DataSet();
        //    //fill dolduruyor
        //    aracListele.Fill(dsHafiza2);
        //    dataGridView1.DataSource = dsHafiza2.Tables[0];
        //    baglantim.Close();
        //}

        private void aracTeslim_Load(object sender, EventArgs e)
        {

            aracGoster();

            //bool kayitAramaDurumu = false;
      
            //    baglantim.Open();
            //    //araclar  tablosundaki tüm alanları seç where tcno alanındaki eşit olanalrı getir 
            //    OleDbCommand selecsorgu = new OleDbCommand("select * from kiralanmis_araclar where ka_durum='kiralandi'", baglantim);
            //    OleDbDataReader kayitOkuma = selecsorgu.ExecuteReader();
            //    while (kayitOkuma.Read())
            //    {
            //        kayitAramaDurumu = true;
            //        //   veri tabanından 1 nolu elemanı alıp stringe dönüştürüp yazdırıyoruz
           

             

            //        //  break;
            //    }
            //    //  eğer yok ise folse ise
            //    if (kayitAramaDurumu == false)
            //    {  //Exclamation bilgi msg box
            //        MessageBox.Show("Araç Kaydı BULUNAMADI !!", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //    }
            //    baglantim.Close();

            
     
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        void teslimAl()
        {
            if (textBox1.Text != "")
            {
                bool kayitAramaDurumu = false;
                baglantim.Open();
                OleDbCommand aramaSorgu = new OleDbCommand("select * from kiralanmis_araclar where ka_plaka='" + textBox1.Text + "'", baglantim);
                OleDbDataReader kayitokuma = aramaSorgu.ExecuteReader();

                



                while (kayitokuma.Read())
                {
                    kayitAramaDurumu = true;
                    OleDbCommand deleteSorgu = new OleDbCommand("delete from kiralanmis_araclar where ka_plaka='" + textBox1.Text + "'", baglantim);
                    deleteSorgu.ExecuteNonQuery();
                    OleDbCommand KiraDurumuEkle = new OleDbCommand("update aracbil set kiraDurumu='bosta' where Plaka='" + textBox1.Text + "'", baglantim);
                    KiraDurumuEkle.ExecuteNonQuery();

                 
                     
                    
                       
                   


                    MessageBox.Show("Araç Teslim Alındı. (BAŞARILI)", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //baglantim.Close();
                    //aracGoster();
                    //aracEkleTemizle();
                    break;

                }

                if (kayitAramaDurumu == false)
                    MessageBox.Show("Silinecek Araç Kaydı Bulunamadı!!", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                baglantim.Close();
                aracGoster();

            }//if

            else
                MessageBox.Show("Silmek istediğiniz kaydın Plakasını doğru girin.!!", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnTeslimAl_Click(object sender, EventArgs e)
        {
            teslimAl();

        }














        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[-1].Value.ToString();
            //}
        }

        private void dataGridView1_ControlAdded(object sender, ControlEventArgs e)
        {
        
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Right) // sağ tuşa basılma
            {
                //int satir = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                //if (satir > -1) //www.yazilimkodlama.com
                //{
                //    dataGridView1.Rows[satir].Selected = true;//bu tıkladığımız alanı seçtiriyoruz
                //    numara = Convert.ToInt32(dataGridView1.Rows[satir].Cells["ka_plaka"].Value);
                //}
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Data Grid View çökyordu başlığa tıklayınca çökmemesi için 
            if (e.RowIndex == -1) return;

            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            baglantim.Open();
            OleDbCommand aramaSorgu = new OleDbCommand("select * from aracbil where Plaka='" + textBox1.Text + "'", baglantim);
            OleDbDataReader kayitOkuma = aramaSorgu.ExecuteReader();
            bool kayitAramaDurumu = false;
            while (kayitOkuma.Read())
            {
                kayitAramaDurumu = true;
                //   veri tabanından 1 nolu elemanı alıp stringe dönüştürüp yazdırıyoruz
                string xx = kayitOkuma.GetValue(0).ToString();
                try
                {

                    pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\aracResimleri\\" + kayitOkuma.GetValue(0).ToString() + ".jpg");
                    //bulnunan kaydın 0. plaka alanını aldık.
                }
                catch
                {
                    MessageBox.Show("Araç resmi Bulunamadı!!", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //resim yok resmini getireymiyorum çalışmıyor 
                    pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\aracResimleri\\resimyok.jpg");
                }
                break;
              
            }
            baglantim.Close();





        }
    }
}
