using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//klasörleme işlemleri için
using System.IO;

 

namespace rentacar
{
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            musteri musterisayfa = new musteri();
          //  this.Hide();
            musterisayfa.ShowDialog();
            this.Show();
        }

        private void aracEkle_Click(object sender, EventArgs e)
        {
            aracEkle aracsayfa = new aracEkle();
            //  this.Hide();
            aracsayfa.ShowDialog();
            this.Show();
        }

        private void aracKirala_Click(object sender, EventArgs e)
        {
            aracKirala aracsayfa2 = new aracKirala();
            //  this.Hide();
            aracsayfa2.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            aracTeslim aracTeslimAl = new aracTeslim();
            //  this.Hide();
            aracTeslimAl.ShowDialog();
            this.Show();
        }
       musteri musteriForm;

        public object Application { get; private set; }

        private void gösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            //if (musteriForm == null || musteriForm.IsDisposed)
            //{
            //    musteriForm.Show();
            //}

        }


        // musteri musteriForm = Application.OpenForms["musteri"] as musteri;
        private void gizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
 

            this.Hide();
            //musteriForm.Name = "musteri";
            //if (Application.OpenForms["musteri"] == null )
            //{
            //    musteriForm.Show();

            //}

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            //  this.Close();
        
        }

        //
        // toolStrip Sözleşme öreneğini açma
        //
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string yol = Environment.CurrentDirectory.ToString();
            System.Diagnostics.Process.Start(yol + "\\aracResimleri\\sozlesmeOrnegi.pdf");
        }
        //
        //Menü den kapatma butonu
        //
        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        //
        //Menü den veri tabanını aç
        //
        private void veriTabanınıAÇToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string yol2 = Environment.CurrentDirectory.ToString();
            System.Diagnostics.Process.Start(yol2 + "\\rentacarverit.accdb");
        }
        //
        //Menü den  araç resim klasörünü aç
        //
        private void araçResimleriniAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string yol2 = Environment.CurrentDirectory.ToString();
            System.Diagnostics.Process.Start(yol2 + "\\aracResimleri\\");

        }

        private void iletişimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iletisim iletisim2 = new iletisim();
            //  this.Hide();
            iletisim2.ShowDialog();
            this.Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void raporBtn_Click(object sender, EventArgs e)
        {
            raporTarih raporTarih2 = new raporTarih();
            //  this.Hide();
            raporTarih2.ShowDialog();
            this.Show();
        }

        private void nasılKullanılırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string yol = Environment.CurrentDirectory.ToString();
            System.Diagnostics.Process.Start(yol + "\\aracResimleri\\rentacarProgramAnlatim.docx");
        }
    }
    
}
//if (musteriForm==null||musteriForm.IsDisposed)
//{
//    musteriForm.Close();
//}