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

namespace rentacar
{
    public partial class aracEkle : Form
    {
        public aracEkle()
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
                    "select Plaka AS[PALKA],Marka AS[MARKA],Tip AS[TİP],Model AS[MODEL],Renk AS[RENK] from aracbil Order By Plaka ASC",baglantim);
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
     

        private void aracEkle_Load(object sender, EventArgs e)
        {//form load


            comboxModel.SelectedIndex = 0;
            comboxTip.SelectedIndex = 0;

            masktxtPlaka.Mask = "AAAaaAaa";
            masktxtAraSil.Mask = "AAAaaAaa";
            masktxtMarka.Mask = "LL???????????????????";
            masktxtRenk.Mask= "LL???????????????????"; 
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            aracGoster();
           
        }

        private void aracEkleTemizle()
        {      
            masktxtPlaka.Clear();
            masktxtMarka.Clear();
            masktxtAraSil.Clear();
            comboxModel.SelectedIndex = 0;
            comboxTip.SelectedIndex = 0;
            masktxtRenk.Clear();
            pictureBox1.Image = null;



        }

        private void temizleBtn_Click(object sender, EventArgs e)
        {
          aracEkleTemizle();
        }

        //resim ekle butonu----------------------------------
        private void resimEklebtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog resimsec = new OpenFileDialog();
            resimsec.Title = "Araç Resmi Seçin.";
            resimsec.Filter = "JPG Dosyalar(*.jpg | *.jpg";

