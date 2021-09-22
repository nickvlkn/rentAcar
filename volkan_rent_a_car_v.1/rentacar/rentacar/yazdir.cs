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
//
using System.Drawing.Printing;

namespace rentacar
{
    public partial class yazdir : Form
    {
        public yazdir()
        {
            InitializeComponent();
            //Fare Tekerleğinin printPreviewControl1 ile kullanılması
            this.printPreviewControl1.MouseWheel += PrintPreviewControl1_MouseWheel;
        }
        //
        //Fare Tekerleğinin kullanılması
        //
        private void PrintPreviewControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta>0)
                printPreviewControl1.Zoom *= 1.2;
         
            else
                printPreviewControl1.Zoom /= 1.2;
        }
        //
        //LOAD
        //
        private void yazdir_Load(object sender, EventArgs e)
        {

        
        }
        //
        //Veri tabanı yolu ve provier 
        //
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.16.0;Data Source=rentacarverit.accdb");
        //
        //printDocument1
        //
        int i = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
         
            string sorgu; 
            if (textBox1.Text == "") 
                sorgu = "SELECT * FROM aracbil"; 
            else
                sorgu = "Select * From aracbil where model='" + textBox1.Text + "'"; 
            OleDbCommand komut = new OleDbCommand(sorgu, baglantim);
            OleDbDataAdapter adp = new OleDbDataAdapter(komut);
            DataTable tablo = new DataTable(); 
            adp.Fill(tablo);


            Font myFont = new Font("Arial", 10, FontStyle.Bold); //font oluşturduk      
            SolidBrush sbrush = new SolidBrush(Color.Black);//fırça oluşturduk      
            Pen myPen = new Pen(Color.Black); //kalem oluşturduk 

            e.Graphics.DrawString("Plaka", myFont, sbrush, 50, 50);
            e.Graphics.DrawString("Marka", myFont, sbrush, 150, 50);
            e.Graphics.DrawString("Tip", myFont, sbrush, 300, 50);
            e.Graphics.DrawString("Model", myFont, sbrush, 450, 50);
            e.Graphics.DrawString("Renk", myFont, sbrush, 550, 50);
            e.Graphics.DrawString("kiraDurumu", myFont, sbrush, 650, 50);
            e.Graphics.DrawLine(myPen, 50, 75, 770, 75); // Çizgi çizdik... 1. Kalem, 2. X, 3. Y Koordinatı, 4. Uzunluk, 5. BitişX      
            int y = 85; i = 0;
            myFont = new Font("Arial", 10, FontStyle.Regular); //font oluşturduk 


            while (i < tablo.Rows.Count)
            {
                e.Graphics.DrawString(tablo.Rows[i][0].ToString(), myFont, sbrush, 50, y);
                e.Graphics.DrawString(tablo.Rows[i][1].ToString(), myFont, sbrush, 150, y);
                e.Graphics.DrawString(tablo.Rows[i][2].ToString(), myFont, sbrush, 300, y);
                e.Graphics.DrawString(tablo.Rows[i][3].ToString(), myFont, sbrush, 450, y);
                e.Graphics.DrawString(tablo.Rows[i][4].ToString(), myFont, sbrush, 550, y);
                e.Graphics.DrawString(tablo.Rows[i][5].ToString(), myFont, sbrush, 650, y);
                y += 20; i++;
            }
        }
        //
        //Yazdır Buton
        //
        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }
        //
        //
        //
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void raporOlustur_Click(object sender, EventArgs e)
        {
            i = 0; this.printPreviewControl1.Document = this.printDocument1;
        }
    }
}
