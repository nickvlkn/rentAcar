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
    public partial class aracKirala : Form
    {
        public aracKirala()
        {
            InitializeComponent();
         
           // this.printPreviewDialog1.MouseWheel += PrintPreviewDialog1_MouseWheel;
        }
        //fare tekerlek çalışmadı
        private void PrintPreviewDialog1_MouseWheel(object sender, MouseEventArgs e)
        {

            //if (e.Delta > 0)
            //    printPreviewDialog1.Zoom *= 1.2;

            //else
            //    printPreviewDialog1.Zoom /= 1.2;

        }

        //Veri tabanı yolu ve provier 
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.16.0;Data Source=rentacarverit.accdb");
        //
        //Araçları listeleme metodu
        //
        void listele()
        {
           // OleDbDataAdapter aracListele = new OleDbDataAdapter("select Plaka AS[PALKA],Marka AS[MARKA],Tip AS[TİP],Model AS[MODEL],Renk AS[RENK] from aracbil Order By Plaka ASC", baglantim);
            OleDbDataAdapter aracListele = new OleDbDataAdapter(
                "select * from aracbil where kiraDurumu='bosta' Order By Plaka ASC", baglantim);
        
            DataSet dsHafiza2 = new DataSet();
            //fill dolduruyor
            aracListele.Fill(dsHafiza2);
            gunaDataGridView1.DataSource = dsHafiza2.Tables[0];
            baglantim.Close();
        }
        //
        //Müşeterileri listeleme metodu
        //
        void listele2()
        {
            baglantim.Open();
            OleDbDataAdapter kullanicilariListele = new OleDbDataAdapter(
                 "select tcno AS[TC NO],Ad AS[ADI],Soyad AS[SOYADI],Telefon AS[TELEFON],EhliyetNo AS[EHLİYET NO] from musbil Order By tcno ASC", baglantim);
            //   "select tcno AS[TC NO],Ad AS[ADI],Soyad AS[SOYADI],Telefon AS[TELEFON],EhliyetNo AS[EHLİYET NO],  from musbil Order By tcno ASC",  baglantim);
            DataSet dsHafiza = new DataSet();
            //fill dolduruyor
            kullanicilariListele.Fill(dsHafiza);
            gunaDataGridView2.DataSource = dsHafiza.Tables[0];
        //    dataGridView2.DataSource = dsHafiza.Tables[0];
            baglantim.Close();
        }
        //
        //Bagla
        //
        void bagla()
            {
            OleDbDataAdapter baglaa = new OleDbDataAdapter("select musbil.tc from aracbil Order By Plaka ASC", baglantim);
        }
        //
        // FORM LOAD
        //
        private void aracKirala_Load(object sender, EventArgs e)
        {
            listele();
            listele2();
            resimGetir();
            musteriTcNo.ReadOnly = true;
            aracPlakatxt.ReadOnly = true;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            //  textBox6.ReadOnly = true;
            // textBox3.Visible = false;




        }
        //
        //Kirala Buton Click
        //
        private void kiralabtn_Click(object sender, EventArgs e)
        {


            string tarih = "", saat = "";
            bool kayitKontrol = false;
            //tarih saat çekme
            tarih = DateTime.Now.ToString("dd/MM/yyyy");
            saat = DateTime.Now.ToString("HH:mm:ss");

            //ekleyeceğimiz kişi daha önce varmı yokmu bakıyoruz
            baglantim.Open();
            OleDbCommand selectSorgu = new OleDbCommand("select * from kiralanmis_araclar where ka_plaka='" + aracPlakatxt.Text + "'", baglantim);
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
                // araç
                if (musteriTcNo.Text == "") 
                    label5.ForeColor = Color.Red;
                else
                    label5.ForeColor = Color.Black;

                // müşteri tc veri kontrol
                if (aracPlakatxt.Text == "")
                    label4.ForeColor = Color.Red;
                else
                    label4.ForeColor = Color.Black;

                if (musteriTcNo.Text != ""&& aracPlakatxt.Text != ""  )
                {
                    try
                    {
                        textBox7durum.Text = "kiralandi";
                        baglantim.Open();                                                       //  ,'" dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString() "'
                        OleDbCommand ekle = new OleDbCommand("insert  into kiralanmis_araclar(ka_plaka,ka_tcno,ka_ad,ka_soyad,ka_telefon,ka_ehliyet_no,ka_marka,ka_model,ka_durum,tarih,saat) " +
                            "values( '" + aracPlakatxt.Text + "','" + musteriTcNo.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7durum.Text + "','" + tarih + "','" + saat + "')", baglantim);
                        ekle.ExecuteNonQuery();
                        OleDbCommand KiraDurumuEkle = new OleDbCommand("update aracbil set kiraDurumu='kiralandi' where Plaka='" + aracPlakatxt.Text + "'", baglantim);
                        KiraDurumuEkle.ExecuteNonQuery();
                        baglantim.Close();
                        MessageBox.Show("Araç kiralandı. İyi günlerde kullanın.  :D", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        listele();
                    }
                    catch (Exception hatamsj)
                    {
                        MessageBox.Show(hatamsj.Message, "Araç Kiralnamadı . VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglantim.Close();
                    }
                }
                else
                    MessageBox.Show("Kırmızı alanları düzeltin.", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("'"+aracPlakatxt.Text+"'nolu araç zaten kiralanmıştır.", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
       
        }
        //
        // resim gösterme  data'sı.
        //  
        //
        void resimGetir()
        {


            bool kayitAramaDurumu = false;
            if (aracPlakatxt.Text!="")
            {
                baglantim.Open();
                //araclar  tablosundaki tüm alanları seç where tcno alanındaki eşit olanalrı getir 
                OleDbCommand selecsorgu = new OleDbCommand("select * from aracbil where Plaka='" + aracPlakatxt.Text + "'", baglantim);
                OleDbDataReader kayitOkuma = selecsorgu.ExecuteReader();
                while (kayitOkuma.Read())
                {
                    kayitAramaDurumu = true;
                    //   veri tabanından 1 nolu elemanı alıp stringe dönüştürüp yazdırıyoruz
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
 

                }
            }
         }


                // Araçları gösterme  data'sı.
                //
                private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Data Grid View çökyordu başlığa tıklayınca çökmemesi için 
            if (e.RowIndex == -1) return;

            aracPlakatxt.Text = gunaDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox5.Text = gunaDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox6.Text = gunaDataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox7durum.Text = gunaDataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            bool kayitAramaDurumu = false;
            if (aracPlakatxt.Text != "")
            {
                baglantim.Open();
                //araclar  tablosundaki tüm alanları seç where tcno alanındaki eşit olanalrı getir 
                OleDbCommand selecsorgu = new OleDbCommand("select * from aracbil where Plaka='" + aracPlakatxt.Text + "'", baglantim);
                OleDbDataReader kayitOkuma = selecsorgu.ExecuteReader();  

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
                //  eğer yok ise folse ise
                //if (kayitAramaDurumu == false)
                //{  //Exclamation bilgi msg box
                //    MessageBox.Show("Araç Kaydı BULUNAMADI !!", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
                baglantim.Close();
            }
            else
            {
                MessageBox.Show("Araç plakasın'da hata!", "VOLKAN RENT A CAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }
        //
        //Müşteri bilgilerini gösterme datası
        //
        private void gunaDataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Data Grid View çökyordu başlığa tıklayınca çökmemesi için 
            if (e.RowIndex == -1) return;
            musteriTcNo.Text = gunaDataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = gunaDataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = gunaDataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = gunaDataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = gunaDataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();

        }
        //
        //Yazdir butonu.
        //
        private void button1_Click(object sender, EventArgs e)
        {

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

            //sozlesmeYazdir sozyazdirsayfa = new sozlesmeYazdir();
            ////  this.Hide();
            //sozyazdirsayfa.ShowDialog();
            //this.Show();
        }


        Font Baslik = new Font("Verdana", 14, FontStyle.Bold);
        Font govde = new Font("Verdana", 12);
        SolidBrush sb = new SolidBrush(Color.Black);

        //int i = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat sFormat = new StringFormat();


            sFormat.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("Volkan Rent A Car Araç Kiralama Sözleşmesi\n", Baslik, sb, 200, 100);
            e.Graphics.DrawString("Sözleşmenin Tarafları", Baslik, sb, 70, 150);

            e.Graphics.DrawString("Kiraya Veren :", Baslik, sb, 70, 200);
            e.Graphics.DrawString(" Volkan Rent A Car Ltd. Şti.", govde, sb, 230, 200);
            e.Graphics.DrawString("Adres : ", Baslik, sb, 70, 250);
            e.Graphics.DrawString(" KADIKÖY - İSTANBUL.", govde, sb, 170, 250);

            e.Graphics.DrawString("Kiracı :", Baslik, sb, 70, 300);
            e.Graphics.DrawString(textBox1.Text +" "+ textBox2.Text , govde, sb, 170, 300);

            e.Graphics.DrawString("Tc No :", Baslik, sb, 70, 350);    
            e.Graphics.DrawString( musteriTcNo.Text, govde, sb, 170, 350);    

            e.Graphics.DrawString("Telefon :", Baslik, sb, 70, 400);  
            e.Graphics.DrawString(textBox3.Text, govde, sb, 170, 400);  

            e.Graphics.DrawString("Ehliyet NO :" , Baslik, sb, 70, 450);
            e.Graphics.DrawString( textBox4.Text, govde, sb, 170, 450);

            e.Graphics.DrawString("Sözleşmenin Konusu", Baslik, sb, 70, 500);
            e.Graphics.DrawString("Aşağıda plakası ve teknik özellikleri yazılı bulunan" +
                                           "aracı belirlenen şartlarda \n kiralanmasıdır.", govde, sb, 70, 550);

            e.Graphics.DrawString("Aracın Plakası :", Baslik, sb, 70, 600);
            e.Graphics.DrawString(  aracPlakatxt.Text, govde, sb, 250, 600);

            e.Graphics.DrawString("Aracın Markası :", Baslik, sb, 70, 650);
            e.Graphics.DrawString(textBox5.Text, govde, sb, 250, 650);

            e.Graphics.DrawString("Aracın Modeli :", Baslik, sb, 70, 700);
            e.Graphics.DrawString(textBox6.Text, govde, sb, 250, 700);

            e.Graphics.DrawString("Sözleşmenin Başlangıcı Ve Süresi", Baslik, sb, 70, 750);

            e.Graphics.DrawString("Sözleşmenin başlangıcı :"  , Baslik, sb, 70, 800);
            e.Graphics.DrawString("Tarih: .../.../....       Saat:.../..." , govde, sb, 350, 800);

            e.Graphics.DrawString("Sözleşmenin Süresi :" , Baslik, sb, 70, 850);
            e.Graphics.DrawString("Gün: .....       Ay:.....", govde, sb, 320, 850);

            
            e.Graphics.DrawString("Fiyat : ......" , Baslik, sb, 70,900);




            e.Graphics.DrawString(textBox1.Text+ textBox2.Text+"\n İMZA:", govde, sb, 70, 1000);
            e.Graphics.DrawString(" Volkan Renk A Car \n İMZA:", govde, sb, 400, 1000);
 



            //string sorgu;
            //sorgu = "select * from aracbil";
            //OleDbCommand komut = new OleDbCommand(sorgu, baglantim);
            //OleDbDataAdapter adp = new OleDbDataAdapter(komut);
            //DataTable tablo = new DataTable(); 
            //adp.Fill(tablo);

            //Font myFont = new Font("Arial", 10, FontStyle.Bold); //font oluşturduk      
            //SolidBrush sbrush = new SolidBrush(Color.Black);//fırça oluşturduk      
            //Pen myPen = new Pen(Color.Black); //kalem oluşturduk 

            //e.Graphics.DrawString("Plaka", myFont, sbrush, 50, 50); 
            //e.Graphics.DrawString("Marka", myFont, sbrush, 150, 50);
            //e.Graphics.DrawString("Tip", myFont, sbrush, 300, 50);
            //e.Graphics.DrawString("Model", myFont, sbrush, 450, 50);
            //e.Graphics.DrawString("Renk", myFont, sbrush, 550, 50);
            //e.Graphics.DrawString("kiraDurumu", myFont, sbrush, 650, 50);
            //e.Graphics.DrawLine(myPen, 50, 75, 770, 75); // Çizgi çizdik... 1. Kalem, 2. X, 3. Y Koordinatı, 4. Uzunluk, 5. BitişX      
            //int y = 85; i = 0;    
            //myFont = new Font("Arial", 10, FontStyle.Regular); //font oluşturduk 


            //while (i < tablo.Rows.Count) 
            //{ 
            //    e.Graphics.DrawString(tablo.Rows[i][0].ToString(), myFont, sbrush, 50, y);
            //    e.Graphics.DrawString(tablo.Rows[i][1].ToString(), myFont, sbrush, 150, y);
            //    e.Graphics.DrawString(tablo.Rows[i][2].ToString(), myFont, sbrush, 300, y);
            //    e.Graphics.DrawString(tablo.Rows[i][3].ToString(), myFont, sbrush, 450, y);
            //    e.Graphics.DrawString(tablo.Rows[i][4].ToString(), myFont, sbrush, 550, y);
            //    e.Graphics.DrawString(tablo.Rows[i][5].ToString(), myFont, sbrush, 650, y);
            //    y += 20; i++; 
            //}


        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            this.Text = "Rent A Car";
            
            printPreviewDialog1.Icon = new Icon("car.ico");
       
        }
    }
}