            if (resimsec.ShowDialog() == DialogResult.OK)//resim sec kodu resmi seçtiyse
            {
                this.pictureBox1.Image = new Bitmap(resimsec.OpenFile());//seçilen resmi al
            }
        }
        //resim ekle butonu----------------------------------***


        // kaydet butonu ----------------------------------
        private void kaydetbtn_Click(object sender, EventArgs e)
        {

            bool kayitKontrol = false;
            //ekleyeceğimiz kişi daha önce varmı yokmu bakıyoruz
            baglantim.Open();
            OleDbCommand selectSorgu = new OleDbCommand("select * from aracbil where Plaka='" + masktxtPlaka.Text + "'", baglantim);
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

          
                // plaka koontrol 
                if (masktxtPlaka.MaskCompleted == false)
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;

                //marka 2veri kontrol

                if (masktxtMarka.MaskCompleted == false)
                    label2.ForeColor = Color.Red;
                else
                    label2.ForeColor = Color.Black;


                //tip 3 veri kontrol
                if (comboxTip.Text == "")
                    label3.ForeColor = Color.Red;
                else
                    label3.ForeColor = Color.Black;

                //model 4 veri kontrol
                if (comboxModel.Text == "")
                    label4.ForeColor = Color.Red;
                else
                    label4.ForeColor = Color.Black;

                //renk 5 veri kontrol
                if (masktxtRenk.Text == "")
                    label5.ForeColor = Color.Red;
                else
                    label5.ForeColor = Color.Black;

                // resim kontrol 
                if (pictureBox1.Image == null)
                    resimEklebtn.ForeColor = Color.Red;
                else
                    resimEklebtn.ForeColor = Color.Black;


                if (pictureBox1.Image!=null &&
                    masktxtPlaka.MaskCompleted != false &&
                    masktxtMarka.MaskCompleted != false &&
                    masktxtRenk.MaskCompleted != false &&
                    comboxModel.Text != "" &&
                    comboxTip.Text != "" )
                {
                    try
                    {
                        baglantim.Open();
                        OleDbCommand ekleKomutu = new OleDbCommand("insert into aracbil (Plaka,Marka,Tip,Model,Renk,kiraDurumu) values" +
                            "('" + masktxtPlaka.Text + "','" + masktxtMarka.Text + "','" + comboxTip.Text+ "'," +
                           "'" + comboxModel.Text + "','" + masktxtRenk.Text + "','bosta')", baglantim);
                        ekleKomutu.ExecuteNonQuery();
                        baglantim.Close();

                        if (!Directory.Exists(Application.StartupPath + "\\aracResimleri"))
                        {
                            Directory.CreateDirectory(Application.StartupPath + "\\aracResimleri");
                        }
                        else
                            pictureBox1.Image.Save(Application.StartupPath + "\\aracResimleri\\" + masktxtPlaka.Text+".jpg");

                        //duzenlebtn.PerformClick();
                        MessageBox.Show("Kayıt başarılı bir şekilde oluşturuldu.", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        aracGoster();
                        aracEkleTemizle();
                    }
                    catch (Exception hatamsj)
                    {

                        MessageBox.Show(hatamsj.Message, "Kayıt oluşturulamadı. VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglantim.Close();

                    }
                }
                else
                    MessageBox.Show("Kırmızı alanları düzeltin.", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Girilen  araç plakası kayıtlıdır.", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
        //kaydet butonu ----------------------------------***



        //*------------------------------------- ara butonu---------------------------------*
        private void araBtn_Click(object sender, EventArgs e)
        {


            bool kayitAramaDurumu = false;
            if (masktxtAraSil.MaskCompleted == true)
            {
                baglantim.Open();
                //araclar  tablosundaki tüm alanları seç where tcno alanındaki eşit olanalrı getir 
                OleDbCommand selecsorgu = new OleDbCommand("select * from aracbil where Plaka='" + masktxtAraSil.Text + "'", baglantim);
                OleDbDataReader kayitOkuma = selecsorgu.ExecuteReader();
                while (kayitOkuma.Read())
                {
                    kayitAramaDurumu = true;
                 //   veri tabanından 1 nolu elemanı alıp stringe dönüştürüp yazdırıyoruz
                    try
                    {
                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\aracResimleri\\" +kayitOkuma.GetValue(0).ToString() + ".jpg");
                        //bulnunan kaydın 0. plaka alanını aldık.
                    }
                    catch
                    {
                        MessageBox.Show("Araç resmi Bulunamadı!!", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //resim yok resmini getireymiyorum çalışmıyor 
                         pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\aracResimleri\\resimyok.jpg");
                    }

                    masktxtPlaka.Text = kayitOkuma.GetValue(0).ToString();
                    masktxtMarka.Text = kayitOkuma.GetValue(1).ToString();
                    comboxTip.Text = kayitOkuma.GetValue(2).ToString();
                    comboxModel.Text = kayitOkuma.GetValue(3).ToString();
                    masktxtRenk.Text = kayitOkuma.GetValue(4).ToString();

                    //  break;
                }
              //  eğer yok ise folse ise
                if (kayitAramaDurumu == false)
                {  //Exclamation bilgi msg box
                    MessageBox.Show("Araç Kaydı BULUNAMADI !!", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                baglantim.Close();

            }
            else
            {
                MessageBox.Show("Araç plakasını doğru girin!!", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                aracEkleTemizle();
            }
        }
        //*<<------------------------------------- ara butonu---------------------------------*>>





        //*-------------------------------------sil buton-------------------------------------*
        private void silbtn_Click(object sender, EventArgs e)
        {
            if (masktxtAraSil.MaskCompleted == true)
            {
                bool kayitAramaDurumu = false;
                baglantim.Open();
                OleDbCommand aramaSorgu = new OleDbCommand("select * from aracbil where Plaka='" + masktxtAraSil.Text + "'", baglantim);
                OleDbDataReader kayitokuma = aramaSorgu.ExecuteReader();

                while (kayitokuma.Read())
                {
                    kayitAramaDurumu = true;
                    OleDbCommand deleteSorgu = new OleDbCommand("delete from aracbil where Plaka='" + masktxtAraSil.Text + "'", baglantim);
                    deleteSorgu.ExecuteNonQuery();
                    MessageBox.Show("Araç Kaydı Silindi.", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //baglantim.Close();
                    //aracGoster();
                    //aracEkleTemizle();
                    break;

                }

                if (kayitAramaDurumu == false)
                    MessageBox.Show("Silinecek Araç Kaydı Bulunamadı!!", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                baglantim.Close();
                aracGoster();
                aracEkleTemizle();
            }//if

            else
                MessageBox.Show("Silmek istediğiniz kaydın Plakasını doğru girin.!!", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        //<<*-------------------------------------sil buton-------------------------------------*>>

        //*-------------------------------------düzenle buton-------------------------------------*
        private void duzenlebtn_Click(object sender, EventArgs e)
        {
                // plaka koontrol 
                if (masktxtPlaka.MaskCompleted == false)
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;

                //marka 2veri kontrol

                if (masktxtMarka.MaskCompleted == false)
                    label2.ForeColor = Color.Red;
                else
                    label2.ForeColor = Color.Black;


                //tip 3 veri kontrol
                if (comboxTip.Text == "")
                    label3.ForeColor = Color.Red;
                else
                    label3.ForeColor = Color.Black;

                //model 4 veri kontrol
                if (comboxModel.Text == "")
                    label4.ForeColor = Color.Red;
                else
                    label4.ForeColor = Color.Black;

                //renk 5 veri kontrol
                if (masktxtRenk.Text == "")
                    label5.ForeColor = Color.Red;
                else
                    label5.ForeColor = Color.Black;

                // resim kontrol 
                if (pictureBox1.Image == null)
                    resimEklebtn.ForeColor = Color.Red;
                else
                    resimEklebtn.ForeColor = Color.Black;


                if (pictureBox1.Image != null &&
                    masktxtPlaka.MaskCompleted != false &&
                    masktxtMarka.MaskCompleted != false &&
                    masktxtRenk.MaskCompleted != false &&
                    comboxModel.Text != "" &&
                    comboxTip.Text != "")
                {
                    try
                    {
                        baglantim.Open();
                        OleDbCommand guncelleKomutu = new OleDbCommand("update aracbil set " +
                            "Marka='" + masktxtMarka.Text + "', Tip='" + comboxTip.Text + "'," +
                           "Model='" + comboxModel.Text + "',Renk='" + masktxtRenk.Text + "'where Plaka='"+masktxtPlaka.Text+"'", baglantim);
                       
                        guncelleKomutu.ExecuteNonQuery();
                        baglantim.Close(); 
                        aracGoster();
                        aracEkleTemizle();
                        MessageBox.Show("Kayıt başarılı bir şekilde oluşturuldu.", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //if (!Directory.Exists(Application.StartupPath + "\\aracResimleri"))
                    //{
                    //    Directory.CreateDirectory(Application.StartupPath + "\\aracResimleri");
                    //}
                    //else
                    //    pictureBox1.Image.Save(Application.StartupPath + "\\aracResimleri\\" + masktxtPlaka.Text + ".jpg");
                    }
                    catch (Exception hatamsj)
                    {

                        MessageBox.Show(hatamsj.Message, "Kayıt oluşturulamadı. VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglantim.Close();

                    }
              
               
                }
        

        }
        //<<*-------------------------------------düzenle buton-------------------------------------*>>



        private void txtAracBul_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Data Grid View çökyordu başlığa tıklayınca çökmemesi için 
            if (e.RowIndex == -1) return;
            masktxtAraSil.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            yazdir yazdirsayfa = new yazdir();
            //  this.Hide();
            yazdirsayfa.ShowDialog();
            this.Show();
        }
    }//from
}//namespace

