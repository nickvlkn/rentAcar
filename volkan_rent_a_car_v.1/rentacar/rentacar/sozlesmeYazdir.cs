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
    public partial class sozlesmeYazdir : Form
    {
        public sozlesmeYazdir()
        {
            InitializeComponent();
        }



        //
        //Veri tabanı yolu ve provier 
        //
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.16.0;Data Source=rentacarverit.accdb");
        //
        Font Baslik = new Font("Verdana", 14, FontStyle.Bold);
        Font govde = new Font("Verdana", 12);
        SolidBrush sb = new SolidBrush(Color.Black);

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            //StringFormat sFormat = new StringFormat();


            //sFormat.Alignment = StringAlignment.Near;
            //e.Graphics.DrawString("Volkan Rent A Car Araç Kiralama Sözleşmesi\n", Baslik, sb, 200, 100);
            //e.Graphics.DrawString("Sözleşmenin Tarafları", Baslik, sb, 70, 150);

            //e.Graphics.DrawString("Kiraya Veren :", Baslik, sb, 70, 200);
            //e.Graphics.DrawString(" Volkan Rent A Car Ltd. Şti.", govde, sb, 230, 200);
            //e.Graphics.DrawString("Adres : ", Baslik, sb, 70, 250);
            //e.Graphics.DrawString(" KADIKÖY - İSTANBUL.", govde, sb, 170, 250);

            //e.Graphics.DrawString("Kiracı :", Baslik, sb, 70, 300);
            //e.Graphics.DrawString(textBox1.Text + " " + textBox2.Text, govde, sb, 170, 300);

            //e.Graphics.DrawString("Tc No :", Baslik, sb, 70, 350);
            //e.Graphics.DrawString(musteriTcNo.Text, govde, sb, 170, 350);

            //e.Graphics.DrawString("Telefon :", Baslik, sb, 70, 400);
            //e.Graphics.DrawString(textBox3.Text, govde, sb, 170, 400);

            //e.Graphics.DrawString("Ehliyet NO :", Baslik, sb, 70, 450);
            //e.Graphics.DrawString(textBox4.Text, govde, sb, 170, 450);

            //e.Graphics.DrawString("Sözleşmenin Konusu", Baslik, sb, 70, 500);
            //e.Graphics.DrawString("Aşağıda plakası ve teknik özellikleri yazılı bulunan" +
            //                               "aracı belirlenen şartlarda \n kiralanmasıdır.", govde, sb, 70, 550);

            //e.Graphics.DrawString("Aracın Plakası :", Baslik, sb, 70, 600);
            //e.Graphics.DrawString(aracPlakatxt.Text, govde, sb, 250, 600);

            //e.Graphics.DrawString("Aracın Markası :", Baslik, sb, 70, 650);
            //e.Graphics.DrawString(textBox5.Text, govde, sb, 250, 650);

            //e.Graphics.DrawString("Aracın Modeli :", Baslik, sb, 70, 700);
            //e.Graphics.DrawString(textBox6.Text, govde, sb, 250, 700);

            //e.Graphics.DrawString("Sözleşmenin Başlangıcı Ve Süresi", Baslik, sb, 70, 750);

            //e.Graphics.DrawString("Sözleşmenin başlangıcı :", Baslik, sb, 70, 800);
            //e.Graphics.DrawString("Tarih: .../.../....       Saat:.../...", govde, sb, 350, 800);

            //e.Graphics.DrawString("Sözleşmenin Süresi :", Baslik, sb, 70, 850);
            //e.Graphics.DrawString("Gün: .....       Ay:.....", govde, sb, 320, 850);



            //e.Graphics.DrawString(textBox1.Text + textBox2.Text + "\n İMZA:", govde, sb, 70, 1000);
            //e.Graphics.DrawString(" Volkan Renk A Car \n İMZA:", govde, sb, 400, 1000);



        }

        private void sozlesmeYazdir_Load(object sender, EventArgs e)
        {

        }
    }
}
