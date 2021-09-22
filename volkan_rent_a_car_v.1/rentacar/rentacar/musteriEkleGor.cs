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


namespace rentacar
{
    public partial class musteri : Form
    {
        public musteri()
        {
            InitializeComponent();
        }
        string yoldb = Environment.CurrentDirectory.ToString();
 
        //Veri tabanı yolu ve provier 
         OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.16.0;Data Source=rentacarverit.accdb");
        //
        //LOAD 
        //
        private void Form1_Load(object sender, EventArgs e)
        {
            masktxtAd.Mask = "LL????????????????????";
            masktxtSoyad.Mask = "LL????????????????????";

            musteriGoster();
            //cisiyeti seçili getiridk 
            comboBoCinsiyet.SelectedIndex = 0;

            DateTime zaman = DateTime.Now;
            int yil = int.Parse(zaman.ToString("yyyy"));
            int ay = int.Parse(zaman.ToString("MM"));
            int gun = int.Parse(zaman.ToString("dd"));

            dateTimePicker1.MinDate = new DateTime(1960, 1, 1);
            dateTimePicker1.MaxDate = new DateTime(yil - 20, ay, gun);
            dateTimePicker1.Format = DateTimePickerFormat.Short;


            DateTime zaman2 = DateTime.Now;
            int yil2 = int.Parse(zaman.ToString("yyyy"));
            int ay2 = int.Parse(zaman.ToString("MM"));
            int gun2 = int.Parse(zaman.ToString("dd"));

            dateTimeEhliyetTarih.MinDate = new DateTime(1960, 1, 1);
            dateTimeEhliyetTarih.MaxDate = new DateTime(yil2 - 20, ay2, gun2);
            dateTimeEhliyetTarih.Format = DateTimePickerFormat.Short;
        }
        //
        //Müşteri göster.
        //
        private void musteriGoster()
        {
            try
            {
                baglantim.Open();
                OleDbDataAdapter kullanicilariListele = new OleDbDataAdapter(
                    "select tcno AS[TC KİMLİK NO],Ad AS[ADI],Soyad AS[SOYADI]," +
                    "Cinsiyet AS[CİNSİYET],DogumTarihi AS[DOĞUM TARİHİ]," +
                    "Telefon AS[TELEFON],Email AS[E-POSTA],Adres AS[ADRES]," +
                    "EhliyetNo AS[EHLİYET NO],EhliyetTarihi AS[EHLİYET TARİHİ]" +
                    " from musbil Order By ad ASC",
                    baglantim);
                DataSet dsHafiza = new DataSet();
                //fill dolduruyor
                kullanicilariListele.Fill(dsHafiza);
                dataGridView1.DataSource = dsHafiza.Tables[0];
                baglantim.Close();

            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message, "volkan yıldız Rent a Car programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglantim.Close();
            }
        }
        //
        //Müşteri ekle temizle.
        //
        private void musteriEkleTemizle()
        {
            masktxtTcNo.Clear();
            masktxtAd.Clear();
            masktxtSoyad.Clear();
            comboBoCinsiyet.SelectedIndex = 0;
            maskedtxtTelefon.Clear();
            maskedtxtEposta.Clear();
            maskedtxtAdres.Clear();
            maskedtxtEhliyetno.Clear();
            maskedTextBox1.Clear();
            

        }
        //
        //Kaydet Buton.
        //
        private void kaydet_Click(object sender, EventArgs e)
        {
            bool kayitKontrol = false;
            //ekleyeceğimiz kişi daha önce varmı yokmu bakıyoruz
            baglantim.Open();
            OleDbCommand selectSorgu = new OleDbCommand("select * from musbil where tcno='" + masktxtTcNo.Text + "'", baglantim);
            OleDbDataReader kayitOkuma = selectSorgu.ExecuteReader();
            while (kayitOkuma.Read())
            {
                kayitKontrol = true;
                break;
            }
            baglantim.Close();
            //girilen de veri tabanın da yok ise kayıt yapıyoz
            if (kayitKontrol == false)
            {

                if (masktxtTcNo.MaskCompleted==false)
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;

                //ad 2veri kontrol

                if (masktxtAd.MaskCompleted == false)
                    label2.ForeColor = Color.Red;
                else
                    label2.ForeColor = Color.Black;

                //soyad3 veri kontrol
                if (masktxtSoyad.MaskCompleted == false)
                    label3.ForeColor = Color.Red;
                else
                    label3.ForeColor = Color.Black;

                //cinsiyet 4 veri kontrol
                if (comboBoCinsiyet.SelectedIndex == 0)
                    label4.ForeColor = Color.Red;
                else
                    label4.ForeColor = Color.Black;

                //dogum tarih 5 veri kontrol
                if (dateTimePicker1.Text == "")
                    label9.ForeColor = Color.Red;
                else
                    label9.ForeColor = Color.Black;

                //telefon 6 veri kontrol
                if (maskedtxtTelefon.MaskCompleted== false)
                    label6.ForeColor = Color.Red;
                else
                    label6.ForeColor = Color.Black;

                //eposta 7 veri kontrol
                if (maskedtxtEposta.Text=="")
                    label7.ForeColor = Color.Red;
                else
                    label7.ForeColor = Color.Black;
                                
                //adres  8 veri kontrol
                if (maskedtxtAdres.Text=="")
                    label8.ForeColor = Color.Red;
                else
                    label8.ForeColor = Color.Black;

                //ehliyet no 9 veri kontrol
                if (maskedtxtEhliyetno.MaskCompleted == false)
                    label9.ForeColor = Color.Red;
                else
                    label9.ForeColor = Color.Black;  
                
                //ehliyet tarih 10 veri kontrol
                if (dateTimeEhliyetTarih.Text=="")
                    label10.ForeColor = Color.Red;
                else
                    label10.ForeColor = Color.Black;

                if (masktxtTcNo.MaskCompleted!=false && 
                    masktxtAd.MaskCompleted != false &&
                    masktxtSoyad.MaskCompleted != false &&
                    comboBoCinsiyet.Text!="" &&
                    maskedtxtTelefon.MaskCompleted != false &&
                    maskedtxtEposta.MaskCompleted != false && 
                    maskedtxtAdres.MaskCompleted != false &&
                    maskedtxtEhliyetno.MaskCompleted != false)
                {
                    try
                    {
                        baglantim.Open();
                        OleDbCommand ekle = new OleDbCommand("insert  into musbil " +
                            "(tcno,Ad,Soyad,Cinsiyet,DogumTarihi,Telefon,Email,Adres,EhliyetNo,EhliyetTarihi)" +
                            " values( '" + masktxtTcNo.Text + "'," +
                            "'" + masktxtAd.Text + "'," +
                            "'" + masktxtSoyad.Text + "', " +
                            "'" + comboBoCinsiyet.Text + "'," +
                           "'" + dateTimePicker1.Text + "'," +
                            "'" + maskedtxtTelefon.Text + "'," +
                            "'" + maskedtxtEposta.Text + "'," +
                            "'" + maskedtxtAdres.Text + "'," +
                            "'" + maskedtxtEhliyetno.Text + "'," +
                         "'" + dateTimeEhliyetTarih.Text + "'" +
                         ")",baglantim);
                        ekle.ExecuteNonQuery();
                        baglantim.Close();
                        MessageBox.Show("Kayıt başarılı bir şekilde oluşturuldu.", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        musteriGoster();
                        musteriEkleTemizle();
                    }
                    catch (Exception hatamsj)
                    {

                        MessageBox.Show(hatamsj.Message, "Kayıt e oluşturulamadı. VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglantim.Close();

                    }
                }
                else
                 MessageBox.Show("Kırmızı alanları düzeltin.", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
 
            }
            else
                MessageBox.Show("Girilen Tc No kayıtlıdır.", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
        //
        //<-------------------------------------kaydet buton------------------------------------->
        //

        //
        //*-------------------------------------sil buton-------------------------------------*
        //
        private void sil_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.MaskCompleted==true)
            {
                bool kayitAramaDurumu = false;
                baglantim.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from musbil where tcno='" + maskedTextBox1.Text + "'", baglantim);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();

                while (kayitokuma.Read())
                {
                    kayitAramaDurumu = true;
                    OleDbCommand deleteSorgu = new OleDbCommand("delete from musbil where tcno='" + maskedTextBox1.Text + "'", baglantim);
                    deleteSorgu.ExecuteNonQuery();

                    MessageBox.Show("Kullanıcı Kaydı Silindi.", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    baglantim.Close();
                    musteriGoster();
                    musteriEkleTemizle();
                    break;

                }

                if (kayitAramaDurumu == false)
                    MessageBox.Show("Kullanıcı Kaydı Bulunamadı!!", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                baglantim.Close();
                musteriGoster();
                musteriEkleTemizle();
            }//if

            else
                MessageBox.Show("Silmek istediğiniz kaydı  11 karakterden oluşan Tc no girin.!!", "VOLKAN RENT A CAR" , MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //
        //<-------------------------------------sil buton------------------------------------->
        //

        //
        //*-------------------------------------düzenle buton-------------------------------------*
        //
       
        
        
        private void duzenle_Click(object sender, EventArgs e)
        {
            if (masktxtTcNo.MaskCompleted == false)
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            //ad 2veri kontrol

            if (masktxtAd.MaskCompleted == false)
                label2.ForeColor = Color.Red;
            else
                label2.ForeColor = Color.Black;


            //soyad3 veri kontrol
            if (masktxtSoyad.MaskCompleted == false)
                label3.ForeColor = Color.Red;
            else
                label3.ForeColor = Color.Black;

            //cinsiyet 4 veri kontrol
            if (comboBoCinsiyet.Text == "")
                label6.ForeColor = Color.Red;
            else
                label6.ForeColor = Color.Black;

            //telefon 6 veri kontrol
            if (maskedtxtTelefon.Text == "")
                label6.ForeColor = Color.Red;
            else
                label6.ForeColor = Color.Black;


            //eposta 7 veri kontrol
            if (maskedtxtEposta.Text == "")
                label7.ForeColor = Color.Red;
            else
                label7.ForeColor = Color.Black;

            //adres 8 veri kontrol
            if (maskedtxtAdres.Text == "")
                label8.ForeColor = Color.Red;
            else
                label8.ForeColor = Color.Black;

            //ehlyietno 9 veri kontrol
            if (maskedtxtEhliyetno.Text.Length == 0)
                label9.ForeColor = Color.Red;
            else
                label9.ForeColor = Color.Black;

          
            if (masktxtTcNo.MaskCompleted != false &&
                masktxtAd.MaskCompleted != false &&
                masktxtSoyad.MaskCompleted != false &&
                comboBoCinsiyet.Text != "" &&
                maskedtxtTelefon.MaskCompleted != false &&
                maskedtxtEposta.MaskCompleted != false &&
                maskedtxtAdres.MaskCompleted != false &&
                maskedtxtEhliyetno.MaskCompleted != false)
            {
              
                      try
                         {
                        baglantim.Open();
                        OleDbCommand guncelle = new OleDbCommand("update musbil set " +
                            "Ad='"+masktxtAd.Text+ "'," +
                            "Soyad='" + masktxtSoyad.Text + "'," +
                            "Cinsiyet ='" + comboBoCinsiyet.Text + "'," +
                            "DogumTarihi='" + dateTimePicker1.Text + "'," +
                            "Telefon='" + maskedtxtTelefon.Text + "'," +
                            "Email='" + maskedtxtEposta.Text + "'," +
                            "Adres='" + maskedtxtAdres.Text + "'," +
                            "EhliyetNo='" + maskedtxtEhliyetno.Text + "'," +
                            "EhliyetTarihi='" + dateTimeEhliyetTarih.Text + "'" +
                            "where tcno='"+masktxtTcNo.Text+"'", baglantim);
                        guncelle.ExecuteNonQuery();//güneclle 
                        baglantim.Close();
                        musteriGoster();
                        musteriEkleTemizle();
                       MessageBox.Show("Kayıt başarılı bir şekilde değiştirildi.", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception hatamsj)
                        {
                            MessageBox.Show(hatamsj.Message, "Kayıt e oluşturulamadı. VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            baglantim.Close();
                        }
            }
        }
        //<<*-------------------------------------düzenle buton-------------------------------------*>>

        //
        //Temizle Buton.
        //
        private void formuTemizle_Click(object sender, EventArgs e)
        {
            musteriEkleTemizle();
        }

        //
        //*------------------------------------- ara butonu---------------------------------*
        //
        private void button1_Click(object sender, EventArgs e)
        {
            bool kayitAramaDurumu = false;
            if (maskedTextBox1.Text.Length ==11)
            {
           
             baglantim.Open();
             OleDbCommand selectsorgu = new OleDbCommand("select * from musbil where tcno='" + maskedTextBox1.Text + "'", baglantim);
             OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();

            while (kayitokuma.Read())
            {
                    kayitAramaDurumu = true;

                masktxtTcNo.Text = kayitokuma.GetValue(0).ToString();
                masktxtAd.Text = kayitokuma.GetValue(1).ToString();
                masktxtSoyad.Text = kayitokuma.GetValue(2).ToString();
                comboBoCinsiyet.Text = kayitokuma.GetValue(3).ToString();
                dateTimePicker1.Text = kayitokuma.GetValue(4).ToString();
                maskedtxtTelefon.Text = kayitokuma.GetValue(5).ToString();
                maskedtxtEposta.Text = kayitokuma.GetValue(6).ToString();
                maskedtxtAdres.Text = kayitokuma.GetValue(7).ToString();
                maskedtxtEhliyetno.Text = kayitokuma.GetValue(8).ToString();
                dateTimeEhliyetTarih.Text = kayitokuma.GetValue(9).ToString();
                break;

            }

            if (kayitAramaDurumu == false)
                MessageBox.Show("Kullanıcı Kaydı BULUNAMADI !!.", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Information);

            baglantim.Close();
         }
        //if
           else
                MessageBox.Show("Aramak isteiğiniz kaydın 11 karakterden oluşan Tc sini girin.!!", "VOLKAN RENT A CAR" , MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
 

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //tcno.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //tcno.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        //
        //Data Grid View Tıklandığında tc nonun seçilmesi
        //
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // Data Grid View çökyordu başlığa tıklayınca çökmemesi için 
            if (e.RowIndex == -1) return;
            
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        //
        //Sağ tık menüsünden seçme işlemi.
        //
        private void seçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }


 

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        //silme 
        void Sil(string tc)
        {
            if (tc!="")
            {

           
                    try
                    {
                        baglantim.Open();
                        string sql = "delete from musbil where tcno='"+tc+"'";
                        OleDbCommand com = new OleDbCommand(sql, baglantim);
                        com.ExecuteNonQuery();
                        baglantim.Close();
                        musteriGoster();
                        musteriEkleTemizle();
                        MessageBox.Show("Kullanıcı Kaydı Silindi.", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("silme hatası");
                    }

            }
        }

        int tcnoSag;
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            {

                //int satir = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                //if (satir > -1) //www.yazilimkodlama.com
                //{
                //    dataGridView1.Rows[satir].Selected = true;//bu tıkladığımız alanı seçtiriyoruz
                //    tcnoSag = Convert.ToInt32(dataGridView1.Rows[satir].Cells["tcno"].Value);
                //}
               // MessageBox.Show("sağ tık");
            }

            //if (e.Button == MouseButtons.Right)//farenin sağ tuşuna basılmışsa
            //{

            //    int satir = dataGridView1.HitTest(e.X, e.Y).RowIndex;
            //    if (satir > -1)
            //    {
            //        dataGridView1.Rows[satir].Selected = true;//bu tıkladığımız alanı seçtiriyoruz

            //    }
            //}
        }



        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //sağ tık ile silme .
            string tc = maskedTextBox1.Text;
            Sil(tc);
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            musteriGoster();

        }
    }
}
