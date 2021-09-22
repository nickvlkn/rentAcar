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
using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;

namespace rentacar
{
    public partial class raporTarih : Form
    {
        OleDbConnection con;
        OleDbDataAdapter da;
        DataTable dt;

        public raporTarih()
        {
            InitializeComponent();
        }

        //Veri tabanı yolu ve provier 
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.16.0;Data Source=rentacarverit.accdb");
        DataTable tablo = new DataTable();

        void VeriGetir()
        {
         
        }
 

        private void button1_Click(object sender, EventArgs e)
        {


            //barış
            DateTime tarih1 = dateTimePicker1.Value;
            string t1 = tarih1.ToString("MM/dd/yyyy");
            string t1s = "";
            DateTime tarih2 = dateTimePicker2.Value;
            string t2 = tarih2.ToString("MM/dd/yyyy");
            string t2s = "";

            for (int i = 0; i < t1.Length; i++)
            {
                if (t1[i] == '.')
                    t1s = t1s + '/';
                else if (t1[i] == ' ')
                    break;
                else
                    t1s = t1s + t1[i];

            }
            for (int a = 0; a < t2.Length; a++)
            {
                if (t2[a] == '.')
                    t2s = t2s + '/';
                else if (t2[a] == ' ')
                    break;
                else
                    t2s = t2s + t2[a];

            }


            string sorguCalistir = "select  format(tarih,'dd.mm.yyyy') as 'Tarih',format(saat,'hh:mm:ss') as 'Saat' , ka_plaka as 'Plaka' , ka_tcno as 'Tc No' , ka_ad as 'Ad' , ka_soyad as 'Soyad' , ka_telefon as 'Telefon' ,ka_ehliyet_no as 'Ehliyet No', ka_marka as 'Marka' , ka_model as 'Model', ka_durum as 'Durum'" +
           " from kiralanmis_araclar" +
           " where tarih BETWEEN #" + t1s + "# and #" + t2s + "#";

            try
            {
                baglantim.Open();
                OleDbDataAdapter sorgu = new OleDbDataAdapter(sorguCalistir, baglantim);
                DataSet satis = new DataSet();
                sorgu.Fill(satis);
                gunaDataGridView1.DataSource = satis.Tables[0];
                baglantim.Close();

            }
            catch (Exception)
            {

                MessageBox.Show("db hata");
            }



        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void raporTarih_Load(object sender, EventArgs e)
        {
            VeriGetir();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
